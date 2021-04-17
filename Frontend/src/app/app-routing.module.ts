import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ArchivedComponent } from './archived-drag/archived-drag.component';
import { AssignedDragComponent } from './Assigned/assigned-drag/assigned-drag.component';
import { DragComponent } from './drag/drag.component';
import { ImportantDragComponent } from './important-drag/important-drag.component';

const routes: Routes = [
  {path: '', component: DragComponent},
  {path: 'home', component: DragComponent},
  {path: 'archived', component: ArchivedComponent},
  {path: 'assigned', component: AssignedDragComponent},
  {path: 'important', component: ImportantDragComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
