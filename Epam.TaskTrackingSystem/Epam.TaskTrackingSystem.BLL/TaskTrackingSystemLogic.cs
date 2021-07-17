using Epam.TaskTrackingSystem.BLL.Interfaces;
using Epam.TaskTrackingSystem.DAL.Interfaces;
using Epam.TaskTrackingSystem.Entities;
using System.Collections.Generic;

namespace Epam.TaskTrackingSystem.BLL
{
    public class TaskTrackingSystemLogic : ITaskTrackingSystemLogic
    {
        private ITaskTrackingSystemDAO _taskTrackingSystemDAO;

        public TaskTrackingSystemLogic(ITaskTrackingSystemDAO taskTrackingSystemDAO)
        {
            _taskTrackingSystemDAO = taskTrackingSystemDAO;
        }

        //Users

        public bool SignIn(string email, string password)
        {
            return _taskTrackingSystemDAO.Auth(email, password);
        }

        public string GetUserRole(string email)
        {
            return _taskTrackingSystemDAO.GetUserRole(email);
        }

        public int GetUserId(string email)
        {
            return _taskTrackingSystemDAO.GetUserId(email);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _taskTrackingSystemDAO.GetAllEmployees();
        }

        // Tasks

        public IEnumerable<Objective> GetObjectives()
        {
            return _taskTrackingSystemDAO.GetAllTasks();
        }

        public int GetTaskId(int emp_id)
        {
            return _taskTrackingSystemDAO.GetTaskId(emp_id);
        }

        public bool HasTask(int emp_id)
        {
            return _taskTrackingSystemDAO.HasTask(emp_id);
        }

        public void CommitTask(int task_id)
        {
            _taskTrackingSystemDAO.CommitTask(task_id);
        }

        public void CreateTask(string taskText)
        {
            _taskTrackingSystemDAO.CreateTask(taskText);
        }

        public void DeleteTask(int taskID)
        {
            _taskTrackingSystemDAO.DeleteTask(taskID);
        }

        public void AttachTaskToEmployee(int taskID, int empID)
        {
            _taskTrackingSystemDAO.AttachTaskToEmployee(taskID, empID);
        }

        public void DetachTaskFromEmployee(int taskID, int empID)
        {
            _taskTrackingSystemDAO.DetachTaskFromEmployee(taskID, empID);
        }
    }
}
