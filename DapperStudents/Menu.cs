using DapperStudents.DataAccess;
using DapperStudents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperStudents
{
    public class Menu
    {
        InitStud initStud = new InitStud();
        StudentRepository studentRepository = new StudentRepository();
        GroupRepository groupRepository = new GroupRepository();
        Students student = new Students();
        Group group = new Group();
        public void MenuOfDapper() {
            while (true)
            {
                Console.WriteLine(
                    "1 - Добавить в таблицу значение" +
                    "\n2 - Обновить в таблице значение" +
                    "\n3 - Удалить в таблице значение" +
                    "\n4 - Выборка");
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    switch (result)
                    {
                        case 1:
                            Console.WriteLine("В какую таблицу? " +
                        "\n1 - Студенты" +
                        "\n2 - Группы");
                            if (int.TryParse(Console.ReadLine(), out int result2))
                            {
                                switch (result2)
                                {
                                    case 1:
                                        initStud.AddStudent(student);
                                        studentRepository.Insert(@"insert into Students values (@LastName, @FirstName, @MidlName, @GroupId)", student);
                                        break;
                                    case 2:
                                        groupRepository.Insert(@"insert into [Group] values (@Name)", group);
                                        break;
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine("В какой таблице? " +
                        "\n1 - Студенты" +
                        "\n2 - Группы");
                            if (int.TryParse(Console.ReadLine(), out int result3))
                            {
                                switch (result3)
                                {
                                    case 1:
                                        var students = studentRepository.GetAllStudents("select * from Students");
                                        foreach (var s in students) { Console.WriteLine($"{s.Id}.{s.FirstName} {s.LastName} {s.MidlName}"); }
                                        Console.WriteLine("Введите Id студента, которого хотите изменить");
                                        int id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Что вы хотите изменить?" +
                                            "\n1 - Имя" +
                                            "\n2 - Фамилию" +
                                            "\n3 - Отчество" +
                                            "\n3 - Группу");
                                        if (int.TryParse(Console.ReadLine(), out int result4))
                                        {
                                            switch (result4)
                                            {
                                                case 1:
                                                    Console.WriteLine("Новое имя студента: ");
                                                    string firstName = Console.ReadLine();
                                                    studentRepository.UpdateStudents($"update Students SET FirstName = '{firstName}' where Id = {id}"); break;
                                                case 2:
                                                    Console.WriteLine("Новая фамилия студента: ");
                                                    string lastName = Console.ReadLine();
                                                    studentRepository.UpdateStudents($"update Students SET LastName = '{lastName}' where Id = {id}"); break;
                                                case 3:
                                                    Console.WriteLine("Новое отчество студента: ");
                                                    string midlName = Console.ReadLine();
                                                    studentRepository.UpdateStudents($"update Students SET MidlName = '{midlName}' where Id = {id}"); break;
                                                case 4:
                                                    Console.WriteLine("Новая группа студента: ");
                                                    int numOfGroup = int.Parse(Console.ReadLine());
                                                    studentRepository.UpdateStudents($"update Students SET GroupId = {numOfGroup} where Id = {id}"); break;
                                            }
                                        }
                                        break;
                                    case 2:
                                        var groups = groupRepository.GetAllStudents("select * from Group");
                                        foreach (var s in groups) { Console.WriteLine($"{s.Id}.{s.Name}"); }
                                        Console.WriteLine("Введите Id группы, которую хотите поменять: ");
                                        int id2 = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Новое название группы: ");
                                        string nameOfGroup = Console.ReadLine();
                                        groupRepository.UpdateGroup($"update [Group] SET Name = {nameOfGroup} where Id = {id2}");
                                        break;
                                }
                            }
                            break;
                        case 3:
                            Console.WriteLine("В какой таблице? " +
                        "\n1 - Студенты" +
                        "\n2 - Группы");
                            if (int.TryParse(Console.ReadLine(), out int result5))
                            {
                                switch (result5)
                                {

                                    case 1:
                                        var students = studentRepository.GetAllStudents("select * from Students");
                                        foreach (var s in students) { Console.WriteLine($"{s.Id}.{s.FirstName} {s.LastName} {s.MidlName}"); }
                                        Console.WriteLine("Удалять по: " +
                                            "\n1 - Имя" +
                                            "\n2 - Айди");
                                        if (int.TryParse(Console.ReadLine(), out int result6))
                                        {
                                            switch (result6)
                                            {

                                                case 1:
                                                    Console.WriteLine("Введите имя студента: ");
                                                    string name = Console.ReadLine();
                                                    studentRepository.DeleteAllStudents($"delete from Students where FirstName = {name}");
                                                    break;
                                                case 2:
                                                    Console.WriteLine("Введите айди студента: ");
                                                    int id = int.Parse(Console.ReadLine());
                                                    studentRepository.DeleteAllStudents($"delete from Students where Id = {id}");
                                                    break;
                                            }
                                        }
                                        break;
                                    case 2:
                                        var groups = groupRepository.GetAllStudents("select * from [Group]");
                                        foreach (var s in groups) { Console.WriteLine($"{s.Id}.{s.Name}"); }
                                        Console.WriteLine("Удалять по: " +
                                            "\n1 - Имя" +
                                            "\n2 - Айди");
                                        if (int.TryParse(Console.ReadLine(), out int result7))
                                        {
                                            switch (result7)
                                            {
                                                case 1:
                                                    Console.WriteLine("Введите имя группы: ");
                                                    string name = Console.ReadLine();
                                                    studentRepository.DeleteAllStudents($"delete from [Group] where Name = {name}");
                                                    break;
                                                case 2:
                                                    Console.WriteLine("Введите айди группы: ");
                                                    int id = int.Parse(Console.ReadLine());
                                                    studentRepository.DeleteAllStudents($"delete from [Group] where Id = {id}");
                                                    break;
                                            }
                                        }
                                        break;
                                }
                            }

                            break;
                        case 4:
                            Console.WriteLine("Выборка пo: " +
                                "\n1 - Студентам" +
                                "\n2 - Группам" +
                                "\n3 - Журналу по посещениям");
                            if (int.TryParse(Console.ReadLine(), out int result8))
                            {
                                switch (result8)
                                {
                                    case 1:
                                        Console.WriteLine("1 - Вывести всех студентов" +
                                            "\n2 - Вывести студентов в определённой группе" +
                                            "\n3 - Вывести студентов по дате посещения");
                                        if (int.TryParse(Console.ReadLine(), out int result9))
                                        {
                                            switch (result9)
                                            {
                                                case 1:
                                                    var students = studentRepository.GetAllStudents("select * from Students");
                                                    foreach (var s in students) { Console.WriteLine($"{s.Id}.{s.FirstName} {s.LastName} {s.MidlName}"); }
                                                    break;
                                                case 2:
                                                    var groupsForSearch = groupRepository.GetAllStudents("select * from [Group]");
                                                    foreach (var s in groupsForSearch) { Console.WriteLine($"{s.Id}.{s.Name}"); }
                                                    Console.WriteLine("Из какой группы: ");
                                                    int groupId = int.Parse(Console.ReadLine());
                                                    var studInGroup = studentRepository.GetAllStudents($"select * from Students where GroupId = {groupId}");
                                                    foreach (var s in studInGroup) { Console.WriteLine($"{s.Id}.{s.FirstName} {s.LastName} {s.MidlName}"); }
                                                    break;
                                                case 3:
                                                    Console.WriteLine("Введите дату(YYYY-MM-DD): ");
                                                    string date = Console.ReadLine();
                                                    date = date.Replace(" ", "");
                                                    if (date.Contains("-") & date.Length == 10)
                                                    {
                                                        var studByDate = studentRepository.SelectFromLogOfVisits($"select * from LogOfVisits where Date = '{date}'");
                                                        foreach (var s in studByDate) { Console.WriteLine($"\nId Студента: {s.StudentId} \nId Группы: {s.GroupId}\nДата посещения: {s.Date}"); }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Ошибка");
                                                    }
                                                    break;
                                            }
                                        }

                                        break;
                                    case 2:
                                        Console.WriteLine("1 - Вывести все группы" +
                                            "\n2 - Вывести группу с наибольшим посещением");
                                        if (int.TryParse(Console.ReadLine(), out int result10))
                                        {
                                            switch (result10)
                                            {
                                                case 1:
                                                    var groups = groupRepository.GetAllStudents("select * from [Group]");
                                                    foreach (var s in groups) { Console.WriteLine($"{s.Id}.{s.Name}"); }
                                                    break;
                                                case 2:
                                                    var groupsByVisit = studentRepository.SelectFromLogOfVisits("SELECT GroupId, COUNT(*) FROM LogOfVisits GROUP BY GroupId ORDER BY COUNT(*) DESC");
                                                    Console.WriteLine("По убыванию");
                                                    foreach (var s in groupsByVisit) { Console.WriteLine($"Айди группы: {s.GroupId}"); }
                                                    break;
                                            }
                                        }
                                        break;
                                    case 3:
                                        var logOfVisits = studentRepository.SelectFromLogOfVisits($"select * from LogOfVisits");
                                        foreach (var s in logOfVisits) { Console.WriteLine($"\nId Студента: {s.StudentId} \nId Группы: {s.GroupId}\nДата посещения: {s.Date}"); }
                                        break;
                                }
                                break;
                            }
                            break;
                    }
                }
            }
        }
    }
}
