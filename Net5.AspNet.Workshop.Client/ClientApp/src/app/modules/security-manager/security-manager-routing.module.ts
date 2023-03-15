import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ForgotPasswordComponent } from './sections/forgot-password/forgot-password.component';
import { LoginComponent } from './sections/login/login.component';
import { SignUpComponent } from './sections/sign-up/sign-up.component';
import { SecurityManagerComponent } from './security-manager.component';

const routes: Routes = [
  { path: '', redirectTo: 'login' },
  {
    path: '', component: SecurityManagerComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'forgot-password', component: ForgotPasswordComponent },
      { path: 'sign-up', component: SignUpComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SecurityManagerRoutingModule {
  static components = [
    SecurityManagerComponent,
    LoginComponent,
    ForgotPasswordComponent,
    SignUpComponent
  ];
}
