import { getLocaleFirstDayOfWeek } from '@angular/common';
import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialog } from '@angular/material/dialog';
import { Category } from '../models/category';
import { Priority } from '../models/priority';
import { Task } from '../models/task';
import { User } from '../models/user';
import { CategoriesService } from '../services/categories.service';
import { PrioritiesService } from '../services/priorities.service';
import { UsersService } from '../services/users.service';
import { TasksService } from '../services/tasks.service';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class AddTaskComponent implements OnInit {
  @Input() item: Task = new Task();

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
  private tasksService: TasksService) {

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

  onSubmit() {
    this.tasksService.addTask(this.newTask).subscribe();
    this.dialog.closeAll();
  }

  closeContainer() {
    this.dialog.closeAll();
  }

}
