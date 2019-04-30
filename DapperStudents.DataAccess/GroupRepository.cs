using Dapper;
using DapperStudents.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperStudents.DataAccess
{
    public class GroupRepository
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\murka\source\repos\HomeWork29.04.2019-master\DapperStudents.DataAccess\StudentsDB.mdf;Integrated Security=True";
        public string Insert(string query, Group group)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var result = sql.Execute(query, group);
                if (result < 1)
                {
                    throw new Exception("failed!");
                }
                return "gj!";
            }
        }
        public List<Group> GetAllStudents(string query)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var result = sql.Query<Group>(query).ToList();
                return result;
            }
        }
        public List<Group> UpdateGroup(string query)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var result = sql.Query<Group>(query).ToList();
                return result;
            }
        }
        public List<Group> DeleteAllStudents(string query)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var result = sql.Query<Group>(query).ToList();
                return result;
            }
        }
    }
}
