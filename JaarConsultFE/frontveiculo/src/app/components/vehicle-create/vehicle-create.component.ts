
import { Component, OnInit, ViewChild } from '@angular/core';

import {Subject} from 'rxjs';
import {debounceTime} from 'rxjs/operators';
import {NgbAlert} from '@ng-bootstrap/ng-bootstrap';

import { VehicleService } from 'src/app/services/vehicle.service';
import { AlertService } from 'src/app/components/alert.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vehicle-create',
  templateUrl: './vehicle-create.component.html',
  styleUrls: ['./vehicle-create.component.css']
})
export class VehicleCreateComponent implements OnInit {

  currentVehicle: null | undefined ;
  codigoFipe = '';
  year = '';
  message = '';

  vehicle = {
    placa: '',
    valor: '',
    marca: '',
    modelo: '',
    anoModelo: '',
    combustivel:'',
    codigoFipe: '',
    mesReferencia:''
  };

  submitted = false;

  private _success = new Subject<string>();
  private _error = new Subject<string>();

  staticAlertClosed = false;
  successMessage = '';
  errorMessage = '';

  @ViewChild('staticAlert', {static: false}) staticAlert: NgbAlert | undefined;
  @ViewChild('selfClosingAlert', {static: false}) selfClosingAlert: NgbAlert | undefined;


  constructor(
    private vehicleService: VehicleService,
    public alertService: AlertService,
    private router: Router ) {
     }

    ngOnInit(): void {
      this.currentVehicle = null;

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

    getVehicleFipe(): void {
      this.vehicleService.getByCodigoFipe(this.codigoFipe, this.year)
        .subscribe(
          vehicle => {
            this.vehicle = vehicle.data;
            console.log('Dados FIPE: ');
            console.log( vehicle);
          },
          error => {
            console.log(error);
          });
    }

    create(): void {
      this.vehicleService.create(this.vehicle)
        .subscribe(
          vehicle => {
            console.log(vehicle);
            this._success.next(vehicle.messages[0]);
          },
          error => {
            console.log(error);
            this._error.next(error.error.messages[0]);
          });
    }



}
