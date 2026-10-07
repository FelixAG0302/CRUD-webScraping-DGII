import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Company } from '../Models/company.model';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  private url = 'https://localhost:44319/api/company';

  constructor(private http: HttpClient) {

  }

  getById(id: number): Observable<Company> {
    return this.http.get<Company>(`${this.url}/${id}`);
  }
  
  getAll(): Observable<Company[]> {
    return this.http.get<Company[]>(this.url);
  }

  searchRNC(rnc: string): Observable<Company> {
    return this.http.get<Company>(`${this.url}/search/${rnc}`);
  }

  create(company: Company): Observable<Company> {
    return this.http.post<Company>(this.url, company);
  }

  update(id: number, company: Company): Observable<Company> {
    return this.http.put<Company>(`${this.url}/${id}`, company);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.url}/${id}`);
  }
}
