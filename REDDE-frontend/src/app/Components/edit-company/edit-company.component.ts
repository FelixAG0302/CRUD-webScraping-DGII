import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CompanyService } from '../../Services/company.service';
import { Company } from '../../Models/company.model';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-edit-company',
  templateUrl: './edit-company.component.html',
  styleUrls: ['./edit-company.component.css']
})
export class EditCompanyComponent implements OnInit {

  companyId: number = 0;

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
    private route: ActivatedRoute,
    private companyService: CompanyService,
    private router: Router
  ) { }

  ngOnInit(): void {

    const idParam = this.route.snapshot.paramMap.get('id');
  
    if (idParam) {
      this.companyId = Number(idParam);
      this.loadCompany();
    } else {
      console.error("No se encontró el ID de la compañía en la ruta.");
    }
  }

  loadCompany(): void{
    this.companyService.getById(this.companyId).subscribe(
      response => {
        this.companyForm.patchValue(response);
      },
      error => {
        console.error(error);
      }
    )
  }
  
  update(): void {
      if (this.companyForm.invalid) {
        this.companyForm.markAllAsTouched();
        return;
      }
      const company = this.companyForm.value as Company;
      company.id = this.companyId
  
      this.companyService.update(this.companyId, company).subscribe(
        response => {
          Swal.fire('Success', 'La compania fue editada exitosamente', 'success')
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
