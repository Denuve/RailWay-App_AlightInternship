import { Component, OnInit } from '@angular/core';
import { SeatService } from '../services/seat.service';
import { ActivatedRoute } from '@angular/router';
import { TrainService } from '../services/train.service';

@Component({
  selector: 'app-traindetails',
  templateUrl: './traindetails.component.html',
  styleUrls: ['./traindetails.component.css']
})
export class TraindetailsComponent implements OnInit {

  seats: any = '';
  train: any = '';
  trainId : any = '';

  constructor(private seatService: SeatService,
              private trainService: TrainService,
              private route: ActivatedRoute) { 
    this.seatService.getSeats().subscribe(res => {
      this.seats = res;

      this.trainId = this.route.snapshot.params['id'];

      this.trainService.getTrain(this.trainId).subscribe(res => {
        this.train = res;
      });

    });

    
  }

  ngOnInit(): void {
  }

  firstClass(){

  }

  secondClass(){

  }

  sleeping(){

  }

}
