using Microsoft.EntityFrameworkCore;
using Moq;
using ToDoList.Persistence;
using ToDoList.Services;
using ToDoList.Services.Interfaces;

namespace ToDoListTests
{
    public class Tests
    {
        [TestFixture]
        public class TaskServiceTests
        {
            private ITaskService _taskService;
            private Mock<ToDoListDbContext> _mockContext;
            private List<ToDoList.Entities.Task> _tasks;

            [SetUp]
            public void Setup()
            {
                _tasks = new List<ToDoList.Entities.Task>
            {
                new ToDoList.Entities.Task("Title 1", "Description 1"),
                new ToDoList.Entities.Task("Title 2", "Description 2"),
                new ToDoList.Entities.Task("Title 3", "Description 3")
                };

                var mockSet = new Mock<DbSet<ToDoList.Entities.Task>>();
                mockSet.As<IQueryable<ToDoList.Entities.Task>>().Setup(m => m.Provider).Returns(_tasks.AsQueryable().Provider);
                mockSet.As<IQueryable<ToDoList.Entities.Task>>().Setup(m => m.Expression).Returns(_tasks.AsQueryable().Expression);
                mockSet.As<IQueryable<ToDoList.Entities.Task>>().Setup(m => m.ElementType).Returns(_tasks.AsQueryable().ElementType);
                mockSet.As<IQueryable<ToDoList.Entities.Task>>().Setup(m => m.GetEnumerator()).Returns(_tasks.AsQueryable().GetEnumerator());

                _mockContext = new Mock<ToDoListDbContext>();
                _mockContext.Setup(c => c.Tasks).Returns(mockSet.Object);

                _taskService = new TaskService(_mockContext.Object);
            }

            [Test]
            public void GetTaskById_NonExistingId_ThrowsException()
            {
                // Arrange
                int id = 99;

                // Act & Assert
                Assert.Throws<Exception>(() => _taskService.GetTaskById(id));
            }

        }
    }
}