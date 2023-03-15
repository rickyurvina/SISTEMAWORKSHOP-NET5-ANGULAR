import { SelectionModel } from '@angular/cdk/collections';
import { AfterViewInit, Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Category } from '../../../../../models/category';
import { Instructor } from '../../../../../models/instructor';
import { WorkshopService } from '../../../../../services/data/workshop/workshop.service';
import { InstructorsFilterModel } from './instructors-filter-model';

@Component({
  selector: 'app-instructors-dialog',
  templateUrl: './instructors-dialog.component.html',
  styleUrls: ['./instructors-dialog.component.scss']
})
export class InstructorsDialogComponent implements OnInit, AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  
  instructors = new MatTableDataSource<Instructor>();
  selection = new SelectionModel<Instructor>(false, []);

  categories = new Array<Category>();
  filter = new InstructorsFilterModel();
  
  isLoading = true;
  selectedRowIndex = -1;
  displayedColumns: string[] = [
    'select',
    'Nro',
    'IdentificationNumber',
    'FullName',
    'Category',       
  ];

  constructor(
    public _dialogRef: MatDialogRef<InstructorsDialogComponent>,
    private _workshopService: WorkshopService,
    @Inject(MAT_DIALOG_DATA) public data: string
  ) {
    _dialogRef.disableClose = true;
  }

  ngOnInit(): void {
    this.listCategories();
    this.listInstructors();
  }

  ngAfterViewInit(): void {
    this.instructors.paginator = this.paginator;
  }

  listCategories() {
    this._workshopService.listCategories().subscribe((categories) => {
      this.categories = categories;
    });
  }

  listInstructors() {
    let filter = this.getFilter();    
    this._workshopService.listInstructors(filter).subscribe((instructors) => {
      this.instructors = new MatTableDataSource<Instructor>(instructors);
      this.instructors.paginator = this.paginator;
      this.selection = new SelectionModel<Instructor>(false, []);

      this.selectedRowIndex = -1;
      this.isLoading = false;

      if (this.instructors.paginator) {
        this.instructors.paginator.firstPage();
      }
    },
      error => this.isLoading = false);
  }

  getFilter(): InstructorsFilterModel {
    console.log(this.filter);
    return this.filter;
  }

  btnCloseOnClick(): void {
    this._dialogRef.close();
  }

  btnSearchOnClick(e: any): void {
    this.listInstructors();
  }

  btnAddOnClick(e: any): void {
    this._dialogRef.close(this.instructors.data[this.selectedRowIndex]);
  }

  highlight(instructor: Instructor, index: number) {
    this.selection.toggle(instructor);

    if (this.selectedRowIndex == index) {
      this.selectedRowIndex = -1;
    } else {
      this.selectedRowIndex = index;
    }
  }
}
