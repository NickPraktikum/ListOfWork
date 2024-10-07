namespace devdeer.ListOfWork.Services.CoreApi.Controllers.v1
{
    using devdeer.ListOfWork.Logic.Interfaces;
    using devdeer.ListOfWork.Logic.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Provides endpoints to handle todo items.
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TodoListController : ControllerBase
    {
        /// <summary>
        /// The business logic for this controller.
        /// </summary>
        private ITodoListLogic Logic { get; }
        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="logic">The business logic for this controller.</param>
        public TodoListController(ITodoListLogic logic) { 
            Logic = logic;
        }
        /// <summary>
        /// Creates a new todo item in the backend.
        /// </summary>
        /// <param name="createTodo">The data required for the todo item creation.</param>
        /// <returns>The created todo item with the provided creation data in the backend.</returns>
        /// <response code="200">Returns the created todo item.</response>
        [HttpPost]
        public async Task<ActionResult<TodoItemModel>> CreateTodoAsync(CreateTodoItemModel createTodo)
        {
            var result = await Logic.CreateTodoAsync(createTodo);
            return Ok(result);
        }
        /// <summary>
        /// Retrieves all of the todo items from the backend.
        /// </summary>
        /// <returns>An list of todo items found in the backend.</returns>
        /// <response code="200">Returns an list of todo item.</response>
        /// <response code="404">If no todo items were found.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemModel>>> GetAllTodos() { 
            var result = await Logic.GetAllTodosAsync();
            return result.Any() ? Ok(result) : NotFound();
        }
        /// <summary>
        /// Retrieves a single todo item with the provided <paramref name="id"/> from backend.
        /// </summary>
        /// <param name="id">The id of the todo item in the backend.</param>
        /// <returns>A todo item with the provided <paramref name="id"/>.</returns>
        /// <response code="200">Returns the todo item with the provided <paramref name="id"/>.</response>
        /// <response code="404">If no todo item with the provided <paramref name="id"/> were found.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemModel?>> GetTodoById(string id)
        {
            var result = await Logic.GetTodoByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }
        /// <summary>
        /// Deletes a single todo item with the provided <paramref name="id"/> from the backend.
        /// </summary>
        /// <param name="id">The id of the todo item in backend.</param>
        /// <returns><c>true</c> if the todo item with the provided <paramref name="id"/> was successfully deleted or <c>false</c> if the todo item with the provided <paramref name="id"/> wasn't deleted.</returns>
        /// <response code="200"><c>true</c> if the todo item was deleted or <c>false</c> if it wasn't deleted.</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTodo(string id)
        {
            var result = await Logic.DeleteTodoAsync(id);
            return Ok(result);
        }
        /// <summary>
        /// Sets a single todo item to completed state.
        /// </summary>
        /// <param name="id">The id of the todo item in the backend.</param>
        /// <returns>A todo item with the provided <paramref name="id"/> and state set to completed.</returns>
        /// <response code="200">A todo item with the provided <paramref name="id"/> if its state is set to completed.</response>
        /// <response code="404">If the todo item with the provided <paramref name="id"/> wasn't found.</response>
        [HttpPatch("{id}")]
        public async Task<ActionResult<TodoItemModel?>> SetTodoToComplete(string id)
        {
            var result = await Logic.SetTodoToCompleteAsync(id);
            return result != null ? Ok(result) : NotFound();
        }
        /// <summary>
        /// Updates the data inside of a single todo item.
        /// </summary>
        /// <param name="id">The id of the todo item in the backend</param>
        /// <param name="updateTodo">The data that is supposed to be updated in the todo item.</param>
        /// <returns>The todo item with provided and the updated data from provided update data.</returns>
        /// <response code="200">A todo item if its data was updated with provided update data.</response>
        /// <response code="404">If the todo item with the provided todo item wasn't found.</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItemModel?>> UpdateTodo(string id, TodoItemModel updateTodo)
        {
            var result = await Logic.UpdateTodoAsync(id, updateTodo);
            return result != null ? Ok(result) : NotFound();
        }
    }
}