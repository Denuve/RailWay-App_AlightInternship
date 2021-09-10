import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Seat } from '../models/seat';

@Injectable({
  providedIn: 'root'
})
export class SeatService {

  baseUri: string = 'http://localhost:8080/';
  constructor(private http: HttpClient) { }

  getSeats(){
    return this.http.get<Seat[]>(this.baseUri + 'api/Seats');
  }

  getSeat(seatId: string){
    return this.http.get<Seat>(this.baseUri + `api/Seats/${seatId}`);
  }

  putSeat(seatId: string, seat: Seat){
    return this.http.put<any>(this.baseUri + `api/Seats/${seatId}`, seat);
  }

}
