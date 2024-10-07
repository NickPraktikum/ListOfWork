using devdeer.ListOfWork.Logic.Models;

namespace devdeer.ListOfWork.Tests.Logic.Models
{
    /// <summary>
    /// Provides unit tests for the model <see cref="TodoItemModel" />.
    /// </summary>
    [TestFixture]
    public class TodoItemModelTests
    {
        /// <summary>
        /// This method runs before any unit test is running.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _todoListItemToTest = new TodoItemModel();
        }
        /// <summary>
        /// Tests if <see cref="TodoItemModel.Id"/> isn't set to null after the <see cref="TodoItemModel"/> creation.
        /// </summary>
        [Test]
        public void TodoListItem_Has_Not_Nullable_Id()
        {
            // Act & Assert
            Assert.That(_todoListItemToTest.Id, Is.Not.Null);
        }
        /// <summary>
        /// Tests if <see cref="TodoItemModel.Id"/> has a length of 4 after the <see cref="TodoItemModel"/> creation.
        /// </summary>
        [Test]
        public void TodoListItemsIdLength_Equals_4()
        {
            // Act & Assert
            Assert.That(_todoListItemToTest.Id, Has.Length.EqualTo(4));
        }
        /// <summary>
        /// Tests if <see cref="TodoItemModel.Id"/> is unique after <see cref="TodoItemModel"/> creation.
        /// </summary>
        [Test]
        public void TodoListItem_Has_Unique_Id()
        {
            // Arrange
            var newTodoListItem = new TodoItemModel();
            // Assert &
            Assert.That(newTodoListItem.Id, Is.Not.EqualTo(_todoListItemToTest.Id));
        }
        /// <summary>
        /// Tests if the properties of <see cref="TodoItemModel"/> can be set properly.
        /// </summary>
        [Test]
        public void TodoListItem_Properties_Are_Set_Right()
        {
            // Arrange
            var title = "New Title";
            var description = "Description";
            var dueTime = new DateTimeOffset();
            var completedAt = new DateTimeOffset();
            // Act
            _todoListItemToTest.Title = title;
            _todoListItemToTest.Description = description;
            _todoListItemToTest.DueTime = dueTime;
            _todoListItemToTest.CompletedAt = completedAt;
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(_todoListItemToTest.Title, Is.EqualTo(title));
                Assert.That(_todoListItemToTest.Description, Is.EqualTo(description));
                Assert.That(_todoListItemToTest.DueTime, Is.EqualTo(dueTime));
                Assert.That(_todoListItemToTest.CompletedAt, Is.EqualTo(completedAt));
            });
        }
        /// <summary>
        /// Test if <see cref="TodoItemModel.CreatedAt"/> is automatically set to time at the moment of creation.
        /// </summary>
        [Test]
        public void TodoListItem_CreationTime_Is_Now()
        {
            // Arrange
            var dateNow = DateTimeOffset.Now;
            // Act & Assert
            Assert.That(_todoListItemToTest.CreatedAt, Is.EqualTo(dateNow).Within(TimeSpan.FromSeconds(1)));
        }
        /// <summary>
        /// Test if <see cref="TodoItemModel.CompletedAt"/> is set to <c>null</c> after <see cref="TodoItemModel"/> creation.
        /// </summary>
        [Test]
        public void TodoListItem_CompletedAt_Is_Null_After_Creation()
        {
            // Act & Assert
            Assert.That(_todoListItemToTest.CompletedAt, Is.Null);
        }
        private TodoItemModel _todoListItemToTest;
    }
}
