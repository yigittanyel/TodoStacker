import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './comp/home/home.component';
import { TodosComponent } from './todos/todos.component';


const routes: Routes = [
  {
    path:'',
    component:HomeComponent
  },
  {
    path:'todos',
    loadChildren: () => import('./todos/todos.module').then(m => m.TodosModule)
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
