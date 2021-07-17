using Epam.TaskTrackingSystem.BLL;
using Epam.TaskTrackingSystem.BLL.Interfaces;
using Epam.TaskTrackingSystem.DAL.Interfaces;
using Epam.TaskTrackingSystem.SqlDAO;

namespace Epam.TaskTrackingSystem.DependencyResolver
{
    public class DependenciesResolver
    {
        private static DependenciesResolver _instance;
        public static DependenciesResolver Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new DependenciesResolver();
                }

                return _instance;
            }
        }

        public ITaskTrackingSystemDAO TaskTrackingSystemDAO => new SqlDAL();
        public ITaskTrackingSystemLogic TaskTrackingSystemLogic => new TaskTrackingSystemLogic(TaskTrackingSystemDAO);
        
    }
}
