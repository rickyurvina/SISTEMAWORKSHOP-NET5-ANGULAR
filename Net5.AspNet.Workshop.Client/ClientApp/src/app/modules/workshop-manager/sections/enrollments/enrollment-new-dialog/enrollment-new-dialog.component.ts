import { SelectionModel } from '@angular/cdk/collections';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { map, startWith, } from 'rxjs/operators';
import { Enrollment } from '../../../../../models/enrollment';
import { Workshop } from '../../../../../models/workshop';
import { WorkshopService } from '../../../../../services/data/workshop/workshop.service';
import { EnrollmentEnrolledFilterModel } from './enrollment-enrolled-filter-model';

@Component({
  selector: 'app-enrollment-new-dialog',
  templateUrl: './enrollment-new-dialog.component.html',
  styleUrls: ['./enrollment-new-dialog.component.scss']
})
export class EnrollmentNewDialogComponent implements OnInit, AfterViewInit {

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  enrollments = new MatTableDataSource<Enrollment>();
  selection = new SelectionModel<Enrollment>(true, []);

  workshops = new Array<Workshop>();
  filter = new EnrollmentEnrolledFilterModel();
  filteredWorkshops?: Observable<Workshop[]>;
  workshopControl = new FormControl();

  isLoading = true;  
  displayedColumns: string[] = [
    'select',
    'Nro',
    'IdentificationNumber',
    'FullName',
    'EnrollmentDate',
  ];

  constructor(
    public _dialogRef: MatDialogRef<EnrollmentNewDialogComponent>,
    private _workshopService: WorkshopService
  ) {
    _dialogRef.disableClose = true;
  }

  ngOnInit(): void {
    this.listWorkshops();
    this.isLoading = false;

    this.filteredWorkshops = this.workshopControl.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value))
    );
  }

  ngAfterViewInit(): void {
    this.enrollments.paginator = this.paginator;
  }

  listWorkshops() {
    this._workshopService.listWorkshops().subscribe((workshops) => {
      this.workshops = workshops;
    });
  }

  listEnrollments() {
    let filter = this.getFilter();
    this._workshopService.listEnrollmentsEnrolled(filter).subscribe((enrollments) => {
      this.enrollments = new MatTableDataSource<Enrollment>(enrollments);
      this.enrollments.paginator = this.paginator;
      this.selection = new SelectionModel<Enrollment>(true, []);
            
      this.isLoading = false;

      if (this.enrollments.paginator) {
        this.enrollments.paginator.firstPage();
      }
    },
      error => this.isLoading = false);
  }

  getFilter(): EnrollmentEnrolledFilterModel {
    console.log(this.filter);
    if (typeof this.filter.Workshop === "string") {
      this.filter.Workshop = new Workshop();
    }

    this.filter.WorkshopId = this.filter.Workshop.WorkshopId;
    return this.filter;
  }

  btnCloseOnClick(): void {
    this._dialogRef.close();
  }

  btnSearchOnClick(e: any): void {
    this.listEnrollments();
  }

  btnSaveOnClick(e: any): void {    
    this._dialogRef.close(this.selection.selected);
  }

  masterToggle() {    
    if (this.isAllSelected()) {      
      this.selection.clear()
    } else {
      this.enrollments.data.forEach(enrollment => {        
        this.selection.select(enrollment)
      });
    }
  }

  isAllSelected(): boolean {
    const numSelected = this.selection.selected.length;
    const numRows = this.enrollments.data.length;
    return numSelected === numRows;
  }

  select(enrollment: Enrollment) {    
    this.selection.toggle(enrollment);
  }

  displayFn(workshop: Workshop):any {
    return workshop ? workshop.Title : undefined;
  }

  private _filter(value: string): Workshop[] {    
    let filterValue = '';

    if (typeof value === "string") {
      filterValue = value.toLowerCase();
      this.enrollments = new MatTableDataSource<Enrollment>();
      this.enrollments.paginator = this.paginator;
      this.selection = new SelectionModel<Enrollment>(true, []);
    } else {
      let w = value as Workshop;
      filterValue = w.Title.toLowerCase();
    }

    return this.workshops.filter(workshop => workshop.Title.toLowerCase().indexOf(filterValue) >= 0);
  }

  enableBtnSave(): boolean {    
    return this.filter.Workshop.WorkshopId > 0 && this.selection.selected.length > 0;
  }
}
