namespace devdeer.ListOfWork.Repositories.Core
{
    using devdeer.ListOfWork.Logic.Models;
    using devdeer.ListOfWork.Repositories.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// A repository to handle todos.
    /// </summary>
    public class TodoListRepository : ITodoListRepository
    {
        /// <inheritdoc/>
        public Task<TodoItemModel> CreateTodoAsync(CreateTodoItemModel createTodo)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public Task<bool> DeleteTodoAsync(string id)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public Task<IEnumerable<TodoItemModel>> GetAllTodosAsync()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public Task<TodoItemModel?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public Task<TodoItemModel?> UpdateTodoAsync(string id, UpdateTodoItemModel updateTodo)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// An in-memory storage for todos.
        /// </summary>
        private static List<TodoItemModel> _todoItems { get; } = new List<TodoItemModel> {};
    }
}
