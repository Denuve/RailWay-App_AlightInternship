import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TraindetailsComponent } from './traindetails.component';

describe('TraindetailsComponent', () => {
  let component: TraindetailsComponent;
  let fixture: ComponentFixture<TraindetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TraindetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TraindetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
