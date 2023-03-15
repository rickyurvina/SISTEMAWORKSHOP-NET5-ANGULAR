import { Injectable } from '@angular/core';
import { User } from 'src/app/models/user';
import { of, Observable } from 'rxjs';
import { SecurityService } from '../data/security.service';
import { ApplicationStateService } from '../settings/application-state.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {  
  private userName!: string;

  constructor(
    private _securityService: SecurityService,
    private _applicationSatateService: ApplicationStateService
  ) {    
  }

  login(username: string, password: string): Observable<boolean> {
    return new Observable<boolean>((observer) => {
      let userParam = new User();
      userParam.UserName = username;
      userParam.Password = password;

      this._securityService.validateUser(userParam).subscribe((response) => {        
        if (response) {          
          this._securityService.getUserByUserName(username).subscribe(user => {
            this._applicationSatateService.setIsloggedIn(true);
            this._applicationSatateService.setUser(user);
            observer.next(true);
            observer.complete();
          });
        } else {
          observer.next(false);
          observer.complete();
        }
      });
    });
  }

  forgotPassword(username: string, email: string): Observable<boolean> {
    let userParam = new User();
    userParam.UserName = username;
    userParam.Email = email;
    debugger
    return this._securityService.forgotPassword(userParam);
  }

  signUp(user: User): Observable<boolean> {
    return new Observable<boolean>((observer) => {      
      this._securityService.insertUser(user).subscribe((response) => {
        if (response) {
          observer.next(true);
        } else {
          observer.next(false);
        }
        observer.complete();
      });
    });
  }
  signOut(): Observable<boolean> {
    return new Observable<boolean>((observer) => {
      this._applicationSatateService.signOut();
      this._securityService.logout();
      observer.next(true);
      observer.complete();
    });    
  }
}
