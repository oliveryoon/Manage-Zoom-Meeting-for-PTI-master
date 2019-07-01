using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sick_Bed_Terminal_2019.Models.SickBays
{
    public class SickBay
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
    public class SickBaySimple // for Time in/out SickBay.
    {
        public int Seq { get; set; }
        public int Id { get; set; }
        public DateTime IncidentDate { get; set; }
        public TimeSpan Time { get; set; }
        public string RequestedJobCode { get; set; }
        public string UsernameModified { get; set; }
    }
}
