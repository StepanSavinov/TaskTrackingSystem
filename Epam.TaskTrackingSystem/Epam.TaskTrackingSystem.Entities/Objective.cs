namespace Epam.TaskTrackingSystem.Entities
{
    public class Objective
    {
        public Objective(int id, int? emp_id, string objective, bool isCompleted)
        {
            Id = id;
            Employee_Id = emp_id;
            TaskText = objective;
            IsCompleted = isCompleted;
        }
        public int Id { get; private set; }
        public int? Employee_Id { get; private set; }
        public string TaskText { get; private set; }
        public bool IsCompleted { get; private set; }
    }
}
