﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApi.Models.MusicLessons
{
    public class UspMusicLessonStatusSelect
    {
        public int Id { get; set; }
        public int Seq { get; set; } // staff schedule seq.
        public string Code { get; set; } // ER => Pending Check out. The student must check out first. A=> The student didn't sign out and a nurse must sign out because he signed in yesterday. 
                                         //SI=> It is ok to ign out.
                                         //SO=> It is ok to sign in.
        public string Description { get; set; } //Exists
    }
}
