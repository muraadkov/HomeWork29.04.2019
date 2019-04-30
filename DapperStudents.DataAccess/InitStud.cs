using DapperStudents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperStudents.DataAccess
{
    public class InitStud
    {
        public void AddStudent(Students student)
        {
            Console.WriteLine("Введите имя студента: ");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию студента: ");
            student.LastName = Console.ReadLine();
            Console.WriteLine("Введите отчество студента(если есть): ");
            student.MidlName = Console.ReadLine();
            Console.WriteLine("Введите айди группы студента: ");
            student.GroupId = int.Parse(Console.ReadLine());
        }
    }
}
