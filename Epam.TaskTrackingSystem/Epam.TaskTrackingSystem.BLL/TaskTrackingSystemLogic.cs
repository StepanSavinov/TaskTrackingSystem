using Epam.TaskTrackingSystem.BLL.Interfaces;
using Epam.TaskTrackingSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TaskTrackingSystem.BLL
{
    public class TaskTrackingSystemLogic : ITaskTrackingSystemLogic
    {
        private ITaskTrackingSystemDAO _taskTrackingSystemDAO;

        public TaskTrackingSystemLogic(ITaskTrackingSystemDAO taskTrackingSystemDAO)
        {
            _taskTrackingSystemDAO = taskTrackingSystemDAO;
        }

        public bool SignIn(string email, string password)
        {
            return _taskTrackingSystemDAO.Auth(email, password);
        }

        public string GetUserRole(string email)
        {
            return _taskTrackingSystemDAO.GetUserRole(email);
        }

        //public bool IsUserInRole(string email, string roleName)
        //{
        //    return _taskTrackingSystemDAO.IsUserInRole(email, roleName);
        //}

    }
}
