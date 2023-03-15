import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DateAdapter } from '@angular/material/core';
import { MatDialog } from '@angular/material/dialog';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from '../../../../../models/category';
import { FileData } from '../../../../../models/filleData';
import { Instructor } from '../../../../../models/instructor';
import { Workshop } from '../../../../../models/workshop';
import { WorkshopState } from '../../../../../models/workshop-state';
import { WorkshopService } from '../../../../../services/data/workshop/workshop.service';
import { InstructorsDialogComponent } from '../instructors-dialog/instructors-dialog.component';

@Component({
  selector: 'app-workshop-new-or-edit',
  templateUrl: './workshop-new-or-edit.component.html',
  styleUrls: ['./workshop-new-or-edit.component.scss']  
})
export class WorkshopNewOrEditComponent implements OnInit {

  imgCoverSource? :SafeResourceUrl;

  workshopId = 0;
  categories = new Array<Category>();
  workshopStates = new Array<WorkshopState>();
  workshop = new Workshop();

  form!: FormGroup;
  public workshopInvalid!: boolean;
  private formSubmitAttempt!: boolean;
  retUrl: string = "/workshop-manager/home";

  constructor(
    private _instructorsDialog: MatDialog,
    private _activatedRoute: ActivatedRoute,
    private _router: Router,
    private _workshopService: WorkshopService,
    private _adapter: DateAdapter<any>,
    private sanitizer: DomSanitizer,
    private _formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this._adapter.setLocale('es-PE');

    const routeParams = this._activatedRoute.snapshot.paramMap;
    this.workshopId = Number(routeParams.get('workshopId'));

    this.listCategories();
    this.listWorkshopStates();

    this.form = this._formBuilder.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      categoryId: ['', Validators.min(1)],
      instructorId: ['', Validators.required],
      instructorFullName: ['', Validators.required],
      startDate: ['', Validators.required],
      startTime: ['', Validators.required],
      workshopStateId: ['', Validators.min(1)],
      coverFileName: ['', Validators.required],
      agendaFileName: ['', Validators.required],
    });

    if (this.workshopId > 0) {
      this.loadWorkshop(this.workshopId);
    }
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

  uploadFileEvt(imgFile: any, control: string) {    
    let fileData = control == 'cover' ? this.workshop.CoverFileData : this.workshop.AgendaFileData;

    if (imgFile.target.files && imgFile.target.files[0]) {
      let file = imgFile.target.files[0];
      fileData.FileName = '';
      const internalFile = (file as File);
      fileData.FileName = internalFile.name;
      fileData.Type = internalFile.type;
      fileData.Size = internalFile.size;
      fileData.Extension = internalFile.name.split('.').pop()!;

      // HTML5 FileReader API
      let reader = new FileReader();
      reader.onload = (e: any) => {
        if (control == 'cover') {
          this.workshop.CoverFileData.Base64 = e.target.result;
          this.loadImage(this.workshop.CoverFileData.Base64);
        } else {
          this.workshop.AgendaFileData.Base64 = e.target.result;
        }
      };
      reader.readAsDataURL(file);
    } else {
      fileData.FileName = '';
    }

    if (control == 'cover') {
      this.workshop.CoverFileData = fileData;
    } else {
      this.workshop.AgendaFileData = fileData;
    }
  }

  loadImage(base64: string): void {
    let image = new Image();    
    image.src = base64;
    image.onload = rs => {
      this.workshop.CoverFileData.SafeResourceUrl = this.sanitizer.bypassSecurityTrustResourceUrl(`${base64}`) as string;
    };
  }

  onSubmit() {
    this.workshopInvalid = false;
    this.formSubmitAttempt = false;
    if (this.form.valid) {      
      if (this.workshopId > 0) {
        this._workshopService.updateWorkshop(this.workshop).subscribe(workshop => {
          this._router.navigate(['workshop-manager', 'workshops']);
        });
      } else {
        this._workshopService.insertWorkshop(this.workshop).subscribe(workshop => {
          this._router.navigate(['workshop-manager', 'workshops']);
        });
      }
      

    } else {
      this.formSubmitAttempt = true;
    }
  }

  btnInstructorOnClick(e: any) {
    const dialogRef = this._instructorsDialog.open(InstructorsDialogComponent, {
      width: '800px',
      height: '800px',
      panelClass: 'custom-dialog',
      data: ""
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const instructor = result as Instructor;
        this.workshop.InstructorId = instructor.PersonId;
        this.form.controls.instructorFullName.setValue(instructor.FullName);
      }
    });
  }

  btnCancelOnclick(e: any) {
    this._router.navigate(['workshop-manager', 'workshops']);
  }
    
  loadWorkshop(workshopId: number): void {
    this._workshopService.getWorkshop(workshopId).subscribe(workshop => {
      this.workshop = workshop;
      this.loadImage(workshop.CoverFileData.Base64);
    });
  }
}
