namespace devdeer.ListOfWork.Logic.Core
{
    using devdeer.ListOfWork.Logic.Interfaces;
    using devdeer.ListOfWork.Logic.Models;
    using System.Collections.Generic;
    /// <summary>
    /// Default logic for handling the <see cref="TodoItemModel"/>s.
    /// </summary>
    public class TodoListLogic : ITodoListLogic
    {
        /// <inheritdoc />
        public TodoItemModel CreateTodo(CreateTodoItemModel todoItem)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public bool DeleteTodo(string id)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public IEnumerable<TodoItemModel>? GetAllDeletedTodos()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public IEnumerable<TodoItemModel>? GetAllTodos()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public TodoItemModel? GetTodoById(string id)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public TodoItemModel? SetTodoToComplete(string id)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public TodoItemModel? UpdateTodo(string id, UpdateTodoItemModel updateTodoItem)
        {
            throw new NotImplementedException();
        }
    }
}
