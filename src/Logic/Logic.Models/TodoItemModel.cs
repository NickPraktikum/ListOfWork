namespace devdeer.ListOfWork.Logic.Models
{
    /// <summary>
    /// A representation of a single todo list item inside of the backend.
    /// </summary>
    public class TodoItemModel
    { 
        /// <summary>
        /// The unique identifier of the item in the backend.
        /// </summary>
        public string Id { get; } = Guid.NewGuid()
            .ToString("N")
            .Substring(1, 4);
        /// <summary>
        /// The title of the todo item.
        /// </summary>
        public string Title { get; set; } = default!;
        /// <summary>
        /// A short description of the todo item.
        /// </summary>
        public string Description { get; set; } = default!;
        /// <summary>
        /// The time of the item creation. The time is automatically set to now to display the time of the request.
        /// </summary>
        public DateTimeOffset CreatedAt { get; } = DateTimeOffset.Now;
        /// <summary>
        /// The time when the todo item is supposed to be fulfilled.
        /// </summary>
        public DateTimeOffset DueTime { get; set; }
        /// <summary>
        /// The time of the todo item completion. The property indicates if the todo item is fulfilled and at what time.
        /// </summary>
        public DateTimeOffset? CompletedAt { get; set; }
    }
}
