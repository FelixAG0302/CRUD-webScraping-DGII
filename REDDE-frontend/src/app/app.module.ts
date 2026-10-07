import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CompanyComponent } from './Components/company.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavbarComponent } from './Components/Navbar/navbar/navbar.component';
import { CreateCompanyComponent } from './Components/create-company/create-company.component';
import {ReactiveFormsModule} from "@angular/forms";
import { EditCompanyComponent } from './Components/edit-company/edit-company.component';
import { DetailsComponent } from './Components/details/details.component';

@NgModule({
  declarations: [
    AppComponent,
    CompanyComponent,
    NavbarComponent,
    CreateCompanyComponent,
    EditCompanyComponent,
    DetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
