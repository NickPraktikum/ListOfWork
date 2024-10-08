namespace devdeer.ListOfWork.Tests.Logic.Core
{
    using devdeer.ListOfWork.Logic.Common.Exceptions;
    using devdeer.ListOfWork.Logic.Core;
    using devdeer.ListOfWork.Logic.Interfaces;
    using devdeer.ListOfWork.Logic.Models;
    using devdeer.ListOfWork.Repositories.Interfaces;
    using System;
    using System.Data;

    /// <summary>
    /// Provides unit tests for the type <see cref="TodoListLogic" />.
    /// </summary>
    public class TodoListLogicTest
    {
        #region member vars

        /// <summary>
        /// A simple model placeholder for providing unit test operations on <see cref="TodoListLogic"/>
        /// </summary>
        private IEnumerable<TodoItemModel>? _testTodoItems;

        #endregion

        #region methods

        /// <summary>
        ///  Tests if <see cref="TodoListLogic.CreateTodoAsync" /> raises an exception when non-valid <see cref="TodoItemModel.Title"/> is provided. <see cref="TodoItemModel.Title"/> has to be a valid string without empty spaces or  be <c>null</c>.
        /// </summary>
        [Test]
        public void CreateTodoRequiresValidTitle()
        {
            // Arrange
            var logic = LogicToTest;
            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = string.Empty, Description = "Description", DueTime = DateTimeOffset.UtcNow.AddDays(5) }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = null!, Description = "Description", DueTime = DateTimeOffset.UtcNow.AddDays(5) }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = new string(' ', 1), Description = "Description", DueTime = DateTimeOffset.UtcNow.AddDays(5) }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = new string(' ', 2), Description = "Description", DueTime = DateTimeOffset.UtcNow.AddDays(5) }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = new string(' ', 10), Description = "Description", DueTime = DateTimeOffset.UtcNow.AddDays(5) }));
                Assert.DoesNotThrowAsync(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Valid title", Description = "Description", DueTime = DateTimeOffset.UtcNow.AddDays(5)}));
            });
        }

        /// <summary>
        ///  Tests if <see cref="TodoListLogic.CreateTodoAsync" /> raises an exception when non-valid <see cref="TodoItemModel.Description"/> is provided. <see cref="TodoItemModel.Description"/> has to be a valid <see cref="string"/> without empty spaces or  be <c>null</c>.
        /// </summary>
        [Test]
        public void CreateTodoRequiresValidDescription()
        {
            // Arrange
            var logic = LogicToTest;
            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = string.Empty, DueTime = DateTimeOffset.UtcNow.AddDays(5) }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = null!, DueTime = DateTimeOffset.UtcNow.AddDays(5) }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = new string(' ', 1), DueTime = DateTimeOffset.UtcNow.AddDays(5) }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = new string(' ', 2), DueTime = DateTimeOffset.UtcNow.AddDays(5) }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = new string(' ', 10), DueTime = DateTimeOffset.UtcNow.AddDays(5) }));
                Assert.DoesNotThrowAsync(() => logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = "Valid Description", DueTime = DateTimeOffset.UtcNow.AddDays(5) }));
            });
        }
        /// <summary>
        /// Tests if <see cref="TodoListLogic.CreateTodoAsync" /> raises an exception when non-valid <see cref="TodoItemModel.DueTime"/> is provided. <see cref="TodoItemModel.DueTime"/> has to be a <see cref="DateTimeOffset"/> that is bigger and not equal to <see cref="TodoItemModel.CreatedAt"/>.
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
                    logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = "Valid Description", DueTime = DateTimeOffset.UtcNow }));
                Assert.ThrowsAsync<ArgumentException>(() =>
                    logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = "Valid Description", DueTime = DateTimeOffset.UtcNow.AddDays(-5) }));
                Assert.DoesNotThrowAsync(() =>
                    logic.CreateTodoAsync(new CreateTodoItemModel { Title = "Title", Description = "Valid Description", DueTime = DateTimeOffset.UtcNow.AddDays(5) }));
            });
        }

        /// <summary>
        /// Tests if <see cref="TodoListLogic.CreateTodoAsync"/> creates a valid <see cref="TodoItemModel.Id"/>. <see cref="TodoItemModel.Id"/> has to have 4 characters and be a valid <see cref="string"/> without empty spaces or  be <c>null</c>.
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
                DueTime = DateTimeOffset.UtcNow.AddDays(5)
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
        public async Task CreateTodoAssignsProperValues()
        {
            // Arrange
            var logic = LogicToTest;
            var dueTimeDate = DateTimeOffset.UtcNow.AddDays(5);
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
                    Assert.That(result.Title, Is.EqualTo(model.Title));
                    Assert.That(result.Description, Is.EqualTo(model.Description));
                    Assert.That(result.DueTime, Is.EqualTo(dueTimeDate));
                });
        }

        /// <summary>
        /// Tests if <see cref="TodoListLogic.DeleteTodoAsync"/> requires a valid <see cref="TodoItemModel.Id"/>. <see cref="TodoItemModel.Id"/> has to have 4 characters and be a valid <see cref="string"/> without empty spaces or  be <c>null</c>.
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
        /// Tests if <see cref="TodoListLogic.GetAllTodosAsync"/> returns proper <see cref="TodoItemModel"/>s with <see cref="_testTodoItems"/> provided.
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
                Assert.That(result, Has.Length.EqualTo(_testTodoItems!.Count()));
            });
        }

        /// <summary>
        /// Tests if <see cref="TodoListLogic.GetTodoByIdAsync"/> requires a valid <see cref="TodoItemModel.Id"/>. <see cref="TodoItemModel.Id"/> has to have 4 characters and be a valid <see cref="string"/> without empty spaces or  be <c>null</c>.
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

        /// <summary>
        /// Tests if <see cref="TodoListLogic.SetTodoToCompleteAsync"/> requires a valid <see cref="TodoItemModel.Id"/>. <see cref="TodoItemModel.Id"/> has to have 4 characters and be a valid <see cref="string"/> without empty spaces or  be <c>null</c>.
        /// </summary>
        [Test]
        public void SetTodoToCompleteRequiresValidId()
        {
            // Arrange 
            var logic = LogicToTest;
            var validId = _testTodoItems!.First().Id;
            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentException>(() => logic.SetTodoToCompleteAsync(string.Empty));
                Assert.ThrowsAsync<ArgumentException>(() => logic.SetTodoToCompleteAsync(null!));
                Assert.ThrowsAsync<ArgumentException>(() => logic.SetTodoToCompleteAsync(new string(' ', 1)));
                Assert.ThrowsAsync<ArgumentException>(() => logic.SetTodoToCompleteAsync(new string(' ', 2)));
                Assert.ThrowsAsync<ArgumentException>(() => logic.SetTodoToCompleteAsync(new string(' ', 10)));
                Assert.ThrowsAsync<ArgumentException>(() => logic.SetTodoToCompleteAsync("longer than 4"));
                Assert.DoesNotThrowAsync(() => logic.SetTodoToCompleteAsync(validId));
            });
        }

        /// <summary>
        /// Tests if <see cref="TodoListLogic.SetTodoToCompleteAsync"/> can't set completed <see cref="TodoItemModel.CompletedAt"/> to completed.
        /// </summary>
        [Test]
        public void SetTodoToCompleteRequiresUnCompletedTodoItem()
        {
            // Assert
            var logic = LogicToTest;
            var completedTodoId = _testTodoItems!.Where(todo => todo.CompletedAt != null).First().Id;
            var uncompletedTodoId = _testTodoItems!.Where(todo => todo.CompletedAt == null).First().Id;
            // Act & Assert
            Assert.Multiple(() => {
                Assert.ThrowsAsync<InvalidOperationException>(() => logic.SetTodoToCompleteAsync(completedTodoId));
                Assert.DoesNotThrowAsync(() => logic.SetTodoToCompleteAsync(uncompletedTodoId));
            });
        }

        /// <summary>
        /// Tests if <see cref="TodoListLogic.SetTodoToCompleteAsync"/> requires an existing <see cref="TodoItemModel"/>.
        /// </summary>
        [Test]
        public void SetTodoToCompleteRequiresExistingTodo()
        {
            // Arrange
            var logic = LogicToTest;
            var validId = _testTodoItems!.Where(todo => todo.CompletedAt == null).First().Id;
            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<EntityNotFoundException>(() => logic.SetTodoToCompleteAsync("1111"));
                Assert.DoesNotThrowAsync(() => logic.SetTodoToCompleteAsync(validId));
            });
        }

        /// <summary>
        /// Tests if <see cref="TodoListLogic.SetTodoToCompleteAsync"/> assigns right values to the properties in <see cref="TodoItemModel"/>.
        /// </summary>
        [Test]
        public async Task SetTodoToCompleteAssignsProperValues()
        {
            // Arrange
            var logic = LogicToTest;
            var dateNow = DateTimeOffset.UtcNow;
            var validTodo = _testTodoItems!.Where(todo => todo.CompletedAt == null).First();
            // Act
            var result = await logic.SetTodoToCompleteAsync(validTodo.Id);
            // Assert
            Assert.Multiple(
                () =>
                {
                    Assert.That(result, Is.Not.Null);
                    Assert.That(result!.Title, Is.EqualTo(validTodo.Title));
                    Assert.That(result!.Description, Is.EqualTo(validTodo.Description));
                    Assert.That(result!.DueTime, Is.EqualTo(validTodo.DueTime));
                });
        }

        /// <summary>
        ///  Tests if <see cref="TodoListLogic.SetTodoToCompleteAsync"/> assigns current <see cref="DateTimeOffset.UtcNow"/> to the <see cref="TodoItemModel.CreatedAt"/> property of <see cref="TodoItemModel"/>.
        /// </summary>
        [Test]
        public async Task SetTodoToCompleteAssignsProperCompleteDate()
        {
            // Assert
            var logic = LogicToTest;
            var dateNow = DateTimeOffset.UtcNow;
            var validTodo = _testTodoItems!.Where(todo => todo.CompletedAt == null).First();
            // Act
            var result = await logic.SetTodoToCompleteAsync(validTodo.Id);
            // Assert
            Assert.Multiple(
                () =>
                {
                    Assert.That(result!.CompletedAt, Is.Not.Null);
                    Assert.That(result!.CompletedAt, Is.EqualTo(dateNow).Within(TimeSpan.FromSeconds(1)));
                });
        }

        /// <summary>
        /// Tests if <see cref="TodoListLogic.SetTodoToCompleteAsync"/> only allows to set <see cref="TodoItemModel"/> to completed only if the <see cref="TodoItemModel"/> hasn't been expired yet(<see cref="TodoItemModel.DueTime"/> is expired).
        /// </summary>
        [Test]
        public void SetTodoToCompleteRequiresValidTodos()
        {
            // Assert
            var logic = LogicToTest;
            var validTodo = _testTodoItems!.Where(todo => todo.DueTime > todo.CompletedAt).First().Id;
            var invalidTodo = _testTodoItems!.Where(todo => todo.DueTime < todo.CompletedAt).First().Id;
            // Act & Assert
            Assert.Multiple(() => {
                Assert.ThrowsAsync<InvalidOperationException>(() => logic.SetTodoToCompleteAsync(invalidTodo));
                Assert.DoesNotThrow(() => logic.SetTodoToCompleteAsync(validTodo));
            });
        }

        /// <summary>
        /// Tests if <see cref="TodoListLogic.SetTodoToCompleteAsync"/> only allows to set <see cref="TodoItemModel"/> to completed only if the <see cref="TodoItemModel"/> hasn't been expired yet(<see cref="TodoItemModel.DueTime"/> is expired).
        /// </summary>
        [Test]
        public void SetTodoToCompleteRequiresNotExpiredTodo()
        {
            // Assert
            var logic = LogicToTest;
            var dateTimeNow = DateTimeOffset.UtcNow;
            var validTodo = _testTodoItems!.Where(todo => todo.DueTime > dateTimeNow).First();
            var invalidTodo = _testTodoItems!.Where(todo => todo.DueTime < dateTimeNow).First();
            // Act & Assert
            Assert.Multiple(() => {
                Assert.ThrowsAsync<InvalidOperationException>(() => logic.SetTodoToCompleteAsync(invalidTodo.Id));
                Assert.DoesNotThrow(() => logic.SetTodoToCompleteAsync(validTodo.Id));
            });
        }

        /// <summary>
        /// Tests if <see cref="TodoListLogic.UpdateTodoAsync"/> requires a valid id for <see cref="TodoItemModel"/>. <see cref="TodoItemModel.Id"/> has to have 4 characters and be a valid <see cref="string"/> without empty spaces or <c>null</c>.
        /// </summary>
        [Test]
        public void UpdateTodoRequiresValidId()
        {
            // Arrange 
            var logic = LogicToTest;
            var validId = _testTodoItems!.First().Id;
            var updateTodo = new TodoItemModel
            {
                Title = "Update Test",
                Description = "Update Test",
                DueTime = DateTimeOffset.UtcNow.AddDays(5),
                CompletedAt = null,
            };
            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(string.Empty, updateTodo));
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(null!, updateTodo));
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(new string(' ', 1), updateTodo));
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(new string(' ', 2), updateTodo));
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(new string(' ', 10), updateTodo));
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync("longer than 4", updateTodo));
                Assert.DoesNotThrowAsync(() => logic.UpdateTodoAsync(validId, updateTodo));
            });
        }

        /// <summary>
        /// Tests if <see cref="TodoListLogic.UpdateTodoAsync"/> requires a valid title for <see cref="TodoItemModel"/>. <see cref="TodoItemModel.Title"/> has to be a valid <see cref="string"/> without empty spaces or  be <c>null</c>.
        /// </summary>
        [Test]
        public void UpdateTodoRequiresValidTitle()
        {
            // Arrange
            var logic = LogicToTest;
            var validId = _testTodoItems!.First().Id;
            // Act & Assert
            Assert.Multiple(() =>
            {
               Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(validId, new TodoItemModel {
                   Title = "Update Test",
                   Description = string.Empty,
                   DueTime = DateTimeOffset.UtcNow.AddDays(5),
                   CompletedAt = null,
               }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = "Update Test",
                    Description = null!,
                    DueTime = DateTimeOffset.UtcNow.AddDays(5),
                    CompletedAt = null,
                }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = "Update Test",
                    Description = new string(' ', 1),
                    DueTime = DateTimeOffset.UtcNow.AddDays(5),
                    CompletedAt = null,
                }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = "Update Test",
                    Description = new string(' ', 2),
                    DueTime = DateTimeOffset.UtcNow.AddDays(5),
                    CompletedAt = null,
                }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = "Update Test",
                    Description = new string(' ', 10),
                    DueTime = DateTimeOffset.UtcNow.AddDays(5),
                    CompletedAt = null,
                }));
                Assert.DoesNotThrowAsync(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = "Update Test",
                    Description = "Valid Update Test",
                    DueTime = DateTimeOffset.UtcNow.AddDays(5),
                    CompletedAt = null,
                }));
            });
        }
        /// <summary>
        /// Tests if <see cref="TodoListLogic"/> requires a valid description for <see cref="TodoItemModel"/>. <see cref="TodoItemModel.Description"/> has to be a valid <see cref="string"/> without empty spaces or  be <c>null</c>.
        /// </summary>
        [Test]
        public void UpdateTodoRequiresValidDescription()
        {
            // Arrange
            var logic = LogicToTest;
            var validId = _testTodoItems!.First().Id;
            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = string.Empty,
                    Description = "Update Test",
                    DueTime = DateTimeOffset.UtcNow.AddDays(5),
                    CompletedAt = null,
                }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = null!,
                    Description = "Update Test",
                    DueTime = DateTimeOffset.UtcNow.AddDays(5),
                    CompletedAt = null,
                }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = new string(' ', 1),
                    Description = "Update Test",
                    DueTime = DateTimeOffset.UtcNow.AddDays(5),
                    CompletedAt = null,
                }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = new string(' ', 2),
                    Description = "Update Test",
                    DueTime = DateTimeOffset.UtcNow.AddDays(5),
                    CompletedAt = null,
                }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = new string(' ', 10),
                    Description = "Update Test",
                    DueTime = DateTimeOffset.UtcNow.AddDays(5),
                    CompletedAt = null,
                }));
                Assert.DoesNotThrowAsync(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = "Valid Update Test",
                    Description = "Update Test",
                    DueTime = DateTimeOffset.UtcNow.AddDays(5),
                    CompletedAt = null,
                }));
            });
        }
        /// <summary>
        /// Tests if <see cref="TodoListLogic.UpdateTodoAsync"/> requires a valid due time for <see cref="TodoItemModel"/>. <see cref="TodoItemModel.DueTime"/> has to be a <see cref="DateTimeOffset"/> that is bigger and not equal to <see cref="TodoItemModel.CreatedAt"/>.
        /// </summary>
        [Test]
        public void UpdateTodoRequiresValidDueTime()
        {
            // Arrange
            var logic = LogicToTest;
            var validId = _testTodoItems!.First().Id;
            var dateNow = DateTimeOffset.UtcNow;
            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = "UpdateTest",
                    Description = "Update Test",
                    DueTime = dateNow,
                    CompletedAt = null,
                }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = "Update",
                    Description = "Update Test",
                    DueTime = dateNow.AddDays(-5),
                    CompletedAt = null,
                }));
                Assert.DoesNotThrowAsync(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = "Valid Update Test",
                    Description = "Update Test",
                    DueTime = dateNow.AddDays(5),
                    CompletedAt = null,
                }));
            });
        }

        /// <summary>
        /// Tests if <see cref="TodoListLogic.UpdateTodoAsync"/> requires a valid completed at date time for <see cref="TodoItemModel"/>. <see cref="TodoItemModel.CompletedAt"/> has to be smaller than <see cref="TodoItemModel.DueTime"/>.
        /// </summary>
        [Test]
        public void UpdateTodoRequiresValidCompletedAtAndDueTime()
        {
            // Arrange
            var logic = LogicToTest;
            var validId = _testTodoItems!.Where(todo => todo.CompletedAt == null).First().Id;
            var dateNow = DateTimeOffset.UtcNow;
            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = "Valid Update Test",
                    Description = "Update Test",
                    DueTime = dateNow.AddDays(3),
                    CompletedAt = dateNow.AddDays(4),
                }));
                Assert.DoesNotThrow(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = "Valid Update Test",
                    Description = "Update Test",
                    DueTime = dateNow.AddDays(5),
                    CompletedAt = dateNow,
                }));
                Assert.DoesNotThrowAsync(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = "Valid Update Test",
                    Description = "Update Test",
                    DueTime = dateNow.AddDays(5),
                    CompletedAt = dateNow.AddDays(5),
                }));
            });
        }

        /// <summary>
        /// Tests if <see cref="TodoListLogic.UpdateTodoAsync"/> requires a valid due time for <see cref="TodoItemModel"/>. <see cref="TodoItemModel.CompletedAt/> has to be a <see cref="DateTimeOffset"/> that is bigger and not equal to <see cref="TodoItemModel.CreatedAt"/>.
        /// </summary>
        [Test]
        public void UpdateTodoRequiresValidCompletedAt()
        {
            // Arrange
            var logic = LogicToTest;
            var validId = _testTodoItems!.First().Id;
            var dateNow = DateTimeOffset.UtcNow;
            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = "UpdateTest",
                    Description = "Update Test",
                    DueTime = dateNow.AddDays(5),
                    CompletedAt = dateNow,
                }));
                Assert.ThrowsAsync<ArgumentException>(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = "Update",
                    Description = "Update Test",
                    DueTime = dateNow.AddDays(5),
                    CompletedAt = dateNow.AddDays(-5),
                }));
                Assert.DoesNotThrowAsync(() => logic.UpdateTodoAsync(validId, new TodoItemModel
                {
                    Title = "Valid Update Test",
                    Description = "Update Test",
                    DueTime = dateNow.AddDays(5),
                    CompletedAt = dateNow.AddDays(5),
                }));
            });
        }

        /// <summary>
        /// Tests if <see cref="TodoListLogic.UpdateTodoAsync"/> assigns proper values for <see cref="TodoItemModel"/> that are completed or not.
        /// </summary>
        [Test]
        public async Task UpdateTodoAssignsProperValues()
        {
            // Arrange
            var logic = LogicToTest;
            var dateNow = DateTimeOffset.UtcNow;
            var validUncompletedTodo = _testTodoItems!.Where(todo => todo.CompletedAt == null).First().Id;
            var validCompletedTodo = _testTodoItems!.Where(todo => todo.CompletedAt != null).First().Id;
            var dateTime = DateTimeOffset.UtcNow;
            var updateUncompletedTodo = new TodoItemModel
            {
                Title = "Update Test",
                Description = "Update Test",
                DueTime = dateNow.AddDays(5),
                CompletedAt = null
            };
            var updateCompletedTodo = new TodoItemModel
            {
                Title = "Update Test",
                Description = "Update Test",
                DueTime = dateNow.AddDays(5),
                CompletedAt = dateNow.AddDays(4)
            };
            // Act
            var resultUncompletedTodo = await logic.UpdateTodoAsync
                (validUncompletedTodo, updateUncompletedTodo);
            var resultCompletedTodo = await logic.UpdateTodoAsync
                (validCompletedTodo, updateCompletedTodo);
            // Assert
            Assert.Multiple(
                () =>
                {
                    Assert.That(resultUncompletedTodo, Is.Not.Null);
                    Assert.That(resultUncompletedTodo!.Title, Is.EqualTo(updateUncompletedTodo.Title));
                    Assert.That(resultUncompletedTodo!.Description, Is.EqualTo(updateUncompletedTodo.Description));
                    Assert.That(resultUncompletedTodo!.DueTime, Is.EqualTo(updateUncompletedTodo.DueTime));
                    Assert.That(resultUncompletedTodo!.CompletedAt, Is.EqualTo(null));

                    Assert.That(resultCompletedTodo, Is.Not.Null);
                    Assert.That(resultCompletedTodo!.Title, Is.EqualTo(updateCompletedTodo.Title));
                    Assert.That(resultCompletedTodo!.Description, Is.EqualTo(updateCompletedTodo.Description));
                    Assert.That(resultCompletedTodo!.DueTime, Is.EqualTo(updateCompletedTodo.DueTime));
                    Assert.That(resultCompletedTodo!.CompletedAt, Is.EqualTo(dateNow.AddDays(4)));
                });
        }

        /// <summary>
        /// This method runs before any unit test is running. Creates new <see cref="TodoItemModel"/> for tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _testTodoItems =
            [
                new()
                {
                    Title = "Test",
                    Description = "Test",
                    DueTime = DateTimeOffset.UtcNow.AddDays(5),
                    CompletedAt = null,
                },
                new()
                {
                    Title = "Test",
                    Description = "Test",
                    DueTime = DateTimeOffset.UtcNow.AddDays(5),
                    CompletedAt = DateTimeOffset.UtcNow,
                },
                new()
                {
                    Title = "Test",
                    Description = "Test",
                    DueTime = DateTimeOffset.UtcNow.AddDays(-5),
                    CompletedAt = null,
                },
                new()
                {
                    Title = "Test",
                    Description = "Test",
                    DueTime = DateTimeOffset.UtcNow.AddDays(-5),
                    CompletedAt = DateTimeOffset.UtcNow,
                }
            ];
        }

        /// <summary>
        /// Retrieves a fresh unit test todo list repository.
        /// </summary>
        /// <returns>The instance to use.</returns>
        private ITodoListRepository GetRepository()
        {
            return TodoListTestRepository.Create(_testTodoItems!);
        }

        #endregion

        #region properties

        /// <summary>
        /// Can be used internally to retrieve a fresh ready-to-use and configured instance of the logic to test.
        /// </summary>
        private ITodoListLogic LogicToTest => new TodoListLogic(GetRepository());

        #endregion
    }
}
