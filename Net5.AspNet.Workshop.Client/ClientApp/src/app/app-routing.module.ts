import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from './services/security/auth-guard.service';

const appRoutes: Routes = [
  {
    path: 'security-manager',
    loadChildren: () => import('./modules/security-manager/security-manager.module').then(m => m.SecurityManagerModule),
  },  
  {
    path: 'workshop-manager',
    loadChildren: () => import('./modules/workshop-manager/workshop-manager.module').then(m => m.WorkshopManagerModule),
    canActivate: [AuthGuardService]
  },
  {
    path: 'workshop-web-manager',
    loadChildren: () => import('./modules/workshop-web-manager/workshop-web-manager.module').then(m => m.WorkshopWebManagerModule)    
  },
  //{ path: '', pathMatch: 'full', redirectTo: '/workshop-manager/home' },
  //{ path: '**', pathMatch: 'full', redirectTo: '/workshop-manager/home' }
  { path: '', pathMatch: 'full', redirectTo: '/workshop-web-manager/home' },
  { path: '**', pathMatch: 'full', redirectTo: '/workshop-web-manager/home' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes, {
    useHash: true
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {
  static components = [
    
  ];
}
