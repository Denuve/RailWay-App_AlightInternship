import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TraindetailsComponent } from './traindetails/traindetails.component';

const routes: Routes = [
    {path:'', component:HomeComponent},
    {path:'traindetails/:id', component:TraindetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
