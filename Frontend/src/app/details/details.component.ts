import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TasksService } from '../services/tasks.service';
import { ElementRef } from '@angular/core';
import { TaskComponent } from '../task/task.component';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  constructor(private tasksService: TasksService,
  private host: ElementRef<HTMLElement>,
  private dialog: MatDialog,
  public dialogRef: MatDialogRef<TaskComponent>,
  @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
  }

  close() {
    this.dialog.closeAll();
  }

}
