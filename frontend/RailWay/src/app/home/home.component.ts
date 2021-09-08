import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { TrainService } from '../services/train.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  trains: any;
  trainsByDate: any;
  constructor(trainService: TrainService) { 
    trainService.getTrains().subscribe( res => {
      this.trains = res;
    });
  }

  ngOnInit(): void {
  }

  submit(form:NgForm){
    this.trainsByDate = this.trains.filter((element: { dayOfWeek: any; }) =>{
        return (element.dayOfWeek.slice(0, 10) == form.value.trainsdata);
    });
  }
}
