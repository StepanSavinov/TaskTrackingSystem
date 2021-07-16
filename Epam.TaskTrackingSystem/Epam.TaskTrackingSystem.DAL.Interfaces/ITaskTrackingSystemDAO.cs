using Epam.TaskTrackingSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TaskTrackingSystem.DAL.Interfaces
{
    public interface ITaskTrackingSystemDAO
    {
        // Employee methods
        IEnumerable<Employee> GetAllEmployees();
        bool Auth(string email, string password);

        string GetUserRole(string email);
        //bool IsUserInRole(string email, string roleName);

        //Task methods

        IEnumerable<Objective> GetAllTasks();
        void AttachTaskToEmployee(int emp_id, int task_id);
        

    }
}
