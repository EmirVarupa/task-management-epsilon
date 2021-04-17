import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable, timer } from 'rxjs';
import { delayWhen, retryWhen } from 'rxjs/operators';
import { Priority } from '../models/priority';

@Injectable({
  providedIn: 'root'
})

export class PrioritiesService {

  constructor(private http: HttpClient) { }

    getPriorities(): Observable<Array<Priority>> {
    return this.http.get<Array<Priority>>(`${environment.API_URL}Priority`)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(1000))
        ))
      );
  }
}
