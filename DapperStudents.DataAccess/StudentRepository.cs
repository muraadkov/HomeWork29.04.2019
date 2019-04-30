using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperStudents.Models;

namespace DapperStudents.DataAccess
{
    public class StudentRepository
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\murka\source\repos\HomeWork29.04.2019-master\DapperStudents.DataAccess\StudentsDB.mdf;Integrated Security=True";
        public string Insert(string query, Students student)
        {
            using(var sql = new SqlConnection(connectionString))
            {
                var result = sql.Execute(query, student);
                if(result < 1)
                {
                    throw new Exception("failed!");
                }
                return "gj!";
            }
        }
        public List<Students> GetAllStudents(string query)
        {
            using(var sql = new SqlConnection(connectionString))
            {
                var result = sql.Query<Students>(query).ToList();
                return result;
            }
        }
        public void UpdateStudents(string query)
        {
            using(var sql = new SqlConnection(connectionString))
            {
                sql.Execute(query);
            }
        }
        public List<Students> DeleteAllStudents(string query)
        {
            using(var sql = new SqlConnection(connectionString))
            {
                var result = sql.Query<Students>(query).ToList();
                return result;
            }
        }
        public List<LogOfVisits> SelectFromLogOfVisits(string query)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var result = sql.Query<LogOfVisits>(query).ToList();
                return result;
            }
        }
    }
}