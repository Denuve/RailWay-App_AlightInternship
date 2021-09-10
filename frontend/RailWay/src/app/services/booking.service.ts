import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { BookSeats } from '../models/bookseats';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  baseUri: string = 'http://localhost:8080/';
  constructor(private http: HttpClient) { }

  getBookings(){
    return this.http.get<BookSeats[]>(this.baseUri + 'api/BookSeats');
  }

  postBooking(bookseats: BookSeats){
    return this.http.post<BookSeats>(this.baseUri +'api/BookSeats', bookseats );
  }

}
