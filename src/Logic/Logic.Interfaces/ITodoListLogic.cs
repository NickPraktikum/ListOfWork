using devdeer.ListOfWork.Logic.Models;

namespace devdeer.ListOfWork.Logic.Interfaces
{
    public interface ITodoListLogic
    {
        TodoItemModel CreateTodo(CreateTodoItemModel todoItem);
    }
}
