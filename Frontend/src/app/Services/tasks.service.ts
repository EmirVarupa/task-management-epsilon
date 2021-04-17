import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable, timer } from 'rxjs';
import { delayWhen, retryWhen } from 'rxjs/operators';
import { Task } from '../models/task';

@Injectable({
  providedIn: 'root'
})

export class TasksService {

  loadActiveTasksCount: number;
  loadDoneTasksCount: number;

  constructor(private http: HttpClient) {
    this.loadActiveTasksCount = -1;
    this.loadDoneTasksCount = -1;
  }

  getTasks(active: boolean, loadCount: number): Observable<Array<Task>> {

    return this.http.get<Array<Task>>(`${environment.API_URL}task?active=${active}&loadCount=${loadCount}`)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(1000))
        ))
      );
  }

  getTasksById(id: number): Observable<Array<Task>> {

    return this.http.get<Array<Task>>(`${environment.API_URL}task/${id}`)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(1000))
        ))
      );
  }

  updateTaskState(task: Task): void {
    this.http.put(`${environment.API_URL}task/${task.taskId}`, task)
      .subscribe();
  }

  addTask(task: Task): Observable<any> {
    const headers = { 'Content-Type': 'application/json' };
    return this.http.post(`${environment.API_URL}Task`, task, { headers });
  }

  updateTask(task: Task): Observable<any> {
    return this.http.put(`${environment.API_URL}Task/${task.taskId}`, task);
  }
}
