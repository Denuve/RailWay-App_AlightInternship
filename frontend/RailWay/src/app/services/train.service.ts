import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Train } from '../models/train';

@Injectable({
  providedIn: 'root'
})
export class TrainService {


  baseUri: string = 'http://localhost:8080/';
  constructor(private http: HttpClient) { }

  getTrains(){
    return this.http.get<Train[]>(this.baseUri + 'api/Trains');
  }
  
  getTrain(trainId: string){
    return this.http.get<Train>(this.baseUri + `api/Trains/${trainId}`);
  }

  
}
