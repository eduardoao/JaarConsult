import { Component, OnInit } from '@angular/core';

import { VehicleService } from 'src/app/services/vehicle.service';

@Component({
  selector: 'app-vehicle-details',
  templateUrl: './vehicle-details.component.html',
  styleUrls: ['./vehicle-details.component.css']
})
export class VehicleDetailsComponent implements OnInit {


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
    private vehicleService: VehicleService ) { }

  ngOnInit(): void {
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
        this.vehicle = vehicle.data;
        console.log(vehicle);
      },
      error => {
        console.log(error);
      });
  }


}
