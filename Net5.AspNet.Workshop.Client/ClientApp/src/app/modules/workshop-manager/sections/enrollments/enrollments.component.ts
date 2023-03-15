import { Component, OnInit, ViewChild } from '@angular/core';
import { DateAdapter } from '@angular/material/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Enrollment } from '../../../../models/enrollment';
import { EnrollmentState } from '../../../../models/enrollment-state';
import { EnrollmentStateEnum } from '../../../../models/enums/enrollment-state-enum';
import { EnrollmentStateFilter } from '../../../../services/data/workshop/enrollment-state-filter';
import { WorkshopService } from '../../../../services/data/workshop/workshop.service';
import { EnrollmentFilterModel } from './enrollment-filter-model';
import { EnrollmentNewDialogComponent } from './enrollment-new-dialog/enrollment-new-dialog.component';

@Component({
  selector: 'app-enrollments',
  templateUrl: './enrollments.component.html',
  styleUrls: ['./enrollments.component.scss']
})
export class EnrollmentsComponent implements OnInit {

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  enrollments = new MatTableDataSource<Enrollment>();  
  enrollmentStates = new Array<EnrollmentState>();
  EnrollmentStateEnum = EnrollmentStateEnum;

  filter = new EnrollmentFilterModel();

  isLoading = true;

  displayedColumns: string[] = [
    'Id',
    'Enrolled',
    'Workshop',
    'EnrollmentDate',    
    'State',
    'Action'
  ];

  constructor(
    private _workshopService: WorkshopService,
    private _router: Router,
    private _enrolleesDialog: MatDialog,
    private _adapter: DateAdapter<any>,
  ) { }

  ngOnInit(): void {
    this._adapter.setLocale('es-PE');

    this.listEnrollmentStates();
    this.listEnrollments();
  }

  ngAfterViewInit(): void {
    this.enrollments.paginator = this.paginator;
  }

  btnSearchOnClick(e: any) {
    this.listEnrollments();
  }

  btnClearOnClick(e: any) {
    this.filter = new EnrollmentFilterModel();
  }

  btnEnrollOnClick(e: any): void {
    const dialogRef = this._enrolleesDialog.open(EnrollmentNewDialogComponent, {
      width: '800px',
      height: '800px',
      panelClass: 'custom-dialog',
      data: ""
    });

    dialogRef.afterClosed().subscribe(result => {      
      if (result) {
        const enrollmentsResult = result as Array<Enrollment>;
        const enrollmentIds = enrollmentsResult.map(enrollment => enrollment.EnrollmentId);
        this._workshopService.changeEnrollmentStates(enrollmentIds, EnrollmentStateEnum.Attend).subscribe((enrollments) => {
          this.listEnrollments();
        });
      }
    });
  }

  btnSwitchStateOnClick(enrollment: Enrollment): void {
    this.switchEnrollmentState(enrollment);
  }
  
  listEnrollmentStates() {
    const filter = new EnrollmentStateFilter();
    filter.EnrollmentStatesIds = [EnrollmentStateEnum.Attend, EnrollmentStateEnum.Canceled];
    this._workshopService.listEnrollmentStates(filter).subscribe((enrollmentStates) => {
      this.enrollmentStates = enrollmentStates;
    });
  }

  switchEnrollmentState(enrollment: Enrollment) {    
    this._workshopService.switchEnrollmentState(enrollment).subscribe((enrollment) => {      
      this.listEnrollments();
    });
  }

  listEnrollments() {
    let filter = this.getFilter();
    this._workshopService.listEnrollmentsAttendOrCanceled(filter).subscribe((enrollments) => {
      this.enrollments = new MatTableDataSource<Enrollment>(enrollments);
      this.enrollments.paginator = this.paginator;
      this.isLoading = false;

      if (this.enrollments.paginator) {
        this.enrollments.paginator.firstPage();
      }
    },
      error => this.isLoading = false);
  }

  applyFilter(event: Event) {
    this.listEnrollments();
  }

  getFilter(): EnrollmentFilterModel {
    console.log(this.filter);    
    return this.filter;
  }
}
