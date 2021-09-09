import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Car } from '../models/car';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  baseUri: string = 'http://localhost:8080/';
  constructor(private http: HttpClient) { }

  getCars(){
    return this.http.get<Car[]>(this.baseUri + 'api/Cars');
  }

}
