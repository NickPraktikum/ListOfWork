namespace devdeer.ListOfWork.Logic.Interfaces
{
    using devdeer.ListOfWork.Logic.Models;
    /// <summary>
    /// Must be implemented by components that provide logic to handle the <see cref="TodoItemModel"/>s.
    /// </summary>
    public interface ITodoListLogic
    {
        /// <summary>
        /// Creates a new <see cref="TodoItemModel"/> in the backend.
        /// </summary>
        /// <param name="createTodo">The data needed for the <see cref="TodoItemModel"/> creation.</param>
        /// <returns>The created <see cref="TodoItemModel"/> with the provided data(<see cref="CreateTodoItemModel"/>).</returns>
        Task<TodoItemModel> CreateTodoAsync(CreateTodoItemModel createTodo);
        /// <summary>
        /// Retrieves all of the <see cref="TodoItemModel"/>s from the backend. 
        /// </summary>
        /// <returns>An list of <see cref="TodoItemModel"/>s present in the backend or <c>null</c> if no available <see cref="TodoItemModel"/>s were found in the backend.</returns>
        Task<IEnumerable<TodoItemModel>> GetAllTodosAsync();
        /// <summary>
        /// Retrieves a single <see cref="TodoItemModel"/> with the provided <paramref name="id"/> from the backend.
        /// </summary>
        /// <param name="id">The id of the todo <see cref="TodoItemModel"/> in the backend.</param>
        /// <returns>A <see cref="TodoItemModel"/> with the provided <paramref name="id"/> or <c>null</c> if the <see cref="TodoItemModel"/> with the <paramref name="id"/> wasn't found in the backend.</returns>
        Task<TodoItemModel?> GetTodoByIdAsync(string id);
        /// <summary>
        /// Deletes a single <see cref="TodoItemModel"/> from the backend.
        /// </summary>
        /// <param name="id">The id of the <see cref="TodoItemModel"/> which is supposed to be deleted.</param>
        /// <returns><c>true</c> if the <see cref="TodoItemModel"/> with the provided <paramref name="id"/> was deleted from the backend or <c>false</c> if the <see cref="TodoItemModel"/> with the <paramref name="id"/> couldn't be deleted.</returns>
        Task<bool> DeleteTodoAsync(string id);
        /// <summary>
        /// Sets a single <see cref="TodoItemModel"/> complition state to done.
        /// </summary>
        /// <param name="id">The id of the <see cref="TodoItemModel"/> whose completion state is supposed to be set to done.</param>
        /// <returns>A <see cref="TodoItemModel"/>, whose <see cref="TodoItemModel.CompletedAt"/> is set to <see cref="DateTimeOffset.Now"/> if the <see cref="TodoItemModel"/> with the provided <paramref name="id"/> was found and <c>null</c> if the <see cref="TodoItemModel"/> with the <paramref name="id"/> wasn't found.</returns>
        Task<TodoItemModel?> SetTodoToCompleteAsync(string id);
        /// <summary>
        /// Updates the data inside of a single <see cref="TodoItemModel"/>. 
        /// </summary>
        /// <param name="updateTodoItem">The data that is supposed to be updated in the <see cref="TodoItemModel"/>.</param>
        /// <returns>A <see cref="TodoItemModel"/> whose data was updated to <paramref name="updateTodoItem"/> or <c>null</c> if the <see cref="TodoItemModel"/> wasn't found in the backend.</returns>
        Task<TodoItemModel?> UpdateTodoAsync(TodoItemModel updateTodoItem);
    }
}
