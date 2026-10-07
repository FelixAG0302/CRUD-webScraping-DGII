import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CompanyService } from '../../Services/company.service';
import { Company } from '../../Models/company.model';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-create-company',
  templateUrl: './create-company.component.html',
  styleUrls: ['./create-company.component.css']
})
export class CreateCompanyComponent implements OnInit {

  companyForm = new FormGroup({
    rnc: new FormControl('', Validators.required),
    name: new FormControl('', Validators.required),
    commercialName: new FormControl('', Validators.required),
    category: new FormControl(''),
    paymentScheme: new FormControl('', Validators.required),
    state: new FormControl('', Validators.required),
    economicActivity: new FormControl('', Validators.required),
    gubernamentalBranch: new FormControl('', Validators.required)
  });
  
  constructor(
    private companyService: CompanyService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  create(): void {
    if (this.companyForm.invalid) {
      this.companyForm.markAllAsTouched();
      return;
    }
    const company = this.companyForm.value as Company;

    this.companyService.create(company).subscribe(
      response => {
        Swal.fire('Success', 'La compania fue creada exitosamente', 'success')
        this.router.navigate(['/company']);
      },
      error => {
        console.error(error);
      }
    )
  };

  searchRNC(): void {
    const rncDgii = this.companyForm.get('rnc');

    if(!rncDgii) {
      return;
    }

    if (rncDgii.invalid){
      rncDgii.markAsTouched();
      return;
    }

    this.companyService.searchRNC(rncDgii.value).subscribe(
      response => {
        this.companyForm.patchValue(response);
      },
      error => {
        console.log(error);
      }
    )
  };

  clearForm(): void{
    this.companyForm.reset();
  }

}
