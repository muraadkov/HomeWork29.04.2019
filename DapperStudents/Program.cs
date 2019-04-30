using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperStudents.Models;
using DapperStudents.DataAccess;

namespace DapperStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.MenuOfDapper();
            Console.ReadLine();
        }
    }
}
