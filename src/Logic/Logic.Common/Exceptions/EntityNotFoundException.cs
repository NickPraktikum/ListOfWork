namespace devdeer.ListOfWork.Logic.Common.Exceptions
{
    /// <summary>
    /// An exception that is thrown if while executing an operation an entity couldn't found.
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Constructor with <paramref name="id" />.
        /// </summary>
        /// <param name="id">The unique id of the entitiy which wasn't found.</param>
        public EntityNotFoundException(string id) : base($"Entity with id {id} not found.")
        {
        }
        /// <inheritdoc />
        public EntityNotFoundException(string id, string message) : base(message)
        {
        }
        /// <inheritdoc />
        public EntityNotFoundException(string id, string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
