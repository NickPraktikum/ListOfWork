namespace devdeer.ListOfWork.Tests.Logic.Core
{
    using devdeer.ListOfWork.Logic.Core;
    using devdeer.ListOfWork.Logic.Interfaces;
    using devdeer.ListOfWork.Logic.Models;
    using devdeer.ListOfWork.Repositories.Interfaces;
    public class TodoListLogicTest
    {
        private IEnumerable<TodoItemModel>? _testTodoItems;
        [SetUp]
        public void Setup()
        {
            _testTodoItems =
            [
                new()
                {
                    Title = "Test",
                    Description = "Test",
                    DueTime = DateTime.Now,
                    CompletedAt = DateTime.Now,
                }
            ];
        }
        [Test]
        public void Test()
        {
        }
        private ITodoListRepository GetRepository()
        {
            return TodoListTestRepository.Create(_testTodoItems!);
        }
        private ITodoListLogic LogicToTest => new TodoListLogic(GetRepository());

    }
}
