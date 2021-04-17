import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, timer } from 'rxjs';
import { delayWhen, retryWhen } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Task } from '../models/task';

@Injectable({
  providedIn: 'root'
})
export class ArchivedTasksService {
  constructor(private http: HttpClient) {
  }

  updateTaskState(task: Task): void {
    this.http.put(`${environment.API_URL}task/${task.taskId}`, task)
      .subscribe();
  }

  getArchivedTasks(active: boolean, loadCount: number): Observable<Array<Task>> {
    return this.http.get<Array<Task>>(`${environment.API_URL}task/Archived?active=${active}&loadCount=${loadCount}`)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(1000))
        ))
      );
  }
}
