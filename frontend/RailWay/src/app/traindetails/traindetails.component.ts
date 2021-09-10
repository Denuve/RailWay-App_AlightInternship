import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';

import { TrainService } from '../services/train.service';
import { CarService } from '../services/car.service';
import { BookingService } from '../services/booking.service';
import { SeatService } from '../services/seat.service';

import { BookSeats } from '../models/bookseats';
import { Seat } from '../models/seat';
import { Guid } from "guid-typescript";


@Component({
  selector: 'app-traindetails',
  templateUrl: './traindetails.component.html',
  styleUrls: ['./traindetails.component.css']
})
export class TraindetailsComponent implements OnInit {

  seats: any = ''; 
  seat: Seat = {
    id: '',
    carId: '',
    seatnumber: 0,
    occupied: false

  };
  seatsFiltered: any = '';
  seatsConsecutive : number = 1;
  seatsForReservation: string = '';

  cars: any = '';
  selectedCarType : any = 'FirstClass';
  
  train: any = '';
  trainId : any = '';

  guid : Guid = Guid.create();

  booking: BookSeats = {
    id: this.uuidv4(),
    name: '',
    email: '',
    date: Date.now as unknown as (Date),
    cnp: 1,
    bookingcode: this.uuidv4()
  }
  
  

  constructor(private seatService: SeatService,
              private trainService: TrainService,
              private carService: CarService,
              private bookingService: BookingService,
              private route: ActivatedRoute) { 
    this.seatService.getSeats().subscribe(res => {
      this.seats = res;

      this.trainId = this.route.snapshot.params['id'];

      this.trainService.getTrain(this.trainId).subscribe(res => {
        this.train = res;
        this.booking.date = this.train.dayOfWeek;
      });

    });

    this.carService.getCars().subscribe( res => {
      this.cars = res;
    });

    this.booking.date = this.train.dayofweek;
  }

  ngOnInit(): void {
  }

  firstClass(){
    this.selectedCarType = 'FirstClass';
  }

  secondClass(){
    this.selectedCarType = 'SecondClass';
  }

  sleeping(){
    this.selectedCarType = 'Sleeping';
  }


  selectSeat(seatId: any){
    this.seatsForReservation = this.seatsForReservation+ '~' + seatId;
  }

   uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
      var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }


  login(form:NgForm){

    if(form.invalid){
      return;
    }

    this.booking.name = form.value.name;
    this.booking.email = form.value.email;
    this.booking.cnp = form.value.cnp;

    let seatsToPut = this.seatsForReservation.split('~');
    
    seatsToPut.forEach(element => {
      this.seatService.getSeat(element).subscribe( res => {
        this.seat = res;
        this.seat.occupied = true;
        console.log(this.booking.id);
        this.seat.bookingCode = this.booking.id;
        this.seatService.putSeat(this.seat.id, this.seat).subscribe( res => {
        } );
      });
    });

    this.bookingService.postBooking(this.booking).subscribe( res => {
      console.log("Booking posted!");
    });
    
    
  }

}
