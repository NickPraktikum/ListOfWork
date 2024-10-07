namespace devdeer.ListOfWork.Tests.Logic.Core
{
    using devdeer.ListOfWork.Logic.Models;
    using devdeer.ListOfWork.Repositories.Interfaces;
    /// <summary>
    /// A simple implentation of an in-memory repository for handling <see cref="TodoItemModel"/>s during unit tests.
    /// </summary>
    public class TodoListTestRepository : ITodoListRepository
    {
        /// <summary>
        /// This is a private default constructor to prevent the creation of instances without the <see cref="Create" /> method.
        /// </summary>
        private TodoListTestRepository()
        {
        }
        ///<inheritdoc/> 
        public Task<TodoItemModel> CreateTodoAsync(CreateTodoItemModel createTodo)
        {
            var todo = new TodoItemModel
            {
                Title = createTodo.Title,
                Description = createTodo.Description,
                DueTime = createTodo.DueTime,
            };
            Database.Add(todo);
            return Task.FromResult(todo);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteTodoAsync(string id)
        {
            var todoToDelete = await GetByIdAsync(id);
            if (todoToDelete == null)
            {
                return false;
            }
            Database.Remove(todoToDelete);
            return true;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<TodoItemModel>> GetAllTodosAsync()
        {
            return await Task.FromResult(Database);
        }
        /// <inheritdoc/>
        public async Task<TodoItemModel?> GetByIdAsync(string id)
        {
            return await Task.FromResult(Database.SingleOrDefault(todo => todo.Id == id));
        }
        /// <inheritdoc/>
        public async Task<TodoItemModel?> UpdateTodoAsync(string id, TodoItemModel updateTodo)
        {
            var todoToUpdate = await GetByIdAsync(id);
            if (todoToUpdate == null)
            {
                return null;
            }
            Database.Remove(todoToUpdate);
            todoToUpdate.Title = updateTodo.Title;
            todoToUpdate.Description = updateTodo.Description;
            todoToUpdate.DueTime = updateTodo.DueTime;
            todoToUpdate.CompletedAt = updateTodo.CompletedAt;
            Database.Add(todoToUpdate);
            return todoToUpdate;
        }

        public static TodoListTestRepository Create(IEnumerable<TodoItemModel> database)
        {
            var result = new TodoListTestRepository();
            result.Database.AddRange(database);
            return result;
        }
        /// <summary>
        /// The in-memory <see cref="TodoItemModel"/> database.
        /// </summary>
        private List<TodoItemModel> Database { get; } = new();
    }
}
