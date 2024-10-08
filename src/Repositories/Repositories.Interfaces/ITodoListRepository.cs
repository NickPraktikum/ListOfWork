namespace devdeer.ListOfWork.Repositories.Interfaces
{
    using devdeer.ListOfWork.Logic.Models;
    /// <summary>
    ///  Must be implemented by types which allow manipulating operations with <see cref="TodoItemModel"/> in the backend.
    /// </summary>
    public interface ITodoListRepository
    {
        /// <summary>
        /// Creates a new <see cref="TodoItemModel"/> data in the backend.
        /// </summary>
        /// <param name="createTodo">The data required for the <see cref="TodoItemModel"/> creation.</param>
        /// <returns>A created <see cref="TodoItemModel"/> with the provided <paramref name="createTodo"/> data.</returns>
        Task<TodoItemModel> CreateTodoAsync(CreateTodoItemModel createTodo);
        /// <summary>
        /// Retrieves all of the <see cref="TodoItemModel"/>s from the backend.
        /// </summary>
        /// <returns>An list of <see cref="TodoItemModel"/>s or <c>null</c> if no items were found in the backend.</returns>
        Task<IEnumerable<TodoItemModel>> GetAllTodosAsync();
        /// <summary>
        /// Retrieves a single <see cref="TodoItemModel"/> from the backend.
        /// </summary>
        /// <param name="id">The id of the <see cref="TodoItemModel"/> in the backend.</param>
        /// <returns>A <see cref="TodoItemModel"/> with the provided <paramref name="id"/> or <c>null</c> if the <see cref="TodoItemModel"/> with provided <paramref name="id"/> wasn't found in the backend.</returns>
        Task<TodoItemModel?> GetByIdAsync(string id);
        /// <summary>
        /// Deletes a single <see cref="TodoItemModel"/> from the backend.
        /// </summary>
        /// <param name="id">The id of the <see cref="TodoItemModel"/> in the backend.</param>
        /// <returns><c>true</c> if the <see cref="TodoItemModel"/> with the provided <paramref name="id"/> was successfully deleted or <c>false</c> if the <see cref="TodoItemModel"/> wasn't deleted from the backend.</returns>
        Task<bool> DeleteTodoAsync(string id);
        /// <summary>
        /// Updates a single <see cref="TodoItemModel"/> in the backend.
        /// </summary>
        /// <param name="id">The id of the <see cref="TodoItemModel"/> in the backend.</param>
        /// <param name="updateTodo">The data to be updated in the <see cref="TodoItemModel"/></param>
        /// <returns>A <see cref="TodoItemModel"/> and updated data from <paramref name="updateTodo"/> or <c>null</c> if the <see cref="TodoItemModel"/> wasn't found in the backend.</returns>
        Task<TodoItemModel?> UpdateTodoAsync(string id, TodoItemModel updateTodo);
    }
}
