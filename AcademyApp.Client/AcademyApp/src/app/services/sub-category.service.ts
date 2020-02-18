import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SubCategory } from '../shared/models/sub-category';

@Injectable({
  providedIn: 'root'
})
export class SubCategoryService {

  public baseApiUrl: string = environment.apiUrl + 'Employee/subcategory/';

  constructor(private http: HttpClient) { }

    public getAll(categoryId : number): Observable<SubCategory[]> {
    return this.http.get<SubCategory[]>(`${this.baseApiUrl}get-all/${categoryId}`);
    }
    public create(subcategory: SubCategory): Observable<SubCategory> {
        return this.http.post<SubCategory>(`${this.baseApiUrl}create`, subcategory);
    }
    public delete(subcategoryId: number): Observable<any> {
        return this.http.delete<any>(`${this.baseApiUrl}delete/${subcategoryId}`);
    }
    public update(subcategory: SubCategory): Observable<object> {
        return this.http.put(`${this.baseApiUrl}update`, subcategory);
    }
    public findById(subcategoryId: number): Observable<SubCategory> {
        return this.http.get<SubCategory>(`${this.baseApiUrl}find-by-id/${subcategoryId}`);
    }
}
