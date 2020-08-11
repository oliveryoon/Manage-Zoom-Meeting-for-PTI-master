using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_Zoom_2019.Models
{
    public class Tracking_Field
    {
        public string field { get; set; }
        public string value { get; set; }
    }
    public class Recurrence
    {
        public int type { get; set; }
        public int repeat_interval { get; set; }
        public int weekly_days { get; set; }
        public int monthly_day { get; set; }
        public int monthyl_week{ get; set; }
        public int monthyl_week_day { get; set; }
        public int end_times { get; set; }
        public string end_date_time { get; set; }

    }
    // Main object as param for adding/updating a Zoom meeting. This will include other objects as param values.
    public class MeetingBaseObject
    {

        public string topic { get; set; }

        public int type { get; set; }
        public string start_time { get; set; }

        public int duration { get; set; }
        public string schedule_for { get; set; }
        public string timezone { get; set; }

        public string password { get; set; } //      "maxLength": 10

        public string agenda { get; set; } //      "maxLength": 2000
        //public IList<Tracking_Field> tracking_Fields { get; set; }

        public Recurrence recurrence { get; set; }
        public Setting settings { get; set; }
        
    }
    public class Setting {
        public bool host_video { get; set; }
        public bool participant_video { get; set; }
        public bool cn_meeting { get; set; }
        public bool in_meeting { get; set; }
        public bool join_before_host { get; set; }
        public bool mute_upon_entry { get; set; }
        public bool watermark { get; set; }
        public bool use_pmi { get; set; }
        public int approval_type { get; set; }
        public int registration_type { get; set; }
        public string audio { get; set; }
        public string auto_recording { get; set; }
        public bool enforce_login { get; set; }
        public string enforce_login_domains { get; set; }
        public string alternative_hosts { get; set; }
        public bool close_registration { get; set; }
        public bool waiting_room { get; set; }
        public string[] global_dial_in_countries { get; set; }
        public string contact_name { get; set; }
        public string contact_email { get; set; }
        public bool registrants_email_notification { get; set; }
        public bool meeting_authentication { get; set; }
        public string authentication_option { set; get; }
        public string authentication_domains { get; set; }
        public string[] additional_data_center_regions { get; set; }
   

    }
}
