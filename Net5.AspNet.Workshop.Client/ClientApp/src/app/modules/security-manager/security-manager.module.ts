import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SecurityManagerRoutingModule } from './security-manager-routing.module';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  declarations: [
    SecurityManagerRoutingModule.components
  ],
  imports: [
    CommonModule,
    SharedModule,
    SecurityManagerRoutingModule    
  ]
})
export class SecurityManagerModule { }
