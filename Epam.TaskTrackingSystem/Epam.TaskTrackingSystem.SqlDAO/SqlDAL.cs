using Epam.TaskTrackingSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                if (reader.Read())
                {
                    if (email.Equals(reader["email"].ToString()) && password.Equals(reader["password"].ToString()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                else
                {
                    return false;
                }
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
                _connection.Open();
                SqlCommand getAllEmps = new SqlCommand("SELECT * FROM Employee", _connection);
                var reader = getAllEmps.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Employee(
                        id: (int)reader["Id"],
                        email: reader["Email"] as string,
                        password: reader["Password"] as string,
                        role: reader["Role"] as string,
                        task_id: (int)reader["Task_Id"]
                    );
                }
            }
        }

        public IEnumerable<Objective> GetAllTasks()
        {
            using (_connection)
            {
                _connection.Open();
                SqlCommand getAllTasks = new SqlCommand("SELECT * FROM Task", _connection);
                var reader = getAllTasks.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Objective(
                        id: (int)reader["Id"],
                        emp_id: (int)reader["Employee_Id"],
                        objective: reader["Task"] as string,
                        isCompleted: (bool)reader["IsCompleted"]
                        );
                        
                }
            }
        }

        public void AttachTaskToEmployee(int emp_id, int task_id)
        {
            throw new NotImplementedException();
        }
    }
}
