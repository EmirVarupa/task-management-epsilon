import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable, timer } from 'rxjs';
import { delayWhen, retryWhen } from 'rxjs/operators';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})

export class CategoriesService {
  constructor(private http: HttpClient) { }
    getCategories(): Observable<Array<Category>> {
    return this.http.get<Array<Category>>(`${environment.API_URL}Category`)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(1000))
        ))
      );
  }

}
