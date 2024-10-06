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
            var todo = new TodoItemModel
            {
                Title = createTodo.Title,
                Description = createTodo.Description,
                DueTime = createTodo.DueTime,
            };
            _todoItems.Add(todo);
            return Task.FromResult(todo);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteTodoAsync(string id)
        {
            var todoToDelete = await GetByIdAsync(id);
            if (todoToDelete == null )
            {
                return false;
            }
            _todoItems.Remove(todoToDelete);
            return true;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<TodoItemModel>> GetAllTodosAsync()
        {
            return await Task.FromResult(_todoItems);
        }
        /// <inheritdoc/>
        public async Task<TodoItemModel?> GetByIdAsync(string id)
        {
            return await Task.FromResult(_todoItems.SingleOrDefault(todo => todo.Id == id));
        }
        /// <inheritdoc/>
        public async Task<TodoItemModel?> UpdateTodoAsync(UpdateTodoItemModel updateTodo)
        {
            var bookToUpdate = await GetByIdAsync(updateTodo.Id);
            if (bookToUpdate == null)
            {
                return null;
            }
            _todoItems.Remove(bookToUpdate);
            bookToUpdate.Title = updateTodo.Title;
            bookToUpdate.Description = updateTodo.Description;
            bookToUpdate.DueTime = updateTodo.DueTime;
            _todoItems.Add(bookToUpdate);
            return bookToUpdate;
        }
        /// <summary>
        /// An in-memory storage for todos.
        /// </summary>
        private static List<TodoItemModel> _todoItems { get; } = new();
    }
}
