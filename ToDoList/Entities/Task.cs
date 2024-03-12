namespace ToDoList.Entities
{
    public class Task
    {
        public Task(string title, string description)
        {
            Title = title;
            Description = description;
            IsCompleted = false;
        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public bool IsCompleted { get; private set; }

        public void Update(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public void CompleteTask()
        {
            IsCompleted = true;
        }
    }
}
