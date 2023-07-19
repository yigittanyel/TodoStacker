import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { TodoItem } from '../Models/todo-item';
import { TodoCreateItem } from '../Models/todo-create-item';

@Injectable({
  providedIn: 'root'
})
export class TodoServiceService {

  constructor(
    @Inject('apiUrl') private apiUrl: string,
    private http: HttpClient
  ) { }

  todos: TodoItem[]=[];

  getTodos(): void {
    this.http.get<TodoItem[]>(this.apiUrl + 'GetTodos')
    .subscribe(
      (res: TodoItem[]) => {
        this.todos = res; 
      }
    );
  }
  

  getTodoItem(id: number):void {
    this.http.get<TodoItem>(this.apiUrl + 'GetTodo/' + id)
    .subscribe((res: TodoItem) => {
      let index = this.todos.findIndex(t => t.id == res.id);
      this.todos[index] = res;
    });
  }

  addTodoItem(todoItem: TodoCreateItem):void {
    this.http.post<TodoItem>(this.apiUrl + 'CreateTodo', todoItem)
    .subscribe((res: TodoItem) => {
       this.todos.push(res);
      });
  }

  deleteTodoItem(id: number):void {
    this.http.delete<TodoItem>(this.apiUrl + 'DeleteTodo/' + id)
    .subscribe((res: TodoItem) => {
      let index =  this.todos.findIndex(t => t.id == res.id);
      this.todos.splice(index, 1);
    });
  }

  updateTodoItem(id:number,todoItem: TodoItem):void {
    this.http.put<TodoItem>(this.apiUrl + 'UpdateTodo/' + id, todoItem)
    .subscribe( (res: TodoItem) => {
      let index = this.todos.findIndex(t => t.id == res.id);
      this.todos[index] = res;
    });
  }

}
