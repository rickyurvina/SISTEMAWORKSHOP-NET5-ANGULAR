import { Injectable } from '@angular/core';
import { SessionStorageService } from 'angular-web-storage';
import { User } from '../../models/user';
import { environment } from 'src/environments/environment';
import { ApplicationState } from '../../models/application-state';
import { RoleEnum } from '../../models/enums/role-enum';

@Injectable({
  providedIn: 'root'
})
export class ApplicationStateService {

  private applicationStateKey = environment.sessionStorageKeys.applicationState;
  private applicationState = new ApplicationState();

  constructor(
    private _sessionStorageService: SessionStorageService,
  ) { }

  setUser(user: User) {
    this.applicationState = this._sessionStorageService.get(this.applicationStateKey) ?? new ApplicationState();
    this.applicationState.User = user;
    this._sessionStorageService.set(this.applicationStateKey, this.applicationState);
  }

  getUser(): User {
    this.applicationState = this._sessionStorageService.get(this.applicationStateKey) ?? new ApplicationState();
    return this.applicationState.User;    
  }

  setIsloggedIn(isloggedIn: boolean) {
    this.applicationState = this._sessionStorageService.get(this.applicationStateKey) ?? new ApplicationState();
    this.applicationState.IsloggedIn = isloggedIn;
    this._sessionStorageService.set(this.applicationStateKey, this.applicationState);
  }

  getIsloggedIn(): boolean {
    this.applicationState = this._sessionStorageService.get(this.applicationStateKey) ?? new ApplicationState();
    return this.applicationState.IsloggedIn;
  }

  isAdmin(): boolean {
    this.applicationState = this._sessionStorageService.get(this.applicationStateKey) ?? new ApplicationState();
    return this.applicationState.User.Roles.findIndex(r => r.NormalizedName == RoleEnum.Administrator) >= 0;
  }

  signOut(){
    this.applicationState = new ApplicationState();
    this._sessionStorageService.set(this.applicationStateKey, this.applicationState);
  }
}
