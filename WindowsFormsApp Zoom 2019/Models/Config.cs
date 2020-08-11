using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_Zoom_2019.Models
{
     // Zoom configuration values (API params).
    public class Config
    {
        [Key]
        public int seq { get; set; }
        public string jwt_token { get; set; }
        public string meeting_topic { get; set; } //meeting title.
        public int meeting_type { get; set; } // 1 Instant meeting. 2 scheduled meeting. 3 Recurring meeting with no fixed time. 8 recurring meeting with fixed time.
        public string start_time { get; set; } //For this application, only holds Time information THH:mm:ss 
        // two formats - local and GMT. GMT yyyy-MM-ddTHH:mm:ssZ. local yyyy-MM-ddTHH:mm:ss
        public DateTime meeting_datetime { get; set; } // Date. Later this date and the above start_time will be combined.
        public int meeting_duration { get; set; } // in minutes.
        public string schedule_for { get; set; } // for organising a meeting for someone else, provide the zoom user id or email address of the user here.
        public string meeting_time_zone { get; set; } //
        public string password { get; set; } //Password to join the meeting. A-Z a-z 0-9 @-_*   upto 10 characters long.
        public string meeting_agenda { get; set; } //Meeting description.

        public bool host_video { get; set; } // Start video when the host joins the meeting.
        public bool participant_video { get; set; } // Start video when participants join the meeting.
        public bool join_before_host { get; set; } 
        public bool mute_upon_entry { get; set; } // 
        public bool watermark { get; set; } //Add watermark when viewing a shared screen.
        public bool use_pmi { get; set; } // Use personal meeting ID instead of an automatically generated meeting ID.Only for scheduled meeting. instant meeting with fixed time.
        public int approval_type { get; set; } //0 automatically approve. 1 Manually approve. 2 No registration required.
        public int? registration_type { get; set; } //1 2 and 3

        public string audio { get; set; } //both - both telephony and VoIP. telephony, voip,
        public string auto_recording { get; set; } // local- record on local, cloud- record on cloud, none -disabled.
        public string alternative_hosts { get; set; } //alternative host's emails or IDs. separated by a comma.
        public bool enforce_login { get; set; }
        public string enforce_login_domains { get; set; }
        public bool close_registration { get; set; } //Close registration after event date.
        public bool waiting_room { get; set; } //enable waiting room.

        public string global_dial_countries { get; set; } // array[string] . List of global dial_in countries.
        public string contact_name { get; set; } //Contact name for registration.
        public string contact_email { get; set; } //Contact email for registration.

        public bool registraints_email_notification { get; set; }                    
        public bool meeting_authentication { get; set; }                    
        public string authentication_option { get; set; }
        public string authentication_domains { get; set; }
        public bool active_flag { get; set; } // It is not for Zoom API. 

    }
    public class ApprovalType
    {
        [Key]
        public int Code { get; set; }
        public string Description { get; set; }
    }
    public class Audio
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
    }
    public class AutoRecording
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
    }
    public class MeetingType
    {
        [Key]
        public int Code { get; set; }
        public string Description { get; set; }
    }
    public class RegistrationType
    {
        [Key]
        public int Code { get; set; }
        public string Description { get; set; }
    }
}
