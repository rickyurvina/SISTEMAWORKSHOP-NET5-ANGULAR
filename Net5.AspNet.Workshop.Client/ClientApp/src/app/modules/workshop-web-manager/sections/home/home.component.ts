import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { DateAdapter } from '@angular/material/core';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { Instructor } from '../../../../models/instructor';
import { Workshop } from '../../../../models/workshop';
import { WorkshopService } from '../../../../services/data/workshop/workshop.service';
import { HomeFilterModel } from './home-filter-model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  filteredInstructors?: Observable<Instructor[]>;
  filter = new HomeFilterModel();
  instructorControl = new FormControl();
  instructors = new Array<Instructor>();
  workshops = new Array<Array<Workshop>>();

  constructor(
    private _adapter: DateAdapter<any>,
    private _workshopService: WorkshopService
  ) { }

  ngOnInit(): void {
    this._adapter.setLocale('es-PE');
    this.listInstructors();

    this.filteredInstructors = this.instructorControl.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value))
    );

    this.listWorkshops();
  }


  listInstructors() {
    this._workshopService.listInstructors().subscribe((instructors) => {
      this.instructors = instructors;
    });
  }

  listWorkshops() {
    let filter = this.getFilter();    
    this._workshopService.listWorkshops(filter).subscribe((workshops) => {      
      this.workshops = new Array<Array<Workshop>>();

      let ws = new Array<Workshop>();

      workshops.forEach((workshop, index) => {
        if (index % 3 == 0) {
          if (ws.length > 0) {
            this.workshops.push(ws);
          }
          ws = new Array<Workshop>();
        }
        ws.push(workshop);
      });

      if (ws.length > 0) {
        this.workshops.push(ws);
      }
    });
  }

  getFilter(): HomeFilterModel {
    console.log(this.filter);    
    if (typeof this.filter.Instructor === "string") {
      this.filter.Instructor = new Instructor();
    }
    this.filter.InstructorId = this.filter.Instructor.PersonId;
    return this.filter;
  }

  btnTodayOnClick(e: any) {    
    const today = new Date();
    today.setHours(0, 0, 0, 0);
    this.filter.StartDate = today;
    this.filter.EndDate = today;
  }

  btnWeekOnClick(e: any) {
    const startDate = new Date();
    const endDate = new Date();
    endDate.setDate(startDate.getDate() + 7);

    this.filter.StartDate = startDate;
    this.filter.EndDate = endDate;
  }

  btnMonthOnClick(e: any) {
    const startDate = new Date();
    const endDate = new Date();
    endDate.setDate(startDate.getDate() + 30);

    this.filter.StartDate = startDate;
    this.filter.EndDate = endDate;
  }

  btnSearchOnClick(e: any) {
    this.listWorkshops();
  }

  displayFn(instructor: Instructor): any {
    return instructor ? instructor.FullName : undefined;
  }

  private _filter(value: string): Instructor[] {
    let filterValue = '';

    if (typeof value === "string") {
      filterValue = value.toLowerCase();
    } else {
      let w = value as Instructor;
      filterValue = w.FullName.toLowerCase();
    }

    return this.instructors.filter(instructor => instructor.FullName.toLowerCase().indexOf(filterValue) >= 0);
  }
}
