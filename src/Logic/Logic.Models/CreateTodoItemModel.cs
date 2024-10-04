namespace devdeer.ListOfWork.Logic.Models
{
    /// <summary>
    /// Represent the data needed for the creation of a single todo item.
    /// </summary>
    public class CreateTodoItemModel
    {
        /// <summary>
        /// The title of the created todo item.
        /// </summary>
        public string Title { get; set; } = default!;
        /// <summary>
        /// A short description of the created todo item.
        /// </summary>
        public string Description { get; set; } = default!;
        /// <summary>
        /// The time when the created todo item is supposed to be fulfilled.
        /// </summary>
        public DateTimeOffset DueTime { get; set; } = default;
    }
}
