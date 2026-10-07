import { Component, OnInit } from '@angular/core';
import { Company } from '../../Models/company.model';
import { CompanyService } from '../../Services/company.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  company: Company;
  errorMessage: string = '';

  constructor(
    private route: ActivatedRoute,
    private companyService: CompanyService
  ) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.getCompany(id);
  }

  getCompany(id: number): void {
      this.companyService.getById(id).subscribe(
        response => {
          this.company = response;
        },
        error => {
          this.errorMessage = 'No se encontró la compañía.';
          console.error(error);
        }
    );
  }
}
