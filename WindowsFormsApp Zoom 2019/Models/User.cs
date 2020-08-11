using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_Zoom_2019.Models
{

    // For Synergetic to hold Zoom meetings against teachers.
    public class User
    {
        [Key]
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public int type { get; set; }

        public Int64 pmi { get; set; }

        public string timezone { get; set; }

        public int verified { get; set; }
        //"verified": 1,
        public string dept { get; set; }
        public string created_at { get; set; }
        //"created_at": "2018-11-15T01:10:08Z",
        public string last_login_time { get; set; }
        //"last_login_time": "2019-09-13T21:08:52Z",
        public string last_client_version { get; set; }
        //"last_client_version": "4.4.55383.0716(android)",
        public string pic_url { get; set; }
        //"pic_url": "https://lh4.googleusercontent.com/-someurl/photo.jpg",
        public string[] group_ids { get; set; }
        public string[] im_group_ids { get; set; }
        public string Status { get; set; }

    }
    public class ZoomUser
    {
        [Key]
        public int seq { get; set; }
        public int config_seq { get; set; }
        public string user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public int? staff_id { get; set; }
        public string staff_code  { get; set; }
        public long? meeting_id { get; set; }
        public string join_url { get; set; }
        public string start_url { get; set; }
        
        public DateTime? start_time { get; set; }
        public string password { get; set; }        
        public DateTime datetime_last_modified { get; set; }
        public bool active_flag { get; set; }
    }
    public class vZoomUser
    {
        [Key]
        public int staff_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string staff_code { get; set; }
        public DateTime? start_time { get; set; }
        public long? meeting_id { get; set; }

    }
}
