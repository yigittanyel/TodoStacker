import { Component, OnInit } from '@angular/core';
import { TodoServiceService } from 'src/app/Services/todo-service.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.scss'],
})
export class TodoListComponent implements OnInit {
  newTodo: string = '';
  todos = this.todoService.todos;

  constructor(public todoService: TodoServiceService) {}

  ngOnInit(): void {
    this.todoService.getTodos();
  }

  onEnter() {
    if (!this.newTodo || this.newTodo.trim() === '') {
      return;
    }

    const newTask = {
      title: this.newTodo,
      isCompleted: false,
    };

    this.todoService.addTodoItem(newTask);
    this.todoService.getTodos();
  }

  deleteTask(id: number) {
    this.todoService.deleteTodoItem(id);
    this.todoService.getTodos();
  }

  updateTask(id: number, todoItem: any) {
    this.todoService.updateTodoItem(id, todoItem);
    this.todoService.getTodos();
  }
}
