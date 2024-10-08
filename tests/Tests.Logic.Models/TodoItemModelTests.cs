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
        public void TodoListItemHasNotNullableId()
        {
            // Act & Assert
            Assert.That(_todoListItemToTest.Id, Is.Not.Null);
        }
        /// <summary>
        /// Tests if <see cref="TodoItemModel.Id"/> has a length of 4 after the <see cref="TodoItemModel"/> creation.
        /// </summary>
        [Test]
        public void TodoListItemsIdLengthEquals4()
        {
            // Act & Assert
            Assert.That(_todoListItemToTest.Id, Has.Length.EqualTo(4));
        }
        /// <summary>
        /// Tests if <see cref="TodoItemModel.Id"/> is unique after <see cref="TodoItemModel"/> creation.
        /// </summary>
        [Test]
        public void TodoListItemHasUniqueId()
        {
            // Arrange
            var newTodoListItem = new TodoItemModel();
            // Assert &
            Assert.That(newTodoListItem.Id, Is.Not.EqualTo(_todoListItemToTest.Id));
        }
        /// <summary>
        /// Tests if the <see cref=TodoItemModel.Title""/>, <see cref="TodoItemModel.Description"/>, <see cref="TodoItemModel.DueTime"/> and <see cref="TodoItemModel.CompletedAt"/>  of <see cref="TodoItemModel"/> can be set properly.
        /// </summary>
        [Test]
        public void TodoListItemPropertiesAreSetRight()
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
        public void TodoListItemCreationTimeIsNow()
        {
            // Arrange
            var dateNow = DateTimeOffset.Now;
            // Act & Assert
            Assert.That(_todoListItemToTest.CreatedAt, Is.EqualTo(dateNow).Within(TimeSpan.FromSeconds(1)));
        }
        /// <summary>
        /// Test if <see cref="TodoItemModel"/> properties <see cref="TodoItemModel.Title"/>, <see cref="TodoItemModel.Description"/> and <see cref="TodoItemModel.CompletedAt"/> are set to null after <see cref="TodoItemModel"/> creation.
        /// </summary>
        [Test]
        public void TodoListItemPropertiesAreSetToNullAfterCreation()
        {
            // Assert & Act
            Assert.Multiple(() =>
            {
                Assert.That(_todoListItemToTest.Title, Is.Null);
                Assert.That(_todoListItemToTest.Description, Is.Null);
                Assert.That(_todoListItemToTest.CompletedAt, Is.Null);
            });
        }
        /// <summary>
        /// Tests if <see cref="TodoItemModel.DueTime"/> is automatically set to <see cref="DateTimeOffset"/> after <see cref="TodoItemModel"/> creation.
        /// </summary>
        [Test]
        public void TodoListItemDueAtIsSetToNewDatetimeOffsetAfterCreation()
        {
            // Assert & Act
            Assert.That(_todoListItemToTest.DueTime, Is.EqualTo(new DateTimeOffset()));
        }
        /// <summary>
        /// A simple model placeholder for providing unit test operations on <see cref="TodoItemModel"/>
        /// </summary>
        private TodoItemModel _todoListItemToTest;
    }
}
