namespace devdeer.ListOfWork.Logic.Core
{
    using devdeer.ListOfWork.Logic.Interfaces;
    using devdeer.ListOfWork.Logic.Models;
    using devdeer.ListOfWork.Repositories.Interfaces;
    using System.Collections.Generic;
    /// <summary>
    /// Default logic for handling the <see cref="TodoItemModel"/>s.
    /// </summary>
    public class TodoListLogic : ITodoListLogic
    {
        /// <summary>
        /// A default contstructor for the logic.
        /// </summary>
        /// <param name="repository">The repository that is supposed to be injected into the logic.</param>
        public TodoListLogic(ITodoListRepository repository) {
            Repository = repository;
        }
        /// <inheritdoc />
        public async Task<TodoItemModel> CreateTodoAsync(CreateTodoItemModel createTodo)
        {
            return await Repository.CreateTodoAsync(createTodo);
        }
        /// <inheritdoc />
        public async Task<bool> DeleteTodoAsync(string id)
        {
            return await Repository.DeleteTodoAsync(id);
        }
        /// <inheritdoc />
        public async Task<IEnumerable<TodoItemModel>> GetAllDeletedTodosAsync()
        {
            var result = await Repository.GetAllTodosAsync();
            return result!.Where(todo => todo.IsDeleted);
        }
        /// <inheritdoc />
        public async Task<IEnumerable<TodoItemModel>> GetAllTodosAsync()
        {
            return await Repository.GetAllTodosAsync();
        }
        /// <inheritdoc />
        public async Task<TodoItemModel?> GetTodoByIdAsync(string id)
        {
            return await Repository.GetByIdAsync(id);
        }
        /// <inheritdoc />
        public async Task<TodoItemModel?> SetTodoToCompleteAsync(string id)
        {
            return await Repository.UpdateTodoAsync(new UpdateTodoItemModel());
        }
        /// <inheritdoc />
        public async Task<TodoItemModel?> UpdateTodoAsync(UpdateTodoItemModel updateTodoItem)
        {
            return await Repository.UpdateTodoAsync(updateTodoItem);
        }
        /// <summary>
        /// The repository for handling todo in the backend.
        /// </summary>
        private ITodoListRepository Repository { get; }
    }
}
