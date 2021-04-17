import { ElementRef } from '@angular/core';
import { Component, Input } from '@angular/core';
import { Task } from '../models/task';
import { TasksService } from '../services/tasks.service';

@Component({
  selector: 'app-archived-task',
  templateUrl: './archived-task.component.html',
  styleUrls: ['./archived-task.component.css', '../task/task.component.css']
})

export class ArchivedTaskComponent {
  @Input() item: Task = new Task();

  constructor(private tasksService: TasksService, private host: ElementRef<HTMLElement>) { }

  ChangeArchiveState(item: Task): void {
    this.host.nativeElement.remove();

    item.archived = !item.archived;
    this.tasksService.updateTaskState(item);
  }
}
