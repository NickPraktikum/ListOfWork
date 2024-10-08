namespace devdeer.ListOfWork.Logic.Common.Exceptions
{
    /// <summary>
    /// An exception that is thrown if while executing an operation an entity couldn't be found.
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Constructor with <paramref name="id" />.
        /// </summary>
        /// <param name="id">The unique id of the entity which wasn't found.</param>
        public EntityNotFoundException(string id) : base($"Entity with id {id} not found.")
        {
        }
        /// <summary>
        /// Constructor with <paramref name="id"/> and <paramref name="message"/>.
        /// </summary>
        /// <param name="id">The unique id of the entity which wasn't found.</param>
        /// <param name="message">The error message text.</param>
        public EntityNotFoundException(string id, string message) : base(message)
        {
        }
        /// <summary>
        /// Constructor with <paramref name="id"/>, <paramref name="message"/> and <paramref name="innerException"/>.
        /// </summary>
        /// <param name="id">The unique id of the entity which wasn't found.</param>
        /// <param name="message">The error message text.</param>
        /// <param name="innerException">An inner <see cref="Exception"/> inside the error.</param>
        public EntityNotFoundException(string id, string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
