import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Academy } from '../shared/models/academy';

@Injectable({
  providedIn: 'root'
})
export class AcademyService {

  public baseApiUrl: string = `${environment.apiUrl}Employee/academy/`;

  constructor(private http: HttpClient) { }

  public getAllAcademies(): Observable<Academy[]> {
      return this.http.get<Academy[]>(`${this.baseApiUrl}get-all`);
  }
  public create(academy: Academy): Observable<Academy> {
      return this.http.post<Academy>(`${this.baseApiUrl}create`, academy);
  }
  public delete(academyId: number): Observable<any> {
      return this.http.delete<any>(`${this.baseApiUrl}delete/${academyId}`);
  }
  public update(academy: Academy): Observable<object> {
      return this.http.put(`${this.baseApiUrl}update`, academy);
  }
  public findById(academyId: number): Observable<Academy> {
      return this.http.get<Academy>(`${this.baseApiUrl}find-by-id/${academyId}`);
  }
}
