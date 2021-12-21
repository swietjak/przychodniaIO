import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientComponent } from './client/client.component';
import { LoginComponent } from './login/login.component';
import { ManagerComponent } from './manager/manager.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'client', component: ClientComponent },
  { path: 'manager', component: ManagerComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
