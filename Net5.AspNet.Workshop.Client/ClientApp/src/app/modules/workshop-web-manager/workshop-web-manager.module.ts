import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkshopWebManagerRoutingModule } from './workshop-web-manager-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { WorkshopCardComponent } from './sections/home/workshop-card/workshop-card.component';

@NgModule({
  declarations: [
    WorkshopWebManagerRoutingModule.components
  ],
  imports: [
    CommonModule,
    SharedModule,
    WorkshopWebManagerRoutingModule
  ]
})
export class WorkshopWebManagerModule { }
