import { ElementRef, ViewEncapsulation } from '@angular/core';
import { Component, Input } from '@angular/core';
import { Task } from '../models/task';
import { TasksService } from '../services/tasks.service';
import { MatDialog } from '@angular/material/dialog';
import { DetailsComponent } from '../details/details.component';
import { EditTaskComponent } from '../edit-task/edit-task.component';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class TaskComponent {

  @Input() item: Task = new Task();

  constructor(private tasksService: TasksService, private host: ElementRef<HTMLElement>, private dialog: MatDialog) { }

  ChangeArchiveState(item: Task): void {
    this.host.nativeElement.remove();

    item.archived = !item.archived;
    this.tasksService.updateTaskState(item);
  }

  OpenDetails(item: Task) {

    const enddate = item.endDate;
    const tempEndDate = enddate?.toString();
    let shortEndDate = '';

    const creationdate = item.creationDate;
    const tempCreationDate = creationdate?.toString();
    let shortCreationDate = '';

    if (tempEndDate !== undefined) {
      shortEndDate = tempEndDate.slice(0, tempEndDate?.indexOf('T'));
    }

    if (tempCreationDate !== undefined) {
      shortCreationDate = tempCreationDate?.slice(0, tempCreationDate?.indexOf('T'));
    }

    this.dialog.open(DetailsComponent, {
      data: {
        title: item.title,
        description: item.description,
        category: item.category.title,
        priority: item.priority.name,
        creationDate: shortCreationDate,
        userFirstName: item.user.firstName,
        userLastName: item.user.lastName,
        endDate: shortEndDate,
      },
      panelClass: 'custom-dialog-container'
    });
  }


  editTask(item: Task): void {
    this.dialog.open(EditTaskComponent, {
      data: {
        taskId: item.taskId,
        title: item.title,
        description: item.description,
        categoryId: item.category.categoryId,
        priorityId: item.priority.priorityId,
        userId: item.user.userId,
        creationDate: item.creationDate,
        userFirstName: item.user.firstName,
        userLastName: item.user.lastName,
        endDate: item.endDate,
        active: item.active
      }
    });
  }

  getBorder(name: string) {
    switch (name) {
      case 'High':
        return '#d9534f';
      case 'Medium':
        return '#f0ad4e';
      default:
        return '#0275d8';
    }
  }
}
