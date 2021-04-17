import { moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddTaskComponent } from '../add-task/add-task.component';
import { Task } from '../models/task';
import { ImportantTasksService } from '../Services/important-tasks.service';

@Component({
  selector: 'app-important-drag',
  templateUrl: './important-drag.component.html',
  styleUrls: ['./important-drag.component.css', '../drag/drag.component.css']
})
export class ImportantDragComponent implements OnInit {

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

  constructor(private importantTasksService: ImportantTasksService, private dialog: MatDialog) {
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
    this.importantTasksService.getImportantTasksByPriorityId(true, 0, 3)
      .subscribe(res => {
        this.activeTasks = res;
      });

    /*
     * Takes all tasks that have active property set to false and puts them into doneTasks array
     */
    this.importantTasksService.getImportantTasksByPriorityId(false, 0, 3)
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

      if (this.container === 'cdk-drop-list-0') {
        this.changedTask = this.activeTasks[this.index];
      }
      else {
        this.changedTask = this.doneTasks[this.index];
      }

      this.changedTask.active = !this.changedTask.active;

      this.importantTasksService.updateTaskState(this.changedTask);

      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
    }
  }

  showMoreItems(listActive: boolean) {
    let loadCount;

    if (listActive === true) {
      this.loadActiveTasksCount++;
      loadCount = this.loadActiveTasksCount;
    } else {
      this.loadDoneTasksCount++;
      loadCount = this.loadDoneTasksCount;
    }

    this.importantTasksService.getImportantTasksByPriorityId(listActive, loadCount, 3)
      .subscribe(res => {
        if (listActive) {
          this.activeTasks = [...this.activeTasks, ...res];
          this.paginationLimitActive = Number(this.paginationLimitActive) + 2;
        } else {
          this.doneTasks = [...this.doneTasks, ...res];
          this.paginationLimitDone = Number(this.paginationLimitDone) + 2;
        }
      });
  }

  showLessItems(listActive: boolean) {
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
