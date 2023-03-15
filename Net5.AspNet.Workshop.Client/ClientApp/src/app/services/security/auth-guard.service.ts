import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { ApplicationStateService } from '../settings/application-state.service';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate{

  constructor(private _router: Router, private _applicationStateService: ApplicationStateService) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree {    
    if (!this._applicationStateService.getIsloggedIn() || !this._applicationStateService.isAdmin()) {
      this._router.navigate(["security-manager"], { queryParams: { retUrl: state.url } });
      return false;
    }
    return true;
  }
}
