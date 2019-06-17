using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApi.Models.SickBays
{
    public class SickBay
    {
        public int Id { get; set; }
        public DateTime IncidentDate { get; set; }
        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }
        public DateTime DateModified { get; set; }
        public string UsernameModified { get; set; }        
    }
    public class SickBaySimple
    {
        public int Id { get; set; }
        public DateTime IncidentDate { get; set; }
        public TimeSpan Time { get; set; }        
        public string UsernameModified { get; set; }
    }
}
