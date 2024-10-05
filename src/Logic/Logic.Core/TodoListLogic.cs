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
        public Task<TodoItemModel> CreateTodoAsync(CreateTodoItemModel todoItem)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public Task<bool> DeleteTodoAsync(string id)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public Task<IEnumerable<TodoItemModel>?> GetAllDeletedTodosAsync()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public Task<IEnumerable<TodoItemModel>?> GetAllTodosAsync()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public Task<TodoItemModel?> GetTodoByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public Task<TodoItemModel?> SetTodoToCompleteAsync(string id)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public Task<TodoItemModel?> UpdateTodoAsync(string id, UpdateTodoItemModel updateTodoItem)
        {
            throw new NotImplementedException();
        }
    }
}
