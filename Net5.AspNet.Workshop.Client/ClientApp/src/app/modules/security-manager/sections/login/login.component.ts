import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../../../services/security/auth.service';
import { ApplicationStateService } from '../../../../services/settings/application-state.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  form!: FormGroup;
  public loginInvalid!: boolean;
  private formSubmitAttempt!: boolean;
  retUrl: string = "/workshop-manager/home";

  constructor(
    private _formBuilder: FormBuilder,
    private _applicationStateService: ApplicationStateService,
    private _authService: AuthService,
    private _router: Router,
    private _activatedRoute: ActivatedRoute) {
  }

  ngOnInit() {
    this._activatedRoute.queryParamMap
      .subscribe(params => {
        this.retUrl = params.get('retUrl') ?? "";
      });

    this.form = this._formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    if (this._applicationStateService.getIsloggedIn()) {
      this._router.navigate([this.retUrl]);
    }
  }

  onSubmit() {
    this.loginInvalid = false;
    this.formSubmitAttempt = false;
    if (this.form.valid) {

      let username = this.form.get('username')!.value;
      let password = this.form.get('password')!.value;

      this._authService.login(username, password).subscribe(data => {
        if (data) {
          if (this.retUrl != null) {
            this._router.navigate([this.retUrl]);
          } else {
            this._router.navigate(['/workshop-manager/home']);
          }
        } else {
          this.loginInvalid = true;
        }
      });
    } else {
      this.formSubmitAttempt = true;
    }

  }

}
