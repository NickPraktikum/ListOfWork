﻿namespace devdeer.ListOfWork.Logic.Interfaces
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
        /// <param name="todoItem">The data needed for the <see cref="TodoItemModel"/> creation.</param>
        /// <returns>The created <see cref="TodoItemModel"/> with the provided data(<see cref="CreateTodoItemModel"/>).</returns>
        TodoItemModel CreateTodo(CreateTodoItemModel todoItem);
        /// <summary>
        /// Retrieves all of the <see cref="TodoItemModel"/>s from the backend. 
        /// </summary>
        /// <returns>An array of <see cref="TodoItemModel"/>s present in the backend or <c>null</c> if no available <see cref="TodoItemModel"/>s were found in the backend.</returns>
        IEnumerable<TodoItemModel>? GetAllTodos();
        /// <summary>
        /// Retrieves all of the deleted <see cref="TodoItemModel"/>s from the backend.
        /// </summary>
        /// <returns>An array of deleted <see cref="TodoItemModel"/>s from the backend or <c>null</c> if no deleted <see cref="TodoItemModel"/>s were found.</returns>
        IEnumerable<TodoItemModel>? GetAllDeletedTodos();
        /// <summary>
        /// Retrieves a single <see cref="TodoItemModel"/> with the provided <paramref name="id"/> from the backend.
        /// </summary>
        /// <param name="id">The id of the todo <see cref="TodoItemModel"/> in the backend.</param>
        /// <returns>A <see cref="TodoItemModel"/> with the provided <paramref name="id"/> or <c>null</c> if the <see cref="TodoItemModel"/> with the <paramref name="id"/> wasn't found in the backend.</returns>
        TodoItemModel? GetTodoById(string id);
        /// <summary>
        /// Deletes a single <see cref="TodoItemModel"/> from the backend.
        /// </summary>
        /// <param name="id">The id of the <see cref="TodoItemModel"/> which is supposed to be deleted.</param>
        /// <returns><c>true</c> if the <see cref="TodoItemModel"/> with the provided <paramref name="id"/> was deleted from the backend or <c>false</c> if the <see cref="TodoItemModel"/> with the <paramref name="id"/> couldn't be deleted.</returns>
        bool DeleteTodo(string id);
        /// <summary>
        /// Sets the <see cref="TodoItemModel"/> complition state to done.
        /// </summary>
        /// <param name="id">The id of the <see cref="TodoItemModel"/> whose completion state is supposed to be set to done.</param>
        /// <returns>A <see cref="TodoItemModel"/>, whose <see cref="TodoItemModel.CompletedAt"/> is set to <see cref="DateTimeOffset.Now"/> if the <see cref="TodoItemModel"/> with the provided <paramref name="id"/> was found and <c>null</c> if the <see cref="TodoItemModel"/> with the <paramref name="id"/> wasn't found.</returns>
        TodoItemModel? SetTodoToComplete(string id);
        /// <summary>
        /// Updates the data inside of a <see cref="TodoItemModel"/>. 
        /// </summary>
        /// <param name="id">The id of the <see cref="TodoItemModel"/> whose data is supposed to be updated.</param>
        /// <param name="updateTodoItem">The data that is supposed to be updated in the <see cref="TodoItemModel"/>.</param>
        /// <returns>A <see cref="TodoItemModel"/> with the <paramref name="id"/> whose data was updated to <paramref name="updateTodoItem"/> or <c>null</c> if the <see cref="TodoItemModel"/> with <paramref name="id"/> wasn't found in the backend.</returns>
        TodoItemModel? UpdateTodo(string id, UpdateTodoItemModel updateTodoItem);
    }
}
