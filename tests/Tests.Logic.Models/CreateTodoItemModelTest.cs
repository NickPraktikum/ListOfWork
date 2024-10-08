namespace devdeer.ListOfWork.Tests.Logic.Models
{
    using ListOfWork.Logic.Models;

    /// <summary>
    /// Provides unit tests for the model <see cref="CreateTodoItemModel" />.
    /// </summary>
    [TestFixture]
    public class CreateTodoItemModelTest
    {
        #region member vars

        /// <summary>
        /// A simple model placeholder for providing test operations on <see cref="CreateTodoItemModel" />
        /// </summary>
        private CreateTodoItemModel _todoListItemToTest;

        #endregion

        #region methods

        /// <summary>
        /// Tests if the <see cref="CreateTodoItemModel.Title" />, <see cref="CreateTodoItemModel.Description" /> and
        /// <see cref="CreateTodoItemModel.DueTime" /> properties of <see cref="CreateTodoItemModel" /> can be set properly.
        /// </summary>
        [Test]
        public void CreateTodoListItemPropertiesAreSetRight()
        {
            // Arrange
            var title = "New Title";
            var description = "Description";
            var dueTime = new DateTimeOffset();
            // Act
            _todoListItemToTest.Title = title;
            _todoListItemToTest.Description = description;
            _todoListItemToTest.DueTime = dueTime;
            // Assert
            Assert.Multiple(
                () =>
                {
                    Assert.That(_todoListItemToTest.Title, Is.EqualTo(title));
                    Assert.That(_todoListItemToTest.Description, Is.EqualTo(description));
                    Assert.That(_todoListItemToTest.DueTime, Is.EqualTo(dueTime));
                });
        }

        /// <summary>
        /// Test if <see cref="CreateTodoItemModel" /> properties <see cref="CreateTodoItemModel.Title" /> and
        /// <see cref="CreateTodoItemModel.Description" /> are set to null after <see cref="CreateTodoItemModel" /> creation.
        /// </summary>
        [Test]
        public void CreateTodoListItemPropertiesAreSetToNullAfterCreation()
        {
            // Assert & Act
            Assert.Multiple(
                () =>
                {
                    Assert.That(_todoListItemToTest.Title, Is.Null);
                    Assert.That(_todoListItemToTest.Description, Is.Null);
                });
        }

        /// <summary>
        /// Tests if <see cref="CreateTodoItemModel.DueTime" /> is automatically set to <see cref="DateTimeOffset" /> after
        /// <see cref="CreateTodoItemModel" /> creation.
        /// </summary>
        [Test]
        public void CreateTodoListItemDueAtIsSetToNewDatetimeOffsetAfterCreation()
        {
            // Assert & Act
            Assert.That(_todoListItemToTest.DueTime, Is.EqualTo(new DateTimeOffset()));
        }

        /// <summary>
        /// This method runs before any unit test is running.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _todoListItemToTest = new CreateTodoItemModel();
        }

        #endregion
    }
}