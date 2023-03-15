import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../../../services/security/auth.service';
import { ApplicationStateService } from '../../../../services/settings/application-state.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {

  form!: FormGroup;
  public forgotInvalid!: boolean;
  private formSubmitAttempt!: boolean;

  constructor(
    private _formBuilder: FormBuilder,
    private _applicationStateService:ApplicationStateService,
    private _authService: AuthService,
    private _router: Router
    ) {
  }

  ngOnInit() {    
    this.form = this._formBuilder.group({
      username: ['', Validators.required],
      email: ['', Validators.required]
    });
  }

  onSubmit() {
    this.forgotInvalid = true;
    this.formSubmitAttempt = false;
    if (this.form.valid) {

      let username = this.form.get('username')!.value;
      let email = this.form.get('email')!.value;

      this._authService.forgotPassword(username, email).subscribe(data => {
        this.forgotInvalid = !data;
        if (!this.forgotInvalid) {
          this._router.navigate(['/security-manager/login']);
        }
      });
    } else {
      this.formSubmitAttempt = true;
    }

  }

}
