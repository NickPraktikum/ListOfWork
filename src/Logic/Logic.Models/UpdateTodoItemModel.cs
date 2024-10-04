namespace devdeer.ListOfWork.Logic.Models
{
    /// <summary>
    /// Represent the data needed for the update of a single todo item.
    /// </summary>
    public class UpdateTodoItemModel
    {
        /// <summary>
        /// The title of the updated todo item.
        /// </summary>
        public string Title { get; set; } = default!;
        /// <summary>
        /// A short description of the updated todo item.
        /// </summary>
        public string Description { get; set; } = default!;
        /// <summary>
        /// The time when the updated todo item is supposed to be fulfilled.
        /// </summary>
        public DateTimeOffset DueTime { get; set; } = default;
    }
}
