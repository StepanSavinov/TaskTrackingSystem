using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TaskTrackingSystem.Entities
{
    public class Employee
    {
        public Employee(int id, string email, string password, string role, int task_id)
        {
            Id = id;
            Email = email;
            Password = password;
            Role = role;
            Task_Id = task_id;
        }
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public int Task_Id { get; private set; }
    }
}
