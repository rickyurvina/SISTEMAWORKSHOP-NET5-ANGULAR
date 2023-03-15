import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeaderComponent } from './navigation/header/header.component';
import { HomeComponent } from './sections/home/home.component';
import { WorkshopCardComponent } from './sections/home/workshop-card/workshop-card.component';
import { WorkshopComponent } from './sections/workshop/workshop.component';
import { WorkshopWebManagerComponent } from './workshop-web-manager.component';


const routes: Routes = [
  { path: '', redirectTo: 'home' },
  {
    path: '', component: WorkshopWebManagerComponent,
    children: [
      { path: 'home', component: HomeComponent },
      { path: 'workshops/:workshopId', component: WorkshopComponent }
    ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkshopWebManagerRoutingModule {
  static components = [
    WorkshopWebManagerComponent,
    HeaderComponent,
    HomeComponent,
    WorkshopCardComponent,
    WorkshopComponent
  ];
}
