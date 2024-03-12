using ToDoList.Entities;
using ToDoList.Models.InputModels;
using ToDoList.Persistence;
using ToDoList.Services.Interfaces;

namespace ToDoList.Services
{
    public class TaskService : ITaskService
    {
        private readonly ToDoListDbContext _context;

        public TaskService(ToDoListDbContext context)
        {
            _context = context;
        }

        public List<Entities.Task> GetAllTasks()
        {
            var tasks = _context.Tasks.ToList();
            return tasks;
        }

        public Entities.Task GetTaskById(int id)
        {
            var task = _context.Tasks
                .SingleOrDefault(j => j.Id == id);

            if (task is null)
            {
                throw new Exception("Tarefa não encontrada.");
            }

            return task;
        }

        public Entities.Task CreateTask(InputTask createTask)
        {
            var task = new Entities.Task(createTask.Title, createTask.Description);
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return task;
        }

        public Entities.Task? UpdateTask(int id, InputTask input)
        {
            var task = GetTaskById(id);

            task.Update(input.Title, input.Description);
            _context.SaveChanges();

            return task;
        }

        public void DeleteTask(int id)
        {
            var task = GetTaskById(id);

            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public void CompleteTask(int id)
        {
            var task = GetTaskById(id);

            task.CompleteTask();

            _context.Tasks.Update(task);
            _context.SaveChanges();
        }
    }
}
