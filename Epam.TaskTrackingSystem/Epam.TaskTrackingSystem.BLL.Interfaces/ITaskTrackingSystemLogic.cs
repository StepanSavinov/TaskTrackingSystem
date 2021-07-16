using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TaskTrackingSystem.BLL.Interfaces
{
    public interface ITaskTrackingSystemLogic
    {
        bool SignIn(string email, string password);
        string GetUserRole(string email);
        //bool IsUserInRole(string email, string roleName);
    }
}
