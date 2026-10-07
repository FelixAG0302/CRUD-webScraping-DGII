import { Component, OnInit } from '@angular/core';
import { Company } from '../Models/company.model';
import { CompanyService } from '../Services/company.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent implements OnInit {

  companies: Company[] = [];

  constructor(private companyService: CompanyService) { }

  ngOnInit(): void {
    this.getAll();
  }

  getAll(): void {
    this.companyService.getAll().subscribe(
      response => {
        this.companies = response;
      },
      error => {
        console.error(error);
      }
    );
  }

  delete(id: number): void {
    Swal.fire({
      'title': 'Esta seguro que quiere borrar la siguiente compania?',
      'text': 'La compania sera eliminada de la lista',
      'icon': 'warning',
      'showCancelButton': true,
      'confirmButtonText': 'Eliminar',
      'cancelButtonText': 'Cancelar'
    }).then((result) => {
      if (result.value) {
        this.companyService.delete(id).subscribe(
          () => {
            this.getAll();
          },
          (error) => {
            console.error(error);

            Swal.fire('Error', 'No se pudo eliminar la compania', 'error');
          }
        );
      }
    });
  }

}
