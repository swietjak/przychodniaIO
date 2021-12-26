import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewVisitComponent } from './new-visit/new-visit.component';
import { LoginComponent } from './login/login.component';
import { VisitsComponent } from './visits/visits.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'new-visit', component: NewVisitComponent },
  { path: 'visits', component: VisitsComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
