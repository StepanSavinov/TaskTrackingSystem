namespace Epam.TaskTrackingSystem.Entities
{
    public class Employee
    {
        public Employee(int id, string email, string password, string role, int? task_id, string firstname, string lastname)
        {
            Id = id;
            Email = email;
            Password = password;
            Role = role;
            Task_Id = task_id;
            Firstname = firstname;
            Lastname = lastname;
        }
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public int? Task_Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
    }
}
