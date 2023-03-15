import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Category } from '../../../../models/category';
import { Workshop } from '../../../../models/workshop';
import { WorkshopState } from '../../../../models/workshop-state';
import { WorkshopService } from '../../../../services/data/workshop/workshop.service';
import { WorkshopDeleteDialogComponent } from './workshop-delete-dialog/workshop-delete-dialog.component';
import { WorkshopsFilterModel } from './workshops-filter-model';

@Component({
  selector: 'app-workshops',
  templateUrl: './workshops.component.html',
  styleUrls: ['./workshops.component.scss']
})
export class WorkshopsComponent implements OnInit, AfterViewInit  {

  @ViewChild(MatPaginator) paginator!: MatPaginator;  

  workshops = new MatTableDataSource<Workshop>();
  categories = new Array<Category>();
  workshopStates = new Array<WorkshopState>();

  filter = new WorkshopsFilterModel();

  isLoading = true;

  displayedColumns: string[] = [
    'Id',
    'Title',
    'Category',
    'Instructor',
    'StartDate',
    'State',
    'Quantity',
    'Action'
  ];

  constructor(
    private _worshopDeleteDialog: MatDialog,
    private _workshopService: WorkshopService,
    private _router: Router,
  ) { }

  ngOnInit(): void {
    this.listCategories();
    this.listWorkshopStates();
    this.listWorkshops();
  }

  ngAfterViewInit(): void {    
    this.workshops.paginator = this.paginator;
  }

  btnSearchOnClick(e: any) {
    this.listWorkshops();    
  }

  btnClearOnClick(e: any) {
    this.filter = new WorkshopsFilterModel();
  }

  btnNewOnClick(e: any): void {
    this._router.navigate(['workshop-manager', 'workshops', '0']);
  }

  btnEditOnClick(workshop: Workshop): void {
    this._router.navigate(['workshop-manager', 'workshops', workshop.WorkshopId]);
  }

  btnDeleteOnClick(workshop: Workshop): void {
    const dialogRef = this._worshopDeleteDialog.open(WorkshopDeleteDialogComponent, {
      width: '400px',      
      panelClass: 'custom-dialog',
      data: workshop
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const workshopId = result as number;
        this._workshopService.deleteWorkshop(workshopId).subscribe(() => {
          this.listWorkshops();
        });
      }
    });
  }

  listCategories() {
    this._workshopService.listCategories().subscribe((categories) => {
      this.categories = categories;
    });
  }

  listWorkshopStates() {
    this._workshopService.listWorkshopStates().subscribe((workshopStates) => {
      this.workshopStates = workshopStates;
    });
  }

  listWorkshops() {    
    let filter = this.getFilter();
    this._workshopService.listWorkshops(filter).subscribe((workshops) => {
      this.workshops = new MatTableDataSource<Workshop>(workshops);      
      this.workshops.paginator = this.paginator;
      this.isLoading = false;

      if (this.workshops.paginator) {
        this.workshops.paginator.firstPage();
      }
    },      
    error => this.isLoading = false);
  }

  applyFilter(event: Event) {    
    this.listWorkshops();
  }

  getFilter(): WorkshopsFilterModel {
    console.log(this.filter);
    return this.filter;
  }
}
