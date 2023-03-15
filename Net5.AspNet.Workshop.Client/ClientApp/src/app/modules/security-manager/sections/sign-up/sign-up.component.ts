import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSelectChange } from '@angular/material/select';
import { ActivatedRoute, Router } from '@angular/router';
import { Department } from '../../../../models/department';
import { District } from '../../../../models/district';
import { Province } from '../../../../models/province';
import { User } from '../../../../models/user';
import { LocationService } from '../../../../services/data/location/location.service';
import { SecurityService } from '../../../../services/data/security.service';
import { AuthService } from '../../../../services/security/auth.service';
import { ApplicationStateService } from '../../../../services/settings/application-state.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {

  form!: FormGroup;
  public signUpInvalid!: boolean;
  private formSubmitAttempt!: boolean;
  
  user = new User();
  departments = new Array<Department>();
  provinces =  new Array<Province>();
  districts=  new Array<District>();

  constructor(
    private _formBuilder: FormBuilder,
    private _applicationStateService:ApplicationStateService,
    private _authService: AuthService,
    private _locationService: LocationService,    
    private _router: Router) {
  }

  ngOnInit() {
    this.form = this._formBuilder.group({      
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      surName: ['', Validators.required],
      identificationNumber: ['', Validators.required],
      username: ['', Validators.required],
      email: ['', Validators.required],
      phone: ['', Validators.required],
      departmentId: ['', Validators.min(1)],
      provinceId: ['', Validators.min(1)],
      districtId: ['', Validators.min(1)]
    });

    this.listDepartments();    
  }

  onSubmit() {
    this.signUpInvalid = false;
    this.formSubmitAttempt = false;
    if (this.form.valid) {
      this._authService.signUp(this.user).subscribe(data => {
        if (data) {
            this._router.navigate(['/security-manager/login']);         
        } else {
          this.signUpInvalid = true;
        }
      });
    } else {
      this.formSubmitAttempt = true;
      console.log(this.form.controls['departmentId'].hasError('required'));
    }
  }

  onChangeSelDepartment(e: MatSelectChange) {
    this.provinces = new Array<Province>();
    this.districts = new Array<District>();

    this.user.Address.ProvinceId = 0;
    this.user.Address.DistrictId = 0;

    this.listProvinces(e.value);
  }

  onChangeSelProvince(e: MatSelectChange) {    
    this.districts = new Array<District>();
    this.user.Address.DistrictId = 0;

    this.listDistricts(e.value);
  }

  listDepartments() {
    this._locationService.listDepartments().subscribe((departments) => {
      this.departments = departments;
    });
  }

  listProvinces(departmentId: number) {
    this._locationService.listProvincesByDepartmentId(departmentId).subscribe((provinces) => {
      this.provinces = provinces;
    });
  }

  listDistricts(provinceId: number) {
    this._locationService.listDistrictsByProvinceId(provinceId).subscribe((districts) => {
      this.districts = districts;
    });
  }

}
