import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { Observable } from 'rxjs';
import { User } from '../../models/user';
import { ApplicationStateService } from '../settings/application-state.service';
import { DummyDataService } from './dummy-data.service';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {

  private UsersUrl = "https://localhost:44368/api/users"; 

  constructor(
    private _httpClient: HttpClient,    
    private _dummyDatService: DummyDataService,
    private _applicationSatateService: ApplicationStateService,
    private _oauthService: OAuthService
  ) {

    this._oauthService.oidc = false;
    this._oauthService.clientId = "Net5.AspNet.Workshop.Client";
    this._oauthService.scope = "openid profile Net5.AspNet.Workshop Net5.AspNet.Workshop.Workshop.Api Net5.AspNet.Workshop.Location.Api Net5.AspNet.Workshop.IdentityProvider.Api";
    this._oauthService.issuer = "https://localhost:44311";
    this._oauthService.responseType = "token";
    this._oauthService.setStorage(sessionStorage);

    let url = 'https://localhost:44311/.well-known/openid-configuration';
    this._oauthService.loadDiscoveryDocument(url).then(() => {      
    });
  }

  validateUser(user: User): Observable<boolean> {    
    return new Observable<boolean>((observer) => {      
      this._oauthService.fetchTokenUsingPasswordFlowAndLoadUserProfile(user.UserName, user.Password).then(() => {
        observer.next(true);
      }).catch(err => {
        observer.next(false);
      }).finally(() => {
        observer.complete();
      });      
    });
  }

  logout(): void {
    this._oauthService.logOut();
    this._oauthService.revokeTokenAndLogout();
  }

  getUserByUserName(userName: string): Observable<User> {    
    return new Observable<User>((observer) => {      
      const path = `/${userName}`;
      const url = `${this.UsersUrl}${path}`;      
      return this._httpClient.get<User>(url).subscribe(response => {
        const user = response;
        this._applicationSatateService.setUser(user!);
        observer.next(user);
        observer.complete();
      });      
    });
  }

  insertUser(user: User): Observable<User> {
    const path = `/`;
    const url = `${this.UsersUrl}${path}`;
    return this._httpClient.post<User>(url, user);
  }

  forgotPassword(user: User): Observable<boolean> {
    const path = `/${user.UserName}/ForgotPassword`;
    const url = `${this.UsersUrl}${path}`;      
    return this._httpClient.post<boolean>(url,user);
  }
}
