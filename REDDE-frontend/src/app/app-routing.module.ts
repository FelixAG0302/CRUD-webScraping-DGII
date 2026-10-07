import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CompanyComponent } from './Components/company.component';
import { CreateCompanyComponent } from './Components/create-company/create-company.component';
import { EditCompanyComponent } from './Components/edit-company/edit-company.component';
import { DetailsComponent } from './Components/details/details.component';


const routes: Routes = [
  {
    path: 'company', component: CompanyComponent},
  {
    path: 'company/create', component: CreateCompanyComponent},
  {
    path: 'company/edit/:id', component: EditCompanyComponent
  },
  {
    path: 'company/details/:id', component: DetailsComponent
  },
  {
    path: '',
    redirectTo: '/company',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
