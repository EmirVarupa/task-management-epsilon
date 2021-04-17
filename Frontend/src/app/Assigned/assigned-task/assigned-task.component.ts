import { Component, ElementRef, Input, OnInit } from '@angular/core';
import { Task } from 'src/app/models/task';
import { TasksService } from 'src/app/services/tasks.service';

@Component({
  selector: 'app-assigned-task',
  templateUrl: './assigned-task.component.html',
  styleUrls: ['./assigned-task.component.css', '../../task/task.component.css']
})
export class AssignedTaskComponent implements OnInit {
  @Input() item: Task = new Task();

  constructor(private tasksService: TasksService, private host: ElementRef<HTMLElement>) { }

  ngOnInit() { }

  ChangeArchiveState(item: Task): void {
    this.host.nativeElement.remove();

    item.archived = !item.archived;
    this.tasksService.updateTaskState(item);
  }

}
