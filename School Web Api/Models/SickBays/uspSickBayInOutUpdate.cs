using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApi.Models.SickBays
{
    public class UspSickBayInOutUpdate
    {
        public int Id { get; set; }
        public DateTime IncidentDate { get; set; }
        public TimeSpan Time { get; set; }
        public string UsernameModified { get; set; }
    }
}
