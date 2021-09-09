import { Component, OnInit } from '@angular/core';
import { SeatService } from '../services/seat.service';
import { ActivatedRoute } from '@angular/router';
import { TrainService } from '../services/train.service';
import { CarService } from '../services/car.service';

@Component({
  selector: 'app-traindetails',
  templateUrl: './traindetails.component.html',
  styleUrls: ['./traindetails.component.css']
})
export class TraindetailsComponent implements OnInit {

  seats: any = ''; 
  seatsFiltered: any = '';
  seatsConsecutive : number = 1;

  cars: any = '';
  selectedCarType : any = 'FirstClass';
  
  train: any = '';
  trainId : any = '';
  

  constructor(private seatService: SeatService,
              private trainService: TrainService,
              private carService: CarService,
              private route: ActivatedRoute) { 
    this.seatService.getSeats().subscribe(res => {
      this.seats = res;

      this.trainId = this.route.snapshot.params['id'];

      this.trainService.getTrain(this.trainId).subscribe(res => {
        this.train = res;
      });

    });

    this.carService.getCars().subscribe( res => {
      this.cars = res;
    });

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


}
