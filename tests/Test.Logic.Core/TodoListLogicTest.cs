﻿namespace devdeer.ListOfWork.Tests.Logic.Core
{
    using devdeer.ListOfWork.Logic.Common.Exceptions;
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
                    CompletedAt = null,
                },
                new()
                {
                    Title = "Test",
                    Description = "Test",
                    DueTime = DateTime.Now,
                    CompletedAt = DateTime.Now,
                }
            ];
        }
        /// <summary>
        ///  Tests if <see cref="TodoListLogic.CreateTodoAsync" /> raises an exception when non-valid title is provided.
        /// </summary>
        [Test]
        public void CreateTodoRequiresValidTitle()
        {
            // Arrange
            var logic = LogicToTest;
            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = string.Empty, Description = "Description", DueTime = DateTimeOffset.Now.AddDays(5) }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = null!, Description = "Description", DueTime = DateTimeOffset.Now.AddDays(5) }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = new string(' ', 1), Description = "Description", DueTime = DateTimeOffset.Now.AddDays(5) }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = new string(' ', 2), Description = "Description", DueTime = DateTimeOffset.Now.AddDays(5) }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = new string(' ', 10), Description = "Description", DueTime = DateTimeOffset.Now.AddDays(5) }));
                Assert.DoesNotThrowAsync(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Valid title", Description = "Description", DueTime = DateTimeOffset.Now.AddDays(5)}));
            });
        }
        /// <summary>
        ///  Tests if <see cref="TodoListLogic.CreateTodoAsync" /> raises an exception when non-valid description is provided.
        /// </summary>
        [Test]
        public void CreateTodoRequiresValidDescription()
        {
            // Arrange
            var logic = LogicToTest;
            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = string.Empty, DueTime = DateTimeOffset.Now.AddDays(5) }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = null!, DueTime = DateTimeOffset.Now.AddDays(5) }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = new string(' ', 1), DueTime = DateTimeOffset.Now.AddDays(5) }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = new string(' ', 2), DueTime = DateTimeOffset.Now.AddDays(5) }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = new string(' ', 10), DueTime = DateTimeOffset.Now.AddDays(5) }));
                Assert.DoesNotThrowAsync(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = "Valid Description", DueTime = DateTimeOffset.Now.AddDays(5) }));
            });
        }
        /// <summary>
        /// Tests if <see cref="TodoListLogic.CreateTodoAsync" /> raises an exception when non-valid DueTime is provided.
        /// </summary>
        [Test]
        public void CreateTodoRequiresValidDueTime()
        {
            // Arrange
            var logic = LogicToTest;
            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentException>(() =>
                    logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = "Valid Description", DueTime = DateTimeOffset.Now }));
                Assert.ThrowsAsync<ArgumentException>(() =>
                    logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = "Valid Description", DueTime = DateTimeOffset.Now.AddDays(-5) }));
                Assert.DoesNotThrowAsync(() =>
                    logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = "Valid Description", DueTime = DateTimeOffset.Now.AddDays(5) }));
            });
        }
        /// <summary>
        /// Tests if <see cref="TodoListLogic.CreateTodoAsync"/> creates a valid id.
        /// </summary>
        [Test]
        public async Task CreateTodoCreatesValidItemId()
        {
            // Arrange
            var logic = LogicToTest;
            var model = new CreateTodoItemModel
            {
                Title = "Title",
                Description = "Description",
                DueTime = DateTimeOffset.Now.AddDays(5)
            };
            // Act
            var result = await logic.CreateTodoAsync(model);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(
                () =>
                {
                    Assert.That(result!.Id, Is.Not.EqualTo(null));
                    Assert.That(result!.Id, Is.Not.EqualTo(string.Empty));
                    Assert.That(result!.Id, Is.Not.EqualTo(new string(' ',1)));
                    Assert.That(result!.Id, Is.Not.EqualTo(new string(' ', 2)));
                    Assert.That(result!.Id, Is.Not.EqualTo(new string(' ', 10)));
                    Assert.That(result!.Id, Has.Length.EqualTo(4));
                });
        }
        /// <summary>
        /// Tests if <see cref="TodoListLogic.CreateTodoAsync"/> assigns right values to the properties in <see cref="TodoItemModel"/>.
        /// </summary>
        [Test]
        public async Task CreateTodoAssignProperValues()
        {
            // Arrange
            var logic = LogicToTest;
            var dueTimeDate = DateTimeOffset.Now.AddDays(5);
            var model = new CreateTodoItemModel { 
                Title = "Title", 
                Description = "Description", 
                DueTime = dueTimeDate };
            // Act
            var result = await logic.CreateTodoAsync(model);
            // Assert
            Assert.Multiple(
                () =>
                {
                    Assert.That(result, Is.Not.Null);
                    Assert.That(result.Title, Is.EqualTo("Title"));
                    Assert.That(result.Description, Is.EqualTo("Description"));
                    Assert.That(result.DueTime, Is.EqualTo(dueTimeDate));
                });
        }
        /// <summary>
        /// Tests if <see cref="TodoListLogic.DeleteTodoAsync"/> requires a valid id.
        /// </summary>
        [Test]
        public void DeleteTodoRequiresValidId()
        {
            // Arrange
            var logic = LogicToTest;
            var validId = _testTodoItems!.First().Id;
            // Act & Assert
            Assert.Multiple(() =>
            {
            Assert.ThrowsAsync<ArgumentException>(() => logic.DeleteTodoAsync(string.Empty));
            Assert.ThrowsAsync<ArgumentException>(() => logic.DeleteTodoAsync(null!));
            Assert.ThrowsAsync<ArgumentException>(() => logic.DeleteTodoAsync(new string(' ', 1)));
            Assert.ThrowsAsync<ArgumentException>(() => logic.DeleteTodoAsync(new string(' ', 2)));
            Assert.ThrowsAsync<ArgumentException>(() => logic.DeleteTodoAsync(new string(' ', 10)));
            Assert.ThrowsAsync<ArgumentException>(() => logic.DeleteTodoAsync("longer than 4"));
                Assert.DoesNotThrowAsync(() => logic.DeleteTodoAsync(validId));
            });
        }
        /// <summary>
        /// Tests if <see cref="TodoListLogic.DeleteTodoAsync"/> requires an existing <see cref="TodoItemModel"/>.
        /// </summary>
        [Test]
        public void DeletedTodoRequiresExistingTodo()
        {
            // Arrange
            var logic = LogicToTest;
            var validId = _testTodoItems!.First().Id;
            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<EntityNotFoundException>(() => logic.DeleteTodoAsync("1111"));
                Assert.DoesNotThrowAsync(() => logic.DeleteTodoAsync(validId));
            });
        }
        /// <summary>
        /// Tests if <see cref="TodoListLogic.DeleteTodoAsync"/> returns <c>true</c> after successful <see cref="TodoItemModel"/> deletion.
        /// </summary>
        [Test]
        public async Task DeleteTodoReturnsTrueIfDeletedSuccessfully()
        {
            // Arrange
            var logic = LogicToTest;
            var validId = _testTodoItems!.First().Id;
            // Act
            var result = await logic.DeleteTodoAsync(validId);
            // Assert
            Assert.That(result, Is.EqualTo(true));
        }

        /// <summary>
        /// Tests if <see cref="TodoListLogic.GetAllTodosAsync"/> returns proper values with <see cref="_testTodoItems"/> provided
        /// </summary>
        [Test]
        public async Task GetAllTodosReturnsProperValues()
        {
            // Assert
            var logic = LogicToTest;
            // Act
            var result = (await logic.GetAllTodosAsync()).ToArray();
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Any(), Is.True);
                Assert.That(result.Length, Is.EqualTo(2));
            });
        }
        /// <summary>
        /// Tests if <see cref="TodoListLogic.GetTodoByIdAsync"/> requires a valid id.
        /// </summary>
        [Test]
        public void GetTodoByIdRequiresValidId()
        {
            // Arrange 
            var logic = LogicToTest;
            var validId = _testTodoItems!.First().Id;
            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentException>(() => logic.GetTodoByIdAsync(string.Empty));
                Assert.ThrowsAsync<ArgumentException>(() => logic.GetTodoByIdAsync(null!));
                Assert.ThrowsAsync<ArgumentException>(() => logic.GetTodoByIdAsync(new string(' ', 1)));
                Assert.ThrowsAsync<ArgumentException>(() => logic.GetTodoByIdAsync(new string(' ', 2)));
                Assert.ThrowsAsync<ArgumentException>(() => logic.GetTodoByIdAsync(new string(' ', 10)));
                Assert.ThrowsAsync<ArgumentException>(() => logic.GetTodoByIdAsync("longer than 4"));
                Assert.DoesNotThrowAsync(() => logic.GetTodoByIdAsync(validId));
            });
        }
        /// <summary>
        /// Tests if <see cref="TodoListLogic.GetTodoByIdAsync"/> returns a <see cref="TodoItemModel"/> if it's found in the backend or <c>null</c> otherwise.
        /// </summary>
        [Test]
        public async Task GetTodoByIdReturnsNullIfTodoItemNotFound()
        {
            // Assert
            var logic = LogicToTest;
            var wrongId = "1111";
            var rightId = _testTodoItems!.First().Id;
            // Act 
            var wrongResult = await logic.GetTodoByIdAsync(wrongId);
            var rightResult = await logic.GetTodoByIdAsync(rightId);
            Assert.Multiple(() => {
                Assert.That(wrongResult, Is.Null);
                Assert.That(rightResult, Is.Not.Null);
            });
        }
        private ITodoListRepository GetRepository()
        {
            return TodoListTestRepository.Create(_testTodoItems!);
        }
        private ITodoListLogic LogicToTest => new TodoListLogic(GetRepository());

    }
}
