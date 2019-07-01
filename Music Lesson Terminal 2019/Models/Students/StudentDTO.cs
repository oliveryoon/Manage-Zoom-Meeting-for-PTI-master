using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Music_Lesson_Terminal_2019.Models.Students
{
    class StudentDTO
    {
        
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Surname { get; set; }
        public string Given1 { get; set; }
        public string Preferred { get; set; }
        public Int16 YearLevel { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public byte[] Photo { get; set; }
    }
}
