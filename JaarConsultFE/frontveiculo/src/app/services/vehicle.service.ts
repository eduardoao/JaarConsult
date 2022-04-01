import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const baseURL = 'https://localhost:44318/api/Vehicle';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<any> {
    return this.httpClient.get(baseURL);
  }

  getByPlate(plate: any): Observable<any> {
    return this.httpClient.get(`${baseURL}/${plate}`);
  }

  getByCodigoFipe(codigo: any, year: any): Observable<any> {
    return this.httpClient.get(`${baseURL}/${codigo}/${year}`);
  }

  create(data: any): Observable<any> {
    return this.httpClient.post(baseURL, data);
  }

  update(id: any, data: any): Observable<any> {
    return this.httpClient.put(`${baseURL}/${id}`, data);
  }

  delete(id: any): Observable<any> {
    return this.httpClient.delete(`${baseURL}/${id}`);
  }




}
