using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApi.Models.MusicLessons
{
    public class MusicLessonDTO // for Time in/out MusicLesson.
    {
        [Key]
        public int Seq { get; set; } // staff schedule seq.
        public int Id { get; set; }
        //public DateTime IncidentDate { get; set; }
        //public TimeSpan Time { get; set; }
        public string RequestedJobCode { get; set; }
        public string TerminalCode { get; set; }
        //public string UsernameModified { get; set; }
    }
}
