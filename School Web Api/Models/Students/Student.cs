using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Given1 { get; set; }
        public string Preferred { get; set; }
        public Int16 YearLevel { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public byte[] Photo { get; set; }
    }
}
