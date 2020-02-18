import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../shared/models/category';


@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  public baseApiUrl: string = environment.apiUrl + 'Employee/category/';
  
  constructor(private http: HttpClient) { }
  
   public getAll(): Observable<Category[]> {
       return this.http.get<Category[]>(`${this.baseApiUrl}get-all`);
   }
   public create(category: Category): Observable<Category> {
       return this.http.post<Category>(`${this.baseApiUrl}create`, category);
   }
   public delete(categoryId: number): Observable<any> {
       return this.http.delete<any>(`${this.baseApiUrl}delete/${categoryId}`);
   }
   public update(category: Category): Observable<object> {
       return this.http.put(`${this.baseApiUrl}update`, category);
   }
   public findById(categoryId: number): Observable<Category> {
       return this.http.get<Category>(`${this.baseApiUrl}find-by-id/${categoryId}`);
   }
   
}
