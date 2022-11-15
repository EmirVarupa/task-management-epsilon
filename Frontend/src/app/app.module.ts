import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSidenavModule} from '@angular/material/sidenav';
import { CardComponent } from './card/card.component';
import {MatCardFooter, MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatSelectModule} from '@angular/material/select';
import {DragDropModule} from '@angular/cdk/drag-drop';
import { DragComponent } from './drag/drag.component';
import { SideMenuComponent } from './side-menu/side-menu.component';
import { HttpClientModule } from '@angular/common/http';
import { TaskComponent } from './task/task.component';
import { ArchivedComponent } from './archived-drag/archived-drag.component';
import { ArchivedTaskComponent } from './archived-task/archived-task.component';
import { AssignedDragComponent } from './Assigned/assigned-drag/assigned-drag.component';
import { AssignedTaskComponent } from './Assigned/assigned-task/assigned-task.component';
import { ImportantDragComponent } from './important-drag/important-drag.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatNativeDateModule } from '@angular/material/core';
import { DetailsComponent } from './details/details.component';
import { MatDialogActions, MatDialogModule } from '@angular/material/dialog';
import {MatDatepickerModule, MatDatepickerToggle} from '@angular/material/datepicker';
import {MatInputModule} from '@angular/material/input';
import {MatMenuModule} from '@angular/material/menu';
import { FormsModule } from '@angular/forms';
import { EditTaskComponent } from './edit-task/edit-task.component';
import { AddTaskComponent } from './add-task/add-task.component';
import { FlexLayoutModule } from "@angular/flex-layout";

@NgModule({
  declarations: [
    AppComponent,
    CardComponent,
    DragComponent,
    SideMenuComponent,
    TaskComponent,
    ArchivedComponent,
    ArchivedTaskComponent,
    AssignedDragComponent,
    AssignedTaskComponent,
    ImportantDragComponent,
    DetailsComponent,
    AddTaskComponent,
    EditTaskComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatMenuModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatSelectModule,
    DragDropModule,
    HttpClientModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatDialogModule,
    MatInputModule,
    FormsModule,
    FlexLayoutModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {

}
