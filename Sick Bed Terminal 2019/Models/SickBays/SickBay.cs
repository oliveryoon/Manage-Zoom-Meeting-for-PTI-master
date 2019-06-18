using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sick_Bed_Terminal_2019.Models.SickBays
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
    public class SickBaySimple // for Time in/out SickBay.
    {
        public int Id { get; set; }
        public DateTime IncidentDate { get; set; }
        public TimeSpan Time { get; set; }
        public string UsernameModified { get; set; }
    }
}
