using Epam.TaskTrackingSystem.Entities;
using System.Collections.Generic;

namespace Epam.TaskTrackingSystem.DAL.Interfaces
{
    public interface ITaskTrackingSystemDAO
    {
        // Employee methods
        IEnumerable<Employee> GetAllEmployees();
        bool Auth(string email, string password);

        string GetUserRole(string email);
        int GetUserId(string email);
        //bool IsUserInRole(string email, string roleName);

        //Task methods

        IEnumerable<Objective> GetAllTasks();
        int GetTaskId(int emp_id);
        bool HasTask(int emp_id);
        void CommitTask(int task_id);
        void CreateTask(string taskText);
        void DeleteTask(int taskID);
        void AttachTaskToEmployee(int task_id, int emp_id);
        void DetachTaskFromEmployee(int task_id, int emp_id);


    }
}
