using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperStudents.Models
{
    public class LogOfVisits
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public DateTime Date { get; set; }
    }
}
