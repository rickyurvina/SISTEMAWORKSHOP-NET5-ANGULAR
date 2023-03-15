import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeaderComponent } from './navigation/header/header.component';
import { SidenavListComponent } from './navigation/sidenav-list/sidenav-list.component';
import { EnrollmentNewDialogComponent } from './sections/enrollments/enrollment-new-dialog/enrollment-new-dialog.component';
import { EnrollmentsComponent } from './sections/enrollments/enrollments.component';
import { HomeComponent } from './sections/home/home.component';
import { ReportsComponent } from './sections/reports/reports.component';
import { InstructorsDialogComponent } from './sections/workshops/instructors-dialog/instructors-dialog.component';
import { WorkshopDeleteDialogComponent } from './sections/workshops/workshop-delete-dialog/workshop-delete-dialog.component';
import { WorkshopNewOrEditComponent } from './sections/workshops/workshop-new-or-edit/workshop-new-or-edit.component';
import { WorkshopsComponent } from './sections/workshops/workshops.component';
import { WorkshopManagerComponent } from './workshop-manager.component';

const routes: Routes = [
  { path: '', redirectTo: 'home' },
  {
    path: '', component: WorkshopManagerComponent,    
    children: [
      { path: 'home', component: HomeComponent },
      { path: 'workshops', component: WorkshopsComponent },
      { path: 'workshops/:workshopId', component: WorkshopNewOrEditComponent },
      { path: 'enrollments', component: EnrollmentsComponent },
      { path: 'reports', component: ReportsComponent }
    ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkshopManagerRoutingModule {
  static components = [
    WorkshopManagerComponent,
    HeaderComponent,
    SidenavListComponent,
    HomeComponent,
    WorkshopsComponent,
    EnrollmentsComponent,
    ReportsComponent,
    WorkshopNewOrEditComponent,
    InstructorsDialogComponent,
    WorkshopDeleteDialogComponent,
    EnrollmentNewDialogComponent
  ];
}
