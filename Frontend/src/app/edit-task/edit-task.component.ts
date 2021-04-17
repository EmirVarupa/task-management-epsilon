import { getLocaleFirstDayOfWeek } from '@angular/common';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Category } from '../models/category';
import { Priority } from '../models/priority';
import { Task } from '../models/task';
import { User } from '../models/user';
import { CategoriesService } from '../services/categories.service';
import { PrioritiesService } from '../services/priorities.service';
import { UsersService } from '../services/users.service';
import { FormBuilder, Validators } from '@angular/forms';
import { TasksService } from '../services/tasks.service';
import { TaskComponent } from '../task/task.component';

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.css']
})
export class EditTaskComponent implements OnInit {

  priorities: Array<Priority> = [];
  categories: Array<Category> = [];
  users: Array<User> = [];
  minDate: Date;
  startDate: Date;
  newTask: Task = new Task();
  tasksCategory: Category = new Category();
  tasksPriority: Priority = new Priority();
  tasksUser: User = new User();

  constructor(private dialog: MatDialog,
    private prioritiesService: PrioritiesService,
    private categoriesService: CategoriesService,
    private usersService: UsersService,
    private tasksService: TasksService,
    public dialogRef: MatDialogRef<TaskComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {

    const today = new Date().toLocaleDateString();
    this.minDate = new Date(today);
    this.startDate = new Date();
     }

  ngOnInit(): void {
    this.prioritiesService.getPriorities()
    .subscribe(res => {
      this.priorities = res;
    });

    this.categoriesService.getCategories()
    .subscribe(res => {
      this.categories = res;
    });

    this.usersService.getUsers()
    .subscribe(res => {
      this.users = res;
    });
  }

  onSubmit(data: any) {
    this.newTask.taskId = data.taskId;
    this.newTask.title = data.title;
    this.newTask.description = data.description;
    this.newTask.categoryId = data.categoryId;
    this.newTask.priorityId = data.priorityId;
    this.newTask.userId = data.userId;
    this.newTask.endDate = data.endDate;
    this.newTask.active = data.active;

    this.tasksService.updateTask(this.newTask).subscribe();
    this.dialog.closeAll();
  }

  closeContainer(){
    this.dialog.closeAll();
   }


}
