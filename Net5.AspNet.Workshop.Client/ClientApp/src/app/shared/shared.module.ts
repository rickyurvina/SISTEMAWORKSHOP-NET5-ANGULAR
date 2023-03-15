import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MomentModule } from 'ngx-moment';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { MatTableExporterModule } from 'mat-table-exporter';

const sharedModules = [
  MaterialModule,
  FormsModule,
  ReactiveFormsModule,
  FlexLayoutModule,
  MatTableExporterModule,
  NgxMaterialTimepickerModule,
  HttpClientModule,
  MomentModule,  
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ...sharedModules    
  ],
  exports: [
    MaterialModule,
    ...sharedModules
  ]  
})
export class SharedModule { }
