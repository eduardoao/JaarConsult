import { Component, OnInit } from '@angular/core';

import { VehicleService } from 'src/app/services/vehicle.service';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {

  data: any;

  constructor(
    private vehicleService: VehicleService ) { }

  ngOnInit(): void {
    this.getAllVehicles();
  }

  getAllVehicles(): void {
    this.vehicleService.getAll()
      .subscribe(
        vehicle => {
          this.data = vehicle.data;
          console.log(this.data);
        },
        error => {
          console.log(error);
        });
  }



}
