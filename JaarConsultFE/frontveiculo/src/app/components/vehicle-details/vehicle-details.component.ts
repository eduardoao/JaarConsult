import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgbAlert } from '@ng-bootstrap/ng-bootstrap/alert/alert';
import { debounceTime, Subject } from 'rxjs';

import { VehicleService } from 'src/app/services/vehicle.service';

@Component({
  selector: 'app-vehicle-details',
  templateUrl: './vehicle-details.component.html',
  styleUrls: ['./vehicle-details.component.css']
})
export class VehicleDetailsComponent implements OnInit {

  private _success = new Subject<string>();
  private _error = new Subject<string>();

  staticAlertClosed = false;
  successMessage = '';
  errorMessage = '';

  @ViewChild('staticAlert', {static: false}) staticAlert: NgbAlert | undefined;
  @ViewChild('selfClosingAlert', {static: false}) selfClosingAlert: NgbAlert | undefined;


  currentVehicle: null | undefined ;
  placa = '';
  message = '';

  vehicle = {
    id: '',
    placa: '',
    valor: '',
    marca: '',
    modelo: '',
    anoModelo: '',
    combustivel:'',
    codigoFipe: '',
    mesReferencia:''
  };

  constructor(
    private vehicleService: VehicleService,
    private router: Router ) { }

  ngOnInit(): void {

    this._error.subscribe(message => this.errorMessage = message);
    this._success.subscribe(message => this.successMessage = message);
    this._success.pipe(debounceTime(5000)).subscribe(() => {
      if (this.selfClosingAlert) {
        this.selfClosingAlert.close();
        this.router.navigate(['/vehicles']);
      }
    });

    this._error.pipe(debounceTime(5000)).subscribe(() => {
      if (this.selfClosingAlert) {
        this.selfClosingAlert.close();
        this.router.navigate(['/vehicles']);
      }
    });
  }

  getVehicleByPlate(): void {
    this.vehicleService.getByPlate(this.placa)
      .subscribe(
        vehicle => {
          this.vehicle = vehicle.data;
          console.log(vehicle);
        },
        error => {
          console.log(error);
        });
  }

  update(): void {
    this.vehicleService.update(this.vehicle.id,  this.vehicle)
    .subscribe(
      vehicle => {
        this._success.next(vehicle.messages[0]);
        this.vehicle = vehicle.data;
        console.log(vehicle);
      },
      error => {
        this._error.next(error.error.messages[0]);
        console.log(error.error.messages[0]);
      });
  }

  trash(): void {
    this.vehicleService.delete(this.vehicle.id)
    .subscribe(
      vehicle => {
        this.vehicle = vehicle.data;
        this._success.next("Veículo excluído com sucesso!");
        console.log(vehicle);
      },
      error => {
        this._error.next(error.error.messages[0]);
        console.log(error.error.messages[0]);
      });
  }


}
