import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable, timer } from 'rxjs';
import { delayWhen, retryWhen } from 'rxjs/operators';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})

export class UsersService {
  constructor(private http: HttpClient) { }

    getUsers(): Observable<Array<User>> {
    return this.http.get<Array<User>>(`${environment.API_URL}User`)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(1000))
        ))
      );
  }

}
