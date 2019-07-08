using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApi.Models.SickBays
{
    public class UspSickBayInOutUpdate
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
}
