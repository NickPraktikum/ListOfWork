namespace devdeer.ListOfWork.Repositories.Core
{
    using devdeer.ListOfWork.Logic.Models;
    using devdeer.ListOfWork.Repositories.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TodoListRepository : ITodoListRepository
    {
        public TodoListRepository(TodoItemModel[] todoItems)
        {
            _todoItems = todoItems;
        }

        /// <inheritdoc/>
        public Task<TodoItemModel> CreateTodo(CreateTodoItemModel createTodo)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public Task<bool> DeleteTodo(string id)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public Task<IEnumerable<TodoItemModel>?> GetAllTodos()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public Task<TodoItemModel?> GetById(string id)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public Task<TodoItemModel?> UpdateTodo(string id, UpdateTodoItemModel updateTodo)
        {
            throw new NotImplementedException();
        }
        private TodoItemModel[] _todoItems { get; }
    }
}
