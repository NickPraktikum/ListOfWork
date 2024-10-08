namespace devdeer.ListOfWork.Logic.Core
{
    using devdeer.ListOfWork.Logic.Common.Exceptions;
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
            if(string.IsNullOrEmpty(createTodo.Title) || string.IsNullOrWhiteSpace(createTodo.Title))
            {
                throw new ArgumentException("Value can't be null or whitespace.", nameof(createTodo.Title));
            }
            if (string.IsNullOrEmpty(createTodo.Description) || string.IsNullOrWhiteSpace(createTodo.Description))
            {
                throw new ArgumentException("Value can't be null or whitespace.", nameof(createTodo.Description));
            }
            var dateTimeNow = DateTimeOffset.UtcNow;
            if (createTodo.DueTime <= dateTimeNow)
            {
                throw new ArgumentException("Value can't have a date that is earlier or equals the time at the moment.", nameof(createTodo.DueTime));
            }
            return await Repository.CreateTodoAsync(createTodo);
        }
        /// <inheritdoc />
        public async Task<bool> DeleteTodoAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Value can't be null or whitespace.", nameof(id));
            }
            if (id.Length != 4)
            {
                throw new ArgumentException("Value can only have 4 characters.", nameof(id));
            }
            var todo = await Repository.GetByIdAsync(id) ?? throw new EntityNotFoundException(id);
            return await Repository.DeleteTodoAsync(id);
        }
        /// <inheritdoc />
        public async Task<IEnumerable<TodoItemModel>> GetAllTodosAsync()
        {
            return await Repository.GetAllTodosAsync();
        }
        /// <inheritdoc />
        public async Task<TodoItemModel?> GetTodoByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Value can't be null or whitespace.", nameof(id));
            }
            if (id.Length != 4)
            {
                throw new ArgumentException("Value can only have 4 characters.", nameof(id));
            }
            return await Repository.GetByIdAsync(id);
        }
        /// <inheritdoc />
        public async Task<TodoItemModel?> SetTodoToCompleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Value can't be null or whitespace.", nameof(id));
            }
            if (id.Length != 4)
            {
                throw new ArgumentException("Value can only have 4 characters.", nameof(id));
            }
            var todo = await GetTodoByIdAsync(id) ?? throw new EntityNotFoundException(id);
            var dateTimeNow = DateTimeOffset.Now;
            if (todo.DueTime < dateTimeNow)
            {
                throw new InvalidOperationException("Expired todo can't be set to completed");
            }
            if (todo.CompletedAt != null)
            {
                throw new InvalidOperationException("The todo is already set to completed.");
            }
            todo.CompletedAt = dateTimeNow;
            return await Repository.UpdateTodoAsync(id, todo);
        }
        /// <inheritdoc />
        public async Task<TodoItemModel?> UpdateTodoAsync(string id, TodoItemModel updateTodoItem)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Value can't be null or whitespace.", nameof(id));
            }
            if (id.Length != 4)
            {
                throw new ArgumentException("Value can only have 4 characters.", nameof(id));
            }
            if (string.IsNullOrEmpty(updateTodoItem.Title) || string.IsNullOrWhiteSpace(updateTodoItem.Title))
            {
                throw new ArgumentException("Value can't be null or whitespace.", nameof(updateTodoItem.Id));
            }
            if (string.IsNullOrEmpty(updateTodoItem.Description) || string.IsNullOrWhiteSpace(updateTodoItem.Description))
            {
                throw new ArgumentException("Value can't be null or whitespace.", nameof(updateTodoItem.Description));
            }
            if (updateTodoItem.DueTime <= updateTodoItem.CreatedAt)
            {
                throw new ArgumentException("Value can't have a date that is earlier or equals the time at the moment.", nameof(updateTodoItem.DueTime));
            }
            if (updateTodoItem.CompletedAt > updateTodoItem.DueTime)
            {
                throw new ArgumentException($"Value can't have a date that is after the time of when the item is due({nameof(updateTodoItem.DueTime)}).", nameof(updateTodoItem.CompletedAt));
            }
            if (updateTodoItem.CompletedAt <= updateTodoItem.CreatedAt) {
                throw new ArgumentException($"Value can't have a date that is earlier or equals the time of creation({nameof(updateTodoItem.CreatedAt)}).", nameof(updateTodoItem.CompletedAt));
            }
            return await Repository.UpdateTodoAsync(id, updateTodoItem);
        }
        /// <summary>
        /// The repository for handling todo in the backend.
        /// </summary>
        private ITodoListRepository Repository { get; }
    }
}
