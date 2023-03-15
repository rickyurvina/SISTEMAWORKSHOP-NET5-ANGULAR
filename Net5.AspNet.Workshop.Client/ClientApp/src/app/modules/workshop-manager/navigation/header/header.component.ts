import { DOCUMENT } from '@angular/common';
import { Component, EventEmitter, Inject, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../../../../models/user';
import { AuthService } from '../../../../services/security/auth.service';
import { ApplicationStateService } from '../../../../services/settings/application-state.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  @Input() public fixedInViewport!: boolean;
  @Output() public sidenavToggle = new EventEmitter();

  user: User;

  constructor(
    private _applicationStateService: ApplicationStateService,
    private _authService: AuthService,
    private _router: Router,
    @Inject(DOCUMENT) private _document: Document
  ) {
    this.user = _applicationStateService.getUser();
  }

  ngOnInit(): void {
  }

  public onToggleSidenav = () => {
    if (!this.fixedInViewport) {
      this.sidenavToggle.emit();
    }
  }

  public signOut(e: any) {
    this._authService.signOut().subscribe(() => {      
      this._router.navigate(['workshop-web-manager', 'home']).then(() => {
        this._document.defaultView!.location.reload();
      });      
    });
  }

}
