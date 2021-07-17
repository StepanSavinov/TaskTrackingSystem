using Epam.TaskTrackingSystem.Entities;
using System.Collections.Generic;

namespace Epam.TaskTrackingSystem.BLL.Interfaces
{
    public interface ITaskTrackingSystemLogic
    {
        // Users

        bool SignIn(string email, string password);
        string GetUserRole(string email);
        int GetUserId(string email);
        IEnumerable<Employee> GetEmployees();

        // Tasks

        IEnumerable<Objective> GetObjectives();
        int GetTaskId(int emp_id);
        bool HasTask(int emp_id);
        void CommitTask(int task_id);
        void CreateTask(string taskText);
        void DeleteTask(int taskID);
        void AttachTaskToEmployee(int taskID, int empID);
        void DetachTaskFromEmployee(int taskID, int empID);
    }
}
