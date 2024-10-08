namespace devdeer.ListOfWork.Logic.Models
{
    /// <summary>
    /// Represents data needed for the creation of a single <see cref="TodoItemModel"/>.
    /// </summary>
    public class CreateTodoItemModel
    {
        /// <summary>
        /// The title of the created <see cref="TodoItemModel"/>.
        /// </summary>
        public string Title { get; set; } = default!;
        /// <summary>
        /// A short description of the created <see cref="TodoItemModel"/>.
        /// </summary>
        public string Description { get; set; } = default!;
        /// <summary>
        /// The time when the created <see cref="TodoItemModel"/> is supposed to be fulfilled.
        /// </summary>
        public DateTimeOffset DueTime { get; set; } = default;
    }
}
