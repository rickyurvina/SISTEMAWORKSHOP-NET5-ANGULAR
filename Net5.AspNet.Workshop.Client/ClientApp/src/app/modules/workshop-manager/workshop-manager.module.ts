import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkshopManagerRoutingModule } from './workshop-manager-routing.module';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  declarations: [
    WorkshopManagerRoutingModule.components
  ],
  imports: [
    CommonModule,
    SharedModule,
    WorkshopManagerRoutingModule
  ]
})
export class WorkshopManagerModule { }
