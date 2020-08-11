using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_Zoom_2019.Models
{
    // Object returned from API after update or insert.
    class Meeting
    {
        public string uuid { get; set; }
        public long id { get; set; }
        public string host_id { get; set; }
        public string topic { get; set; }
        public int type { get; set; }
        public string start_time { get; set; }
        public int duration { get; set; }
        public string timezone { get; set; }
        public string created_at { get; set; }
        public string join_url { get; set; }
        public string start_url { get; set; }
        public string agenda { get; set; }
        public string password { get; set; }

    }
    
}
