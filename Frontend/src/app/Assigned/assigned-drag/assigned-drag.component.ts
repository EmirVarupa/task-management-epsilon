import { moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddTaskComponent } from 'src/app/add-task/add-task.component';
import { Task } from 'src/app/models/task';
import { AssignedTasksService } from 'src/app/Services/assigned-tasks.service';

@Component({
  selector: 'app-assigned-drag',
  templateUrl: './assigned-drag.component.html',
  styleUrls: ['./assigned-drag.component.css', '../../drag/drag.component.css']
})
export class AssignedDragComponent implements OnInit {

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

  constructor(private assignedTasksService: AssignedTasksService, private dialog: MatDialog) {
    this.startPage = 0;
    this.paginationLimitActive = 2;
    this.paginationLimitDone = 2;
    this.loadActiveTasksCount = 0;
    this.loadDoneTasksCount = 0;
  }

  ngOnInit(): void {

    /*
     * Takes all archived tasks that have active property set to true and puts them into activeTasks array
     */
    this.assignedTasksService.getAssignedToUserIdTasks(true, 0, 1)
      .subscribe(res => {
        this.activeTasks = res;
      });

    /*
     * Takes all archived tasks that have active property set to false and puts them into doneTasks array
     */
    this.assignedTasksService.getAssignedToUserIdTasks(false, 0, 1)
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
      this.assignedTasksService.updateTaskState(this.changedTask);

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

    this.assignedTasksService.getAssignedToUserIdTasks(listActive, loadCount, 1)
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
