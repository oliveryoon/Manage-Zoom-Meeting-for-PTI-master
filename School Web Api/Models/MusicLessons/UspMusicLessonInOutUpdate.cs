using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApi.Models.MusicLessons
{
    public class UspMusicLessonInOutUpdate
    {
        public int Seq { get; set; } // staff schedule seq.
        public int Id { get; set; }
        public DateTime DateTimeIn { get; set; }
        public DateTime DateTimeOut { get; set; }
        public DateTime DateTimeModified { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}