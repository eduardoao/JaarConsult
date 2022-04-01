
import { Component, OnInit } from '@angular/core';

import { VehicleService } from 'src/app/services/vehicle.service';

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

  constructor(
    private vehicleService: VehicleService ) { }


    ngOnInit(): void {
      this.currentVehicle = null;
    }

    getVehicleFipe(): void {
      this.vehicleService.getByCodigoFipe(this.codigoFipe, this.year)
        .subscribe(
          vehicle => {
            this.vehicle = vehicle.data;
            console.log(vehicle);
          },
          error => {
            console.log(error);
          });
    }

    create(): void {
      this.vehicleService.create(this.vehicle)
        .subscribe(
          vehicle => {
            this.message = vehicle.data.messages;
            console.log(vehicle);
          },
          error => {
            console.log(error);
          });
    }



}
