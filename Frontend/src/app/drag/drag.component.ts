import { Component, OnInit } from '@angular/core';

import {CdkDragDrop, moveItemInArray, transferArrayItem} from '@angular/cdk/drag-drop';
import { Task } from '../models/task';
import { TasksService } from '../services/tasks.service';
import { AddTaskComponent } from '../add-task/add-task.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-drag',
  templateUrl: './drag.component.html',
  styleUrls: ['./drag.component.css']
})
export class DragComponent implements OnInit {

  activeTasks: Array<Task> = [];
  doneTasks: Array<Task> = [];
  index = 0;
  container = '';
  changedTask: Task = new Task();
  startPage: number;
  paginationLimitActive: number;
  paginationLimitDone: number;

  loadActiveTasksCount: number;
  loadDoneTasksCount: number;

constructor(private tasksService: TasksService, private dialog: MatDialog) {
  this.startPage = 0;
  this.paginationLimitActive = 2;
  this.paginationLimitDone = 2;

  this.loadActiveTasksCount = 0;
  this.loadDoneTasksCount = 0;
}

  ngOnInit(): void {
    /*
     * Takes all tasks that have active property set to true and puts them into activeTasks array
     */
    this.tasksService.getTasks(true, 0)
    .subscribe(res => {
      this.activeTasks = res;
    });

    /*
     * Takes all tasks that have active property set to false and puts them into doneTasks array
     */
    this.tasksService.getTasks(false, 0)
    .subscribe(res => {
      this.doneTasks = res;
    });
  }

  drop(event: any) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      this.index = event.previousIndex;
      this.container = event.previousContainer.id;

      if (this.container === 'cdk-drop-list-0'){
        this.changedTask = this.activeTasks[this.index];
      }
      else {
        this.changedTask = this.doneTasks[this.index];
      }

      this.changedTask.active = !this.changedTask.active;

      this.tasksService.updateTaskState(this.changedTask);

      transferArrayItem(event.previousContainer.data,
                        event.container.data,
                        event.previousIndex,
                        event.currentIndex);
    }
  }

  showMoreItems(listActive: boolean)
  {
    let loadCount;

    if (listActive === true) {
      this.loadActiveTasksCount++;
      loadCount = this.loadActiveTasksCount;
    } else {
      this.loadDoneTasksCount++;
      loadCount = this.loadDoneTasksCount;
    }

    this.tasksService.getTasks(listActive, loadCount)
    .subscribe(res => {
      if (listActive) {
        this.activeTasks = [ ...this.activeTasks, ...res];
        this.paginationLimitActive = this.activeTasks.length;
        this.paginationLimitActive = Number(this.paginationLimitActive) + 2;
      } else {
        this.doneTasks = [ ...this.doneTasks, ...res];
        this.paginationLimitActive = this.activeTasks.length;
        this.paginationLimitDone = Number(this.paginationLimitDone) + 2;
      }
    });
  }

  showLessItems(listActive: boolean)
  {
    if (listActive) {
      this.paginationLimitActive = 2;
    } else {
      this.paginationLimitDone = 2;
    }
  }

 addToDo(): void {
  this.dialog.open(AddTaskComponent);
  }

}
