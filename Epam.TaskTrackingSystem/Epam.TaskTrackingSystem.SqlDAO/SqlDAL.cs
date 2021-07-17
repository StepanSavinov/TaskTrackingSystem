using Epam.TaskTrackingSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Epam.TaskTrackingSystem.Entities;

namespace Epam.TaskTrackingSystem.SqlDAO
{
    public class SqlDAL : ITaskTrackingSystemDAO
    {
        private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TaskTrackingSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static SqlConnection _connection = new SqlConnection(_connectionString);

        public bool Auth(string email, string password)
        {
            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _connection.Open();
                SqlCommand logIn = new SqlCommand("SELECT * FROM Employee", _connection);
                var reader = logIn.ExecuteReader();

                while (reader.Read())
                {
                    if (email.Equals(reader["email"].ToString()) && password.Equals(reader["password"].ToString()))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public string GetUserRole(string email)
        {
            string role = "";
            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _connection.Open();

                SqlCommand getUserRole = new SqlCommand("select role from employee where email = @Email", _connection);
                getUserRole.Parameters.Add(new SqlParameter("@Email", email));

                var reader = getUserRole.ExecuteReader();
                while (reader.Read())
                {
                    role += reader["role"].ToString();
                }

                return role;
            }
        }

        public int GetUserId(string email)
        {
            int id = 0;
            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _connection.Open();

                SqlCommand getUserId = new SqlCommand("select id from employee where email = @Email", _connection);
                getUserId.Parameters.Add(new SqlParameter("@Email", email));

                var reader = getUserId.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["id"]);
                }

                return id;
            }

        }

        //public bool IsUserInRole(string email, string roleName)
        //{
        //    using (_connection)
        //    {
        //        _connection.ConnectionString = _connectionString;
        //        _connection.Open();
        //        SqlCommand getUserRole = new SqlCommand("SELECT * FROM Employee");
        //        var reader = getUserRole.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            if (email.Equals(reader["email"].ToString()))
        //            {

        //            }
        //        }
        //    }
        //}

        public bool IsUserInRole(string email, string roleName)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _connection.Open();
                SqlCommand getAllEmps = new SqlCommand("select * from Employee", _connection);
                var reader = getAllEmps.ExecuteReader();
                var emps = new List<Employee>();

                while (reader.Read())
                {
                    emps.Add(new Employee(
                        id: (int)reader["Id"],
                        email: reader["Email"] as string,
                        password: reader["Password"] as string,
                        role: reader["Role"] as string,
                        task_id: reader["Task_Id"] as int?,
                        firstname: reader["Firstname"] as string,
                        lastname: reader["Lastname"] as string
                    ));
                }

                return emps;
            }
        }

        //Tasks
        public IEnumerable<Objective> GetAllTasks()
        {
            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _connection.Open();
                SqlCommand getAllTasks = new SqlCommand("SELECT * FROM Task", _connection);
                var reader = getAllTasks.ExecuteReader();
                var tasks = new List<Objective>();

                while (reader.Read())
                {
                    tasks.Add(new Objective(
                        id: (int)reader["Id"],
                        emp_id: reader["Employee_Id"] as int?,
                        objective: reader["Task"] as string,
                        isCompleted: (bool)reader["IsCompleted"]
                        ));
                        
                }

                return tasks;
            }
        }

        public int GetTaskId(int emp_id)
        {
            int id = 0;
            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _connection.Open();

                SqlCommand getTaskId = new SqlCommand("select id from task where employee_id = @empID", _connection);
                getTaskId.Parameters.Add(new SqlParameter("@empID", emp_id));

                var reader = getTaskId.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["id"]);
                }

                return id;
            }

        }

        public bool HasTask(int emp_id)
        {
            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _connection.Open();
                SqlCommand hasTask = new SqlCommand("select id from task where employee_id = @empID", _connection);
                hasTask.Parameters.Add(new SqlParameter("@empID", emp_id));
                var reader = hasTask.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["Id"] is null)
                    {
                        return false;
                    }

                    else
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public void CommitTask(int task_id)
        {
            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _connection.Open();
                SqlCommand commitTask = new SqlCommand("update task set IsCompleted = 1 where id = @taskID", _connection);
                SqlCommand detachUserFromTask = new SqlCommand("update task set employee_id = NULL where id = @taskID", _connection);
                commitTask.Parameters.Add(new SqlParameter("@taskID", task_id));
                detachUserFromTask.Parameters.Add(new SqlParameter("taskID", task_id));

                commitTask.ExecuteNonQuery();
                detachUserFromTask.ExecuteNonQuery();
            }
        }

        public void CreateTask(string taskText)
        {
            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _connection.Open();
                SqlCommand createTask = new SqlCommand("insert into task values(null, @task, 0)", _connection);
                createTask.Parameters.Add(new SqlParameter("@task", taskText));

                createTask.ExecuteNonQuery();
            }
        }

        public void DeleteTask(int taskID)
        {
            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _connection.Open();
                SqlCommand deleteTask = new SqlCommand("delete from task where id = @Id", _connection);
                deleteTask.Parameters.Add(new SqlParameter("@Id", taskID));

                deleteTask.ExecuteNonQuery();
            }
        }

        public void AttachTaskToEmployee(int task_id, int emp_id)
        {
            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _connection.Open();
                SqlCommand taskToEmp = new SqlCommand("update Employee set Task_Id = @taskID where id = @empID", _connection);
                SqlCommand empToTask = new SqlCommand("update Task set Employee_Id = @empID where id = @taskID", _connection);

                taskToEmp.Parameters.Add(new SqlParameter("@taskID", task_id));
                taskToEmp.Parameters.Add(new SqlParameter("@empID", emp_id));

                empToTask.Parameters.Add(new SqlParameter("@empID", emp_id));
                empToTask.Parameters.Add(new SqlParameter("@taskID", task_id));


                taskToEmp.ExecuteNonQuery();
                empToTask.ExecuteNonQuery();
            }
        }

        public void DetachTaskFromEmployee(int task_id, int emp_id)
        {
            using (_connection)
            {
                _connection.ConnectionString = _connectionString;
                _connection.Open();
                SqlCommand taskFromEmp = new SqlCommand("update Employee set Task_Id = NULL where id = @empID", _connection);
                //SqlCommand empToTask = new SqlCommand("update Task set Employee_Id = NULL where id = @taskID", _connection);

                //taskFromEmp.Parameters.Add(new SqlParameter("@taskID", task_id));
                taskFromEmp.Parameters.Add(new SqlParameter("@empID", emp_id));

                //empToTask.Parameters.Add(new SqlParameter("@empID", emp_id));
                //empToTask.Parameters.Add(new SqlParameter("@taskID", task_id));


                taskFromEmp.ExecuteNonQuery();
                //empToTask.ExecuteNonQuery();
            }
        }
    }
}
