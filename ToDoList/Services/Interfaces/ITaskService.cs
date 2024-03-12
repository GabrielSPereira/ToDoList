using ToDoList.Models.InputModels;

namespace ToDoList.Services.Interfaces
{
    public interface ITaskService
    {
        List<Entities.Task> GetAllTasks();
        Entities.Task GetTaskById(int id);
        Entities.Task CreateTask(InputTask createTask);
        Entities.Task? UpdateTask(int id, InputTask input);
        void DeleteTask(int id);
        void CompleteTask(int id);
    }

}
