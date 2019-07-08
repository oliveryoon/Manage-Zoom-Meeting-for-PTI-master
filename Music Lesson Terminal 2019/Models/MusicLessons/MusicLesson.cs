using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Lesson_Terminal_2019.Models.MusicLessons
{
    public class MusicLesson
    {
        
        public int Seq { get; set; }
        public int Id { get; set; }
        public DateTime IncidentDate { get; set; }
        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }
        public DateTime DateTimeModified { get; set; }
        public string UsernameModified { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
    public class MusicLessonDTO // for Time in/out MusicLesson.
    {
        
        public int Seq { get; set; }
        public int Id { get; set; }
        public DateTime DateTimeCardSwiped { get; set; }
        
        public string RequestedJobCode { get; set; }
        public string TerminalCode { get; set; }

    }
}
