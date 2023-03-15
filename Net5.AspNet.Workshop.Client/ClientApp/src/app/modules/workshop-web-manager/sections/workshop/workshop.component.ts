import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Enrollment } from '../../../../models/enrollment';
import { Workshop } from '../../../../models/workshop';
import { WorkshopService } from '../../../../services/data/workshop/workshop.service';
import { ApplicationStateService } from '../../../../services/settings/application-state.service';
import { WorkshopEnrollmentFilterModel } from './workshop-enrollment-filter-model';

@Component({
  selector: 'app-workshop',
  templateUrl: './workshop.component.html',
  styleUrls: ['./workshop.component.scss']
})
export class WorkshopComponent implements OnInit {

  workshopId = 0;
  workshop = new Workshop();
  enrollmentsByEnrollee = new Array<Enrollment>();
  applicationStateService: ApplicationStateService;

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _workshopService: WorkshopService,
    private _sanitizer: DomSanitizer,
    private _applicationStateService: ApplicationStateService
  ) {
    this.applicationStateService = this._applicationStateService;    
  }

  ngOnInit(): void {
    const routeParams = this._activatedRoute.snapshot.paramMap;
    this.workshopId = Number(routeParams.get('workshopId'));

    if (this.workshopId > 0) {
      this.loadWorkshop(this.workshopId);      
    }
  }

  btnDownloadOnClick(e: any) {    
    const url = `https://localhost:44322/api/FileDatum/${this.workshop.AgendaFileDataId}/GetFile`;    
    window.open(url);
  }

  btnEnrollmentMeUpOnClick(e: any) {
    this.insertEnrollomnet();
  }

  loadImage(base64: string): void {
    let image = new Image();
    image.src = base64;
    image.onload = rs => {
      this.workshop.CoverFileData.SafeResourceUrl = this._sanitizer.bypassSecurityTrustResourceUrl(`${base64}`) as string;
    };
  }

  loadWorkshop(workshopId: number): void {
    this._workshopService.getWorkshop(workshopId).subscribe(workshop => {
      this.workshop = workshop;
      this.loadImage(workshop.CoverFileData.Base64);
      this.getEnrollments();
    });
  }

  insertEnrollomnet(): void {
    this._workshopService.insertEnrollomnet(this.workshop.WorkshopId).subscribe(entollment => {
      this.getEnrollments();
    });
  }

  getEnrollments(): void {
    const filter = new WorkshopEnrollmentFilterModel();
    filter.WorkshopId = this.workshop.WorkshopId
    filter.EnrolledId = this._applicationStateService.getUser().PersonId;
    if (filter.EnrolledId > 0) {
      this._workshopService.listEnrollments(filter).subscribe(enrollments => {
        this.enrollmentsByEnrollee = enrollments;
      })
    }
  }
}
