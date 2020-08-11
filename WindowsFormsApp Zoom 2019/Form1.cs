using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;

using RestSharp;
using WindowsFormsApp_Zoom_2019.Data;
using WindowsFormsApp_Zoom_2019.Models;

namespace WindowsFormsApp_Zoom_2019
{
    public partial class frmMain : Form
    {


        public frmMain()
        {
            InitializeComponent();
        }
        // It is not used.
        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }
        // It is not used.
        private string BuildToken(User user)
        {
            
            return "test";

        }
        // It is not used.
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Call an API.
            //var client = new RestSharp.RestClient("https://api.zoom.us/v2/accounts/{userid}/users");
            var client = new RestSharp.RestClient("https://api.zoom.us/v2/users");  
            string token = "";
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", string.Format("Bearer {0}", token));
            IRestResponse response = client.Execute(request);




        }
        // It is not used.
        private async Task<UserList> GetUserList(int page_number, int page_size, string jwtToken)
        {
            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;

            try
            {
                
                var builder = new UriBuilder("https://api.zoom.us/v2/users");
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["page_size"] = page_size.ToString();
                query["page_number"] = page_number.ToString();
                query["status"] = "status";
                builder.Query = query.ToString();

                string url = builder.ToString();
                httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);

                string token = jwtToken;

                //Add the token in Authorization header
                
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                response = await httpClient.SendAsync(request);
                
                UserList userDTO;

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    userDTO = JsonConvert.DeserializeObject<UserList>(content);
                    return userDTO;
                    

                }
                else if ((int)response.StatusCode == 404)
                    throw new Exception("Meeting not found.");
                else if ((int)response.StatusCode == 400)
                    throw new Exception("User not found on this account.");
                else if ((int)response.StatusCode == 401)
                    throw new Exception(response.StatusCode + ". Check if the token is valid.");
                else
                {
                    throw new Exception(string.Format("Api call failed. {0}-{1}", (int)response.StatusCode, response.StatusCode));
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            return new UserList();
        }
        // It is not used.
        private async void btnTest_Click(object sender, EventArgs e)
        {
            string jwtToken = await GetJwtToken();
            if (jwtToken == "")
            {
                MessageBox.Show("Please configure a valid jwtToken from Zoom developer site.");

                return;
            }

            int page_number = 1;
            int total_pages = 1;
            
            int page_size = 100;

            while (page_number<= total_pages)
            {
                var test = await GetUserList(page_number, page_size, jwtToken);
                if (total_pages == 1)
                    total_pages = (test.total_records / page_size) + 1;


                foreach (var user in test.users.Where(t => t.last_name == ""))
                {

                    Debug.Print(user.email);
                }

                page_number ++;
            }
            
        }
        // It is not used.
        private void PostMeeting()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://example.com/");
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
            request.Content = new StringContent("{\"name\":\"John Doe\",\"age\":33}",
                                                Encoding.UTF8,
                                                "application/json");//CONTENT-TYPE header

            client.SendAsync(request)
                  .ContinueWith(responseTask =>
                  {
                      Console.WriteLine("Response: {0}", responseTask.Result);
                  });
        }
        /*
         * This function will check if a teacher in the tag list has a valid Zoom meeting. The result will be shown in the list box.
         * 
         */
        private async void btnGetMeetings_Click(object sender, EventArgs e)
        {
            chkDeleteExistingMeeting.Checked = false; // set the check box back to default.

            try
            {
                string validationMessage = ValidateZoomUserDataFromSynergetic();
                if (validationMessage != "")
                {
                    MessageBox.Show(validationMessage);
                    return;
                }

                lstResults.Items.Clear();
                progressBar.Value = 0;
                progressBar.Minimum = 0; progressBar.Maximum = 0;

                progressBarSimple.Value = 0;
                progressBarSimple.Minimum = 0; progressBarSimple.Maximum = 10;

                lblProcessed.Text = "Processed: 0";
                lblTotal.Text = "Total: 0";
                lblUpdated.Text = "Exists: 0";

                int countExists = 0;

                string jwtToken = await GetJwtToken();
                if (jwtToken == "")
                {
                    MessageBox.Show("Please configure a valid jwtToken from Zoom developer site.");
                    dtpPTI.Focus();
                    return;
                }
                using (var context = new SynergeticContext())
                {
                    // get a list of zoom candidates for PTI. Active users and their active schedule meeting details.
                    var vUsers = context.vZoomUsers.OrderBy(t => t.last_name).ThenBy(t => t.first_name);
                    lblTotal.Text = "Total: " + vUsers.Count().ToString();
                    progressBar.Maximum = vUsers.Count();
                    
                    foreach (var vUser in vUsers)
                    {
                        progressBarSimple.Value = 3;
                                               

                        //Find an existing meeting.                    
                        if (vUser.meeting_id > 0)
                            try
                            {
                                progressBarSimple.Value = 5;
                                Meeting meeting = await GetAMeeting((long)vUser.meeting_id, jwtToken);
                                progressBarSimple.Value = 9;
                                // Add an item.
                                ListItem list = new ListItem();
                                list.Text = string.Format("A meeting for {0} {1} exists.", vUser.first_name, vUser.last_name);
                                lstResults.Items.Add(list);
                                
                                countExists = countExists + 1;
                                lblUpdated.Text = "Exists: " + countExists.ToString();
                                progressBarSimple.Value = 10;
                            }
                            catch (Exception ex)
                            {
                                // Add an item.
                                ListItem list = new ListItem();
                                
                                list.Text = string.Format("A meeting for {0} {1} {2} {3}.", vUser.first_name, vUser.last_name, ex.Message, "!!!");
                                
                                lstResults.Items.Add(list);
                            }
                        else if (vUser.meeting_id == null || vUser.meeting_id <= 0)
                        {
                            // Add an item.
                            ListItem list = new ListItem();
                            list.Text = string.Format("A meeting for {0} {1} has not been created !!!.", vUser.first_name, vUser.last_name);
                            
                            lstResults.Items.Add(list);
                        }
                        progressBarSimple.Value = 10;
                        if (progressBar.Value < progressBar.Maximum)
                            progressBar.Value = progressBar.Value + 1;

                        

                        lblProcessed.Text = "Processed: " + progressBar.Value.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "There is an error caught. " + (ex.Message.Length > 150 ? ex.Message.Substring(0,149) : ex.Message)); // Avoid a page long error message.
            }
        }
        /*
         * Not used. However you may use this function to get a list of zoom meetings.         * 
         */
        private async Task<MeetingList> GetMeetingList(int page_number, int page_size, string jwtToken)
        {
            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;

            try
            {

                var builder = new UriBuilder("https://api.zoom.us/v2/users/{userId}/meetings");
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["page_size"] = page_size.ToString();
                query["page_number"] = page_number.ToString();
                query["status"] = "status";
                builder.Query = query.ToString();

                string url = builder.ToString();
                httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);

                //Add the token in Authorization header

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);
                response = await httpClient.SendAsync(request);

                MeetingList meetingList;

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    meetingList = JsonConvert.DeserializeObject<MeetingList>(content);
                    return meetingList;


                }
                else if ((int)response.StatusCode == 404)
                    throw new Exception("Meeting not found.");
                else if ((int)response.StatusCode == 400)
                    throw new Exception("User not found on this account.");
                else if ((int)response.StatusCode == 401)
                    throw new Exception(response.StatusCode + ". Check if the token is valid.");
                else
                {
                    throw new Exception(string.Format("Api call failed. {0}-{1}", (int)response.StatusCode, response.StatusCode));
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            return new MeetingList();
        }
        /*
         * Not used. However you may use this function to get a list of zoom meetings and add them to Synergetic.
        */
        private async void btnImportUsersToSynergetic_Click(object sender, EventArgs e)
        {
            string jwtToken = await GetJwtToken();
            if (jwtToken == "")
            {
                MessageBox.Show("Please configure a valid jwtToken from Zoom developer site.");

                return;
            }

            int page_number = 1;
            int total_pages = 1;

            int page_size = 100;
            bool total_pages_checked_flag = false;

            while (page_number <= total_pages)
            {
                var test = await GetUserList(page_number, page_size, jwtToken);
                if (total_pages_checked_flag == false)
                {
                    total_pages_checked_flag = true;
                    total_pages = (test.total_records / page_size) + 1;
                }
                    
                foreach (var user in test.users)
                {
                    using (var context = new SynergeticContext())
                    {
                        // Perform data access using the context
                        var userExists = context.ZoomUsers.Where(t => t.user_id == user.id).FirstOrDefault();
                        if (userExists == null)
                        {
                            var userCreated = new ZoomUser();
                            userCreated.user_id = user.id;
                            userCreated.email = user.email;
                            userCreated.first_name = user.first_name;
                            userCreated.last_name = user.last_name;
                            userCreated.active_flag = false;
                            //userCreated.PTIMeetingID = 0;

                            context.ZoomUsers.Add(userCreated);
                            context.SaveChanges();
                        }
                        else
                        {
                            
                            userExists.email = user.email;
                            userExists.first_name = user.first_name;
                            userExists.last_name = user.last_name;
                                                        
                            context.SaveChanges();
                        }
                    }
                    //Debug.Print(user.email);
                }

                page_number++;
            }
            MessageBox.Show("Imported successfully.");
        }
        /*
         * Create a Zoom meeting per teacher from a list of vTagOwn in Synergetic.
        */
        private async void btnCreateMeeting_Click(object sender, EventArgs e)
        {
            try
            {
                
                string validationMessage = ValidateZoomUserDataFromSynergetic();
                if (validationMessage  != "")
                {
                    MessageBox.Show(validationMessage);
                    return;
                }

                string jwtToken = await GetJwtToken();
                if (jwtToken =="")
                {
                    MessageBox.Show("Please configure a valid jwtToken from Zoom developer site.");
                    
                    return;
                }

                if (dtpPTIFromDB.Value <= System.DateTime.Now)
                {
                    MessageBox.Show("Please select a meeting date later than now.");
                    
                    return;
                }

                if (txtMeetingTopicFromDB.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a title.");                    
                    return;
                }
                if (txtMeetingTopicFromDB.Text.Trim() != "" && txtMeetingTopicFromDB.Text.IndexOf("{Staff Name}")<0)
                {
                    MessageBox.Show("Please inlcude the tag {Staff Name} in the title.");                    
                    return;
                }

                lstResults.Items.Clear();
                progressBar.Value = 0;
                progressBar.Minimum = 0;progressBar.Maximum = 0;

                progressBarSimple.Value = 0;
                progressBarSimple.Minimum = 0; progressBarSimple.Maximum = 10;

                lblProcessed.Text = "Processed: 0";
                lblTotal.Text = "Total: 0";
                lblUpdated.Text = "Created: 0";

                int countCreated = 0;

               

                lblMsg.Visible = true;

                DateTime ptiDate = dtpPTI.Value;
                using (var context = new SynergeticContext())
                {
                    // get a list of zoom candidates for PTI (vTagList).
                    var vUsers = context.vZoomUsers.OrderBy(t=>t.last_name).ThenBy(t=>t.first_name);
                    lblTotal.Text = "Total: " + vUsers.Count().ToString();
                    progressBar.Maximum = vUsers.Count();

                    //This message box needs to have how many staff are selected for this process.
                    if (MessageBox.Show(this, "Do you like to create a PTI meeting for people in your Synergetic Tag list? (Total User Count =" + vUsers.Count().ToString() + ")", "Create Zoom Meeting", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;

                    int config_seq = await GetActiveConfigSeq(); // current active schedule seq;

                    foreach ( var vUser in vUsers)
                    {
                        progressBarSimple.Value = 2;
                        
                        //Find an existing meeting.
                        bool ExistsFlag = false;
                        if (vUser.meeting_id > 0)
                            ExistsFlag = await MeetingExists((long)vUser.meeting_id, jwtToken);

                        // Delete first if the delete existing meeting check box is ticked. If Synergetic holds a zoom details but the teacher deleted it accidently, the synergetic record will be deleted too.
                        if ( vUser.meeting_id > 0 && (!ExistsFlag || chkDeleteExistingMeeting.Checked ))
                        {
                            var deletedHttpStatusCode = await DeleteMeeting((long)vUser.meeting_id, jwtToken); // Delete the Zoom meeting.

                            progressBarSimple.Value = 4;
                            if (deletedHttpStatusCode == 204 || deletedHttpStatusCode == 404) //204 deleted. 404 not found.
                            {
                                using (var context2 = new SynergeticContext())
                                {
                                    ZoomUser user = context2.ZoomUsers.Where(t => t.email == vUser.email && t.active_flag && t.config_seq == config_seq).FirstOrDefault(); // Clean up synergetic.
                                    if (user != null)
                                    {
                                        user.first_name = vUser.first_name;
                                        user.last_name = vUser.last_name;                                        
                                        user.email = vUser.email;
                                        user.staff_id = vUser.staff_id;
                                        user.staff_code = vUser.staff_code;
                                        user.meeting_id = null;
                                        user.join_url = "";
                                        user.start_url = "";
                                        user.start_time = null;
                                        user.password = "";

                                        user.active_flag = true;
                                        user.datetime_last_modified = System.DateTime.Now;

                                        context2.SaveChanges();
                                    }
                                }
                            }

                            ListItem list = new ListItem();
                            if (deletedHttpStatusCode == 204)
                                list.Text = string.Format("A meeting for {0} {1} was deleted.", vUser.first_name, vUser.last_name);
                            else
                                list.Text = string.Format("A meeting for {0} {1} was not found.", vUser.first_name, vUser.last_name);

                            lstResults.Items.Add(list);
                        }
                        progressBarSimple.Value = 6;

                        // Add one.
                        if (vUser.meeting_id == null || vUser.meeting_id <= 0 
                            || vUser.meeting_id>0 && (!ExistsFlag || chkDeleteExistingMeeting.Checked))
                        {
                            // Create a new Zoom meeting.
                            Meeting meeting = await CreateMeeting(vUser.email, string.Format("{0} {1}", vUser.first_name, vUser.last_name), ptiDate, txtMeetingTopic.Text.Trim(), jwtToken);

                            progressBarSimple.Value = 8;

                            //Meeting meeting = new Meeting();
                            //meeting.uuid = "iLeQgqUSRrm3r9auWTd_7Q";
                            //meeting.id = 93771524314;
                            //meeting.join_url = "https://joeys.zoom.us/j/6069364394";

                            // If a new meeting is created, then add it to a user table in Synergetic. This will help to manipulate the data. For example, you can upload join url and password of the zoom meeting to 3rd party PTO systems.
                            if (meeting != null) // Created.
                            {
                                countCreated++;
                                lblUpdated.Text = "Created: " + countCreated;

                                using (var context2 = new SynergeticContext())
                                {
                                    try
                                    {

                                    
                                        ZoomUser user = context2.ZoomUsers.Where(t => t.email == vUser.email && t.active_flag && t.config_seq == config_seq).FirstOrDefault(); // add or update Synergetic user table which holds a Zoom details.
                                        if (user == null)
                                        {
                                            user = new ZoomUser();
                                            user.config_seq = config_seq;
                                        }
                                        user.first_name = vUser.first_name;
                                        user.last_name = vUser.last_name;
                                    
                                        user.email = vUser.email;
                                        user.staff_id = vUser.staff_id;
                                        user.staff_code = vUser.staff_code;

                                        user.user_id = meeting.uuid;
                                        user.meeting_id = meeting.id;
                                        user.join_url = meeting.join_url;
                                        user.start_url = meeting.start_url;
                                        user.start_time = System.DateTime.Parse(meeting.start_time);
                                        user.password = meeting.password;
                                        user.active_flag = true;
                                        user.datetime_last_modified = System.DateTime.Now;

                                        ZoomUser[] Users2 = { user };
                                        context2.ZoomUsers.AddOrUpdate(Users2);
                                    
                                        await context2.SaveChangesAsync();
                                    }

                                    catch(Exception ex) //If Adding a new record fails, delete the zoom meeting to avoid an orphaned zoom meeting. For Updating an existing record, do not delete because its meeting_id will stay as is.
                                    {
                                        var httpStatusCode = await DeleteMeeting(meeting.id, jwtToken);
                                        
                                        if (httpStatusCode != 204 && httpStatusCode != 404)
                                        {
                                            throw new Exception(string.Format("A zoom meeting for {0} was created but the Synergetic user table cannot be updated. Clean up the meeting (meeting ID = {1}) failed. {2}", vUser.email, meeting.id, ex.Message));
                                        }
                                        else
                                        {
                                            throw new Exception(string.Format("A zoom meeting for {0} was created but the Synergetic user table cannot be updated. Clean up the meeting (meeting ID = {1}) succeeded. {2}", vUser.email, meeting.id, ex.Message));
                                        }
                                        
                                    }                                    
                                }

                                // Add an item.
                                ListItem list = new ListItem();
                                list.Text = string.Format("A meeting for {0} {1} was created.", vUser.first_name, vUser.last_name);
                                lstResults.Items.Add(list);
                            }
                            else
                            {
                                // Add an item.
                                ListItem list = new ListItem();
                                list.Text = string.Format("Creating a meeting for {0} {1} failed.", vUser.first_name, vUser.last_name);
                                lstResults.Items.Add(list);
                            }
                        

                        }
                        else
                        {
                            ListItem list = new ListItem();
                            list.Text = string.Format("A meeting for {0} {1} exists.", vUser.first_name, vUser.last_name);
                            lstResults.Items.Add(list);
                        }

                        if (progressBar.Value < progressBar.Maximum)
                            progressBar.Value = progressBar.Value + 1;

                        lblProcessed.Text = "Processed: " + progressBar.Value.ToString();
                        progressBarSimple.Value = 10;
                    }
                }
                               
                MessageBox.Show(this, "Creating Zoom Meetings is complete.");
                chkDeleteExistingMeeting.Checked = false; // set the check box back to default.
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "There is an error caught. " + (ex.Message.Length> 150 ? ex.Message.Substring(0, 149) : ex.Message));
            }
            lblMsg.Visible = false;
        }
        /*
         * Not Used. Check if a Zoom meeting exists.
        */
        private async Task<bool> MeetingExists(string userid, int page_size, int page_number, DateTime ptiDate, string jwtToken)
        {
            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;

            try
            {

                //"https://api.zoom.us/v2/users/{userId}/meetings"
                string urlTemp = string.Format("https://api.zoom.us/v2/users/{0}/meetings", userid);
                var builder = new UriBuilder(urlTemp);

                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["page_size"] = page_size.ToString();
                query["page_number"] = page_number.ToString();
                query["status"] = "active";
                builder.Query = query.ToString();

                string url = builder.ToString().Replace("{userId}", userid);
                httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);

                
                //Add the token in Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);
                response = await httpClient.SendAsync(request);

                MeetingList meetingList;

                bool bolExistsFlag = false;

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    meetingList = JsonConvert.DeserializeObject<MeetingList>(content);


                    foreach (var meeting in meetingList.meetings)
                    {
                        DateTime dt;
                        if (DateTime.TryParse(meeting.start_time, out dt))
                        {
                            if (dt.Date == ptiDate.Date)
                            {
                                bolExistsFlag = true;
                                break;
                            }

                        }

                    }




                }
                else if ((int)response.StatusCode == 404)
                    bolExistsFlag = false; // throw new Exception("Meeting not found.");
                else if ((int)response.StatusCode == 400)
                    throw new Exception("User not found on this account.");
               
                else if ((int)response.StatusCode == 401)
                    throw new Exception(response.StatusCode + ". Check if the token is valid.");
                else
                {
                    throw new Exception(string.Format("Api call failed. {0}-{1}", (int)response.StatusCode, response.StatusCode));
                }
                return bolExistsFlag;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                //Debug.Print(e.Message);
            }
            //return false;
        }
        /*
         * Check if a Zoom meeting exists.
        */
        private async Task<bool> MeetingExists(long meeting_id, string jwtToken)
        {
            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;

            try
            {

                //"https://api.zoom.us/v2/meetings/{meetingId}"
                string urlTemp = string.Format("https://api.zoom.us/v2/meetings/{0}", meeting_id);
                var builder = new UriBuilder(urlTemp);

                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                builder.Query = query.ToString();

                string url = builder.ToString();
                httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);

                //Add the token in Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);
                response = await httpClient.SendAsync(request);

                Meeting meeting;

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    meeting = JsonConvert.DeserializeObject<Meeting>(content);

                    if (meeting != null)
                        return true;

                }
                else if ((int)response.StatusCode == 404)
                    return false; // throw new Exception("Meeting not found.");
                else if ((int)response.StatusCode == 400) // The user who runs this application doesn't have enough permission in the Zoom system.
                    throw new Exception("User not found on this account.");
               
                else if ((int)response.StatusCode == 401)
                    throw new Exception(response.StatusCode + ". Check if the token is valid.");
                else
                {
                    throw new Exception(string.Format("Api call failed. {0}-{1}", (int)response.StatusCode, response.StatusCode));
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return false;
        }
        /*
         * Get a zoom meeting. It is used to verify if the meeting_id stored in the Synergetic user table (uZoom_Users) exists.
        */
        private async Task<Meeting> GetAMeeting(long meeting_id, string jwtToken)
        {
            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;

            try
            {

                //"https://api.zoom.us/v2/meetings/{meetingId}"
                string urlTemp = string.Format("https://api.zoom.us/v2/meetings/{0}", meeting_id);
                var builder = new UriBuilder(urlTemp);

                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                builder.Query = query.ToString();

                string url = builder.ToString();
                httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);

                //Add the token in Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);
                response = await httpClient.SendAsync(request);

                Meeting meeting;

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    meeting = JsonConvert.DeserializeObject<Meeting>(content);

                    return meeting;                    

                }
                else if ((int)response.StatusCode == 404)
                    throw new Exception("Meeting not found.");
                else if ((int)response.StatusCode == 400)
                    throw new Exception("User not found on this account.");
                else if ((int)response.StatusCode == 401)
                    throw new Exception(response.StatusCode + ". Check if the token is valid.");
                else
                {
                    throw new Exception(string.Format("Api call failed. {0}-{1}", (int)response.StatusCode, response.StatusCode));
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            //return new Meeting();
        }
        /*
         * Create a zoom meeting. 
         * If a check box of 'Delete existing meeting first' is ticked, This function will delete an existing meeting first and create another one.
         * If a check box of 'Delete existing meeting first' is not ticked, this function skips a teaher if a meeting exists already for the teacher.
         * Otherwise, it will create a new meeting.
        */
        private async Task<Meeting> CreateMeeting(string email, string host_staff_name, DateTime ptiDate, string meeting_topic, string jwtToken)
        {
            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;

            try
            {

                // You can pass either user id or email address to create a meeting.
                //"https://api.zoom.us/v2/users/{userId}/meetings"
                //"https://api.zoom.us/v2/users/{email}/meetings"

                string urlTemp = string.Format("https://api.zoom.us/v2/users/{0}/meetings", email);
                var builder = new UriBuilder(urlTemp);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);             
                builder.Query = query.ToString();
                string url = builder.ToString();

                // Prepare Request Body.
                MeetingBaseObject meetingBaseObject = new MeetingBaseObject();
                // setting
                Setting setting = new Setting();
                using (var context = new SynergeticContext())
                {
                    Config config = context.Configs.Where(t => t.active_flag).FirstOrDefault();
                    if (config == null)
                    {
                        throw new Exception("config is not set. Please review the config table .");
                    }
                    else
                    {
                        //jwtToken = config.jwt_token; // This config called here holds the jwt_token too.

                        // The below title comes from the screen.
                        meeting_topic = meeting_topic.Replace("{Staff Name}", "{0}");
                        meetingBaseObject.topic = string.Format(meeting_topic, host_staff_name);


                        meetingBaseObject.type = config.meeting_type; //   2; //1 instant meeting, 2 scheduled, 3 recurring w/o fixed time, 8, recurring with fixed time.
                        meetingBaseObject.start_time = string.Format("{0}T{1}", ptiDate.ToString("yyyy-MM-dd"), config.start_time); //string.Format("{0}T08:30:00", ptiDate.ToString("yyyy-MM-dd"));// "2020-05-26T08:30:00";
                        meetingBaseObject.duration = config.meeting_duration;// 450; // 7 hours 30 minutes.
                        
                        if (config.schedule_for != null && config.schedule_for != "")
                            meetingBaseObject.schedule_for = config.schedule_for;

                        meetingBaseObject.timezone = config.meeting_time_zone;// "Australia/Sydney";
                        if (config.password != null && config.password != "")
                            meetingBaseObject.password = "";

                        if (config.meeting_agenda != null && config.meeting_agenda != "")
                            meetingBaseObject.agenda = config.meeting_agenda;// "Class Teacher Parent Interview";

                        // We don't use the below.
                        // recurrence
                        //Recurrence recurrence = new Recurrence();
                        //recurrence.type =
                        //meetingBaseObject.recurrence = recurrence;

                        // setting ///////////////////////////////////////////////////////                
                        setting.host_video = config.host_video;// true;
                        setting.participant_video = config.participant_video;// true;
                        //setting.cn_meeting = false;
                        //setting.in_meeting = false;
                        setting.join_before_host = config.join_before_host;
                        setting.mute_upon_entry = config.mute_upon_entry;

                        setting.watermark = config.watermark;
                        setting.use_pmi = config.use_pmi;

                        setting.approval_type = config.approval_type;// 0;// 0 automatic, 1 manual, 2 no registration required.

                        if (config.registration_type != null )
                            setting.registration_type = (int)config.registration_type;// only for recurring meeting.

                        setting.audio = config.audio;// "both"; //both, telephony, voip
                        setting.auto_recording = config.auto_recording;// "none"; //local, cloud, none
                        
                        setting.enforce_login = config.enforce_login;
                        setting.enforce_login_domains = config.enforce_login_domains;
                        
                        setting.alternative_hosts = config.alternative_hosts;
                        setting.close_registration = config.close_registration;
                        setting.waiting_room = config.waiting_room;// true;

                        string[] global_dial_in_countries= { };
                        if (config.global_dial_countries != null && config.global_dial_countries != "")
                            global_dial_in_countries = config.global_dial_countries.Split(',');
                        setting.global_dial_in_countries = global_dial_in_countries;

                        setting.contact_name = config.contact_name;
                        setting.contact_email = config.contact_email;
                        setting.registrants_email_notification = config.registraints_email_notification;
                        setting.meeting_authentication = config.meeting_authentication;
                        setting.authentication_option = config.authentication_option;
                        setting.authentication_domains = config.authentication_domains;
                        ////setting.additional_data_center_regions = string[];

                    }
                }
                meetingBaseObject.settings = setting;
                                
                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Post, url);
                var content = new StringContent(JsonConvert.SerializeObject(meetingBaseObject), Encoding.UTF8, "application/json");
                request.Content = content;
                
                //Add the token in Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);
                
                response = await httpClient.SendAsync(request);
                
                Meeting meeting;
                
                if (response.IsSuccessStatusCode)
                {
                    var contentReturned = await response.Content.ReadAsStringAsync();
                    meeting = JsonConvert.DeserializeObject<Meeting>(contentReturned);

                    return meeting;

                }
                else if ((int)response.StatusCode == 300)
                    throw new Exception("Invalid enforce_login_domains, separate multiple domains by semicolon.");
                else if ((int)response.StatusCode == 404)
                    throw new Exception("User not found.");
              
                else if ((int)response.StatusCode == 401)
                    throw new Exception(response.StatusCode + ". Check if the token is valid.");
                else
                {
                    throw new Exception(string.Format("Api call failed. {0}-{1}", (int)response.StatusCode, response.StatusCode));
                }
                //return new Meeting();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                //Debug.Print(e.Message);
            }
            //return new Meeting();
        }
        /*
         * Not used.
        */
        public static async Task<HttpResponseMessage> SendRequest(HttpMethod method, string endPoint, string accessToken, dynamic content = null)
        {
            HttpResponseMessage response = null;
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(method, endPoint))
                {
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    if (content != null)
                    {
                        string c;
                        if (content is string)
                            c = content;
                        else
                            c = JsonConvert.SerializeObject(content);
                             
                        request.Content = new StringContent(c, Encoding.UTF8, "application/json");
                    }

                    response = await client.SendAsync(request).ConfigureAwait(false);
                }
            }
            return response;

        }
        /*
         * Initialize some dropdown boxes here.         
        */
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new SynergeticContext()) // 
                {
                    context.Database.Connection.Open();// somehow exceptions not raised in the normal code if a connection string is wrong. Therefore i added this code here to catch an error (exeption).
                    context.Database.Connection.Close();
                }

                this.Width = 700;
                this.Height = 500;

                RefreshConfiguration();

                // Set the check box of CreateNewSchedule radio button to default. False.
                rbCreateNewScheduleNo.Checked = true;

            }            
            catch (Exception ex)
            {
                MessageBox.Show(this, "There is an error caught. " + (ex.Message.Length > 150 ? ex.Message.Substring(0, 149) : ex.Message));
            }

        }
        /*
         * Delete a meeting.         
        */
        private async void btnDeleteMeetings_Click(object sender, EventArgs e)
        {
            chkDeleteExistingMeeting.Checked = false; // Set the check box back to default.

            try {
                string validationMessage = ValidateZoomUserDataFromSynergetic();
                if (validationMessage != "")
                {
                    MessageBox.Show(validationMessage);
                    return;
                }

                string jwtToken = await GetJwtToken();
                if (jwtToken == "")
                {
                    MessageBox.Show("Please configure a valid jwtToken from Zoom developer site.");
                    dtpPTI.Focus();
                    return;
                }
                lstResults.Items.Clear();
                progressBar.Value = 0;
                progressBar.Minimum = 0; progressBar.Maximum = 0;

                progressBarSimple.Value = 0;
                progressBarSimple.Minimum = 0; progressBarSimple.Maximum = 10;

                lblProcessed.Text = "Processed: 0";
                lblTotal.Text = "Total: 0";
                lblUpdated.Text = "Deleted: 0";

                int countDeleted = 0;

                DateTime ptiDate = dtpPTI.Value;
                
                lblMsg.Visible = true;
                using (var context = new SynergeticContext())
                {
                    // Get a list of zoom candidates for PTI.
                    var vUsers = context.vZoomUsers.OrderBy(t => t.last_name).ThenBy(t => t.first_name);
                    lblTotal.Text = "Total: " + vUsers.Count().ToString();
                    progressBar.Maximum = vUsers.Count();

                    if (MessageBox.Show(this, "Do you like to delete all PTI meetings for people in your Synergetic Tag list? (Total User Count = " + vUsers.Count().ToString() + ")", "Delete Zoom Meeting", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;

                    int config_seq = await GetActiveConfigSeq(); // current active schedule seq;

                    foreach (var vUser in vUsers)
                    {
                        progressBarSimple.Value = 2;
                        
                        if (vUser.meeting_id != null && vUser.meeting_id > 0)
                        {
                            var deletedHttpStatusCode = await DeleteMeeting((long)vUser.meeting_id, jwtToken);
                            progressBarSimple.Value = 5;
                            if (deletedHttpStatusCode == 204 || deletedHttpStatusCode == 404)
                            {
                                using (var context2 = new SynergeticContext())
                                {
                                    ZoomUser user = context2.ZoomUsers.Where(t => t.email == vUser.email && t.active_flag && t.config_seq == config_seq).FirstOrDefault();
                                    if (user != null)
                                    {

                                        //user.first_name = vUser.first_name; // no need to update again.
                                        //user.last_name = vUser.last_name;
                                        //user.ActiveFlag = true;
                                        //user.email = vUser.email;
                                        user.meeting_id = null;
                                        user.join_url = null;
                                        user.start_url = null;
                                        user.start_time = null;
                                        user.active_flag = true;
                                        user.datetime_last_modified = System.DateTime.Now;

                                        await context2.SaveChangesAsync();
                                    }
                                }

                            }
                            progressBarSimple.Value = 8;

                            countDeleted++;

                            if (deletedHttpStatusCode == 204)  //204 if a meeting is deleted.
                            {
                                lblUpdated.Text = "Deleted: " + countDeleted.ToString();

                                ListItem list = new ListItem();
                                list.Text = string.Format("A meeting for {0} {1} was deleted.", vUser.first_name, vUser.last_name);
                                lstResults.Items.Add(list);
                            }
                        }                        
                        else
                        {
                            // do nothing because there is no meeting to be deleted.
                        }
                        if (progressBar.Value < progressBar.Maximum)
                            progressBar.Value = progressBar.Value + 1;

                        progressBarSimple.Value = 10;

                        lblProcessed.Text = "Processed: " + progressBar.Value.ToString();

                    }
                }
                
                MessageBox.Show(this, "Deleting Zoom Meetings is complete.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "There is an error caught. " + (ex.Message.Length > 150 ? ex.Message.Substring(0, 149) : ex.Message));
            }

            lblMsg.Visible = false;
        }
        /*
         * Delete a meeting in the Zoom meeting.
        */
        private async Task<int> DeleteMeeting(long meeting_id, string jwtToken)
        {
            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;

            try
            {                                
                string urlTemp = string.Format("https://api.zoom.us/v2/meetings/{0}", meeting_id);

                var builder = new UriBuilder(urlTemp);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                builder.Query = query.ToString();
                string url = builder.ToString();
                                
                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Delete, url);
                                
                //Add the token in Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);
                                
                
                response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return 204; //deleted
                }
                else if ((int)response.StatusCode == 400)
                    throw new Exception("You cannot delete the meeting. Meeting ID =" + meeting_id.ToString());
                else if ((int)response.StatusCode == 404)
                    return 404; // throw new Exception("Meeting not found.");
                
                else if ((int)response.StatusCode == 401)
                    throw new Exception(response.StatusCode + ". Check if the token is valid.");
                else
                {
                    throw new Exception(string.Format("Api call failed. {0}-{1}", (int)response.StatusCode, response.StatusCode));
                }
                //return 400;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //MessageBox.Show(this, "There is an error caught. " + (ex.Message.Length > 50 ? ex.Message.Substring(0, 49) : ex.Message));
            }

            
            //return 400;

        }
        /*
         * Not used. Save Configuration values in Synergetic database. Simple version.
        */
        private async void SaveConfig(DateTime meeting_date, string meeting_topic)
        {
            try
            {
                using (var context = new SynergeticContext())
                {
                    Config config = context.Configs.Where(t => t.active_flag).FirstOrDefault();
                    if (config == null)
                    {
                        throw new Exception("Config table is blank.");
                    }

                    config.meeting_datetime = meeting_date;
                    config.meeting_topic= meeting_topic;
                    

                    Config[] configs = { config };
                    context.Configs.AddOrUpdate(configs);
                    await context.SaveChangesAsync();
                }
            }
         
            catch (Exception ex)
            {
                MessageBox.Show(this, "There is an error caught. " + (ex.Message.Length > 150 ? ex.Message.Substring(0, 149) : ex.Message));
            }

        }
        /*
         * Get a Jwt Token only easily.
        */
        private async Task<string> GetJwtToken()
        {
            try
            {
                using (var context = new SynergeticContext())
                {
                    Config config = await context.Configs.Where(t=>t.active_flag).FirstOrDefaultAsync();
                    
                    if (config == null || config.jwt_token == "")
                        throw new Exception("jwt is not set. Please add it to the user table from Zoom developer account.");
                    return config.jwt_token;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //MessageBox.Show(this, "There is an error caught. " + (ex.Message.Length > 150 ? ex.Message.Substring(0, 149) : ex.Message));
            }

        }
        /*
         * Get a Jwt Token only easily.
        */
        private async Task<int> GetActiveConfigSeq()
        {
            try
            {
                using (var context = new SynergeticContext())
                {
                    Config config = await context.Configs.Where(t => t.active_flag).FirstOrDefaultAsync();

                    if (config == null || config.jwt_token == "")
                        throw new Exception("There is no active schedule.");
                    return config.seq;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //MessageBox.Show(this, "There is an error caught. " + (ex.Message.Length > 150 ? ex.Message.Substring(0, 149) : ex.Message));
            }
                        
        }


        /*
         * Refresh Configuration values to be used in this application or to be displayed on screen.
        */

        private void btnRefreshConfig_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you like to refresh the list without saving the changes?", "Refresh", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            try
            {
                // Set the check box of CreateNewSchedule radio button to default. False.
                rbCreateNewScheduleNo.Checked = true;

                RefreshConfiguration();
            }

            catch (Exception ex)
            {
                MessageBox.Show(this, "There is an error caught. " + (ex.Message.Length > 150 ? ex.Message.Substring(0, 149) : ex.Message));
            }

        }
        /*
         * Trigger updaing Zoom meetings.
        */
        private async void btnUpdateMeetings_Click(object sender, EventArgs e)
        {
            chkDeleteExistingMeeting.Checked = false; // set the check box back to default.

            try
            {
                string validationMessage = ValidateZoomUserDataFromSynergetic();
                if (validationMessage != "")
                {
                    MessageBox.Show(validationMessage);
                    return;
                }

                string jwtToken = await GetJwtToken();
                if (jwtToken == "")
                {
                    MessageBox.Show("Please configure a valid jwtToken from Zoom developer site.");                    
                    return;
                }
                else if (dtpPTIFromDB.Value <= System.DateTime.Now)
                {
                    MessageBox.Show("Please select a meeting date later than now.");                    
                    return;
                }

                if (txtMeetingTopicFromDB.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a title.");                    
                    return;
                }

                if (txtMeetingTopicFromDB.Text.Trim() != "" && txtMeetingTopicFromDB.Text.IndexOf("{Staff Name}") < 0)
                {
                    MessageBox.Show("Please inlcude the tag {Staff Name} in the title.");                    
                    return;
                }
                

                lstResults.Items.Clear();
                progressBar.Value = 0;
                progressBar.Minimum = 0; progressBar.Maximum = 0;

                progressBarSimple.Value = 0;
                progressBarSimple.Minimum = 0; progressBarSimple.Maximum = 10;

                lblProcessed.Text = "Processed: 0";
                lblTotal.Text = "Total: 0";
                lblUpdated.Text = "Updated: 0";

                int countUpdated = 0;


                lblMsg.Visible = true;

                DateTime ptiDate = dtpPTI.Value;
                using (var context = new SynergeticContext())
                {
                    // get a list of zoom candidates for PTI.
                    var vUsers = context.vZoomUsers.OrderBy(t => t.last_name).ThenBy(t => t.first_name);
                    lblTotal.Text = "Total: " + vUsers.Count().ToString();
                    progressBar.Maximum = vUsers.Count();


                    if (MessageBox.Show(this, "Do you like to update a PTI meeting for people in your Synergetic Tag list?  (Total User Count = " + vUsers.Count().ToString() + ")", "Update Zoom Meeting", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;

                    int config_seq = await GetActiveConfigSeq(); // current active schedule seq;

                    foreach (var vUser in vUsers)
                    {
                        progressBarSimple.Value = 2;


                        //Find an existing meeting.
                        bool ExistsFlag = false;
                        if (vUser.meeting_id > 0)
                            ExistsFlag = await MeetingExists((long)vUser.meeting_id, jwtToken);

                        progressBarSimple.Value = 8;

                        // Update.
                        if (vUser.meeting_id > 0 && ExistsFlag)
                        {
                            // Update an exiting meeting with a new configuration values.
                            bool successFlag = await UpdateMeeting((long)vUser.meeting_id, string.Format("{0} {1}", vUser.first_name, vUser.last_name), ptiDate, txtMeetingTopic.Text.Trim(), jwtToken);

                            progressBarSimple.Value = 9;
                                                        
                            // If a new meeting is update, then add it to a user table in Synergetic.
                            if (successFlag )
                            {
                                countUpdated++;
                                lblUpdated.Text = "Updated: " + countUpdated;

                                using (var context2 = new SynergeticContext())
                                {
                                    // Update the Synergetic user table to hold a meeting details.
                                    ZoomUser user = context2.ZoomUsers.Where(t => t.email == vUser.email && t.active_flag && t.config_seq == config_seq).FirstOrDefault();
                                    if (user == null)
                                    {
                                        throw new Exception("Zoom User is not found.");                                       
                                    }
                                    user.first_name = vUser.first_name;
                                    user.last_name = vUser.last_name;
                                    
                                    user.email = vUser.email;
                                    user.staff_id = vUser.staff_id;
                                    user.staff_code = vUser.staff_code;

                                    user.active_flag = true;
                                    user.datetime_last_modified = System.DateTime.Now;

                                    ZoomUser[] Users2 = { user };
                                    context2.ZoomUsers.AddOrUpdate(Users2);
                                    await context2.SaveChangesAsync();
                                }

                                // Add an item.
                                ListItem list = new ListItem();
                                list.Text = string.Format("A meeting for {0} {1} was updated.", vUser.first_name, vUser.last_name);
                                lstResults.Items.Add(list);
                            }
                            else
                            {
                                // Add an item.
                                ListItem list = new ListItem();
                                list.Text = string.Format("Updating a meeting for {0} {1} failed.", vUser.first_name, vUser.last_name);
                                lstResults.Items.Add(list);
                            }


                        }
                        else if (vUser.meeting_id > 0 && !ExistsFlag)
                        {
                            ListItem list = new ListItem();
                            list.Text = string.Format("A meeting for {0} {1} does not exist.", vUser.first_name, vUser.last_name);
                            lstResults.Items.Add(list);
                        }
                        else
                        {
                            ListItem list = new ListItem();
                            list.Text = string.Format("A meeting for {0} {1} does not exist.", vUser.first_name, vUser.last_name);
                            lstResults.Items.Add(list);
                        }

                        if (progressBar.Value < progressBar.Maximum)
                            progressBar.Value = progressBar.Value + 1;

                        lblProcessed.Text = "Processed: " + progressBar.Value.ToString();
                        progressBarSimple.Value = 10;
                    }
                }
            
                MessageBox.Show(this, "Updating Zoom Meetings is complete.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "There is an error caught. " + (ex.Message.Length > 150 ? ex.Message.Substring(0, 149) : ex.Message));
            }
            lblMsg.Visible = false;
        }
        /*
         * Update an existing meeting.
        */
        private async Task<bool> UpdateMeeting(long meeting_id, string host_staff_name, DateTime ptiDate, string meeting_topic, string jwtToken)
        {
            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;

            try
            {
                //"https://api.zoom.us/v2/meetings/{meetingId}"                
                string urlTemp = string.Format("https://api.zoom.us/v2/meetings/{0}", meeting_id);
                var builder = new UriBuilder(urlTemp);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                builder.Query = query.ToString();
                string url = builder.ToString();

                // Prepare Request Body.
                MeetingBaseObject meetingBaseObject = new MeetingBaseObject();
                // setting
                Setting setting = new Setting();
                using (var context = new SynergeticContext())
                {
                    Config config = context.Configs.Where(t => t.active_flag).FirstOrDefault();
                    if (config == null)
                    {
                        throw new Exception("config is not set. Please review the config table .");
                    }
                    else
                    {
                        //jwtToken = config.jwt_token;

                        // the below title comes from the screen.
                        meeting_topic = meeting_topic.Replace("{Staff Name}", "{0}");
                        meetingBaseObject.topic = string.Format(meeting_topic, host_staff_name);


                        meetingBaseObject.type = config.meeting_type; //   2; //1 instant meeting, 2 scheduled, 3 recurring w/o fixed time, 8, recurring with fixed time.
                        meetingBaseObject.start_time = string.Format("{0}T{1}", ptiDate.ToString("yyyy-MM-dd"), config.start_time); //string.Format("{0}T08:30:00", ptiDate.ToString("yyyy-MM-dd"));// "2020-05-26T08:30:00";
                        meetingBaseObject.duration = config.meeting_duration;// 450; // 7 hours 30 minutes.

                        if (config.schedule_for != null && config.schedule_for != "")
                            meetingBaseObject.schedule_for = config.schedule_for;

                        meetingBaseObject.timezone = config.meeting_time_zone;// "Australia/Sydney";
                        if (config.password != null && config.password != "")
                            meetingBaseObject.password = "";

                        if (config.meeting_agenda != null && config.meeting_agenda != "")
                            meetingBaseObject.agenda = config.meeting_agenda;// "Class Teacher Parent Interview";

                        // recurrence
                        //Recurrence recurrence = new Recurrence();
                        //recurrence.type =
                        //meetingBaseObject.recurrence = recurrence;

                        // setting ///////////////////////////////////////////////////////                
                        setting.host_video = config.host_video;// true;
                        setting.participant_video = config.participant_video;// true;
                        //setting.cn_meeting = false;
                        //setting.in_meeting = false;
                        setting.join_before_host = config.join_before_host;
                        setting.mute_upon_entry = config.mute_upon_entry;

                        setting.watermark = config.watermark;
                        setting.use_pmi = config.use_pmi;

                        setting.approval_type = config.approval_type;// 0;// 0 automatic, 1 manual, 2 no registration required.

                        if (config.registration_type != null)
                            setting.registration_type = (int)config.registration_type;// only for recurring meeting.

                        setting.audio = config.audio;// "both"; //both, telephony, voip
                        setting.auto_recording = config.auto_recording;// "none"; //local, cloud, none

                        setting.enforce_login = config.enforce_login;
                        setting.enforce_login_domains = config.enforce_login_domains;

                        setting.alternative_hosts = config.alternative_hosts;
                        setting.close_registration = config.close_registration;
                        setting.waiting_room = config.waiting_room;// true;

                        string[] global_dial_in_countries = { };
                        if (config.global_dial_countries != null && config.global_dial_countries != "")
                            global_dial_in_countries = config.global_dial_countries.Split(',');
                        setting.global_dial_in_countries = global_dial_in_countries;

                        setting.contact_name = config.contact_name;
                        setting.contact_email = config.contact_email;
                        setting.registrants_email_notification = config.registraints_email_notification;
                        setting.meeting_authentication = config.meeting_authentication;
                        setting.authentication_option = config.authentication_option;
                        setting.authentication_domains = config.authentication_domains;
                        ////setting.additional_data_center_regions = string[];

                    }
                }
                meetingBaseObject.settings = setting;

                //httpClient.DefaultRequestHeaders
                //    .Accept
                //    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var method = new HttpMethod("PATCH");
                var request = new System.Net.Http.HttpRequestMessage(method, url);
                var content = new StringContent(JsonConvert.SerializeObject(meetingBaseObject), Encoding.UTF8, "application/json");
                request.Content = content;
                
                //Add the token in Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);

                response = await httpClient.SendAsync(request);

                Meeting meeting;

                
                if (response.IsSuccessStatusCode)
                {
                    var contentReturned = await response.Content.ReadAsStringAsync();
                    meeting = JsonConvert.DeserializeObject<Meeting>(contentReturned);

                    return true;

                }
                else if ((int)response.StatusCode == 300)
                    throw new Exception("Invalid enforce_login_domains, separate multiple domains by semicolon..");
                else if ((int)response.StatusCode == 400)
                    throw new Exception("User not found on this account.");
                else if ((int)response.StatusCode == 404)
                    return false; // throw new Exception("Meeting not found.");
                else if ((int)response.StatusCode == 401)
                    throw new Exception(response.StatusCode + ". Check if the token is valid.");
                else
                {
                    throw new Exception(string.Format("Api call failed. {0}-{1}", (int)response.StatusCode, response.StatusCode));
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
        /*
         * Expand the screen size to display the configuration management area.
        */
        private void btnConfigurationExpand_Click(object sender, EventArgs e)
        {
            // Show the configuration section.
            this.Width = 1450;
            this.Height = 900;

            // Set the check box of CreateNewSchedule radio button to default. False.
            rbCreateNewScheduleNo.Checked = true;

            RefreshConfiguration();
        }
        /*
         * Shrink the screen size to hide the configuration management area.
        */
        private void btnConfigurationShrink_Click(object sender, EventArgs e)
        {
            this.Width = 700;
            this.Height = 500;

            // this will refresh the meeting date and meeting topic.
            RefreshConfiguration();

            // Set the check box of CreateNewSchedule radio button to default. False.
            rbCreateNewScheduleNo.Checked = true;

        }

        // Refresh the screen with data from the Synergetic configuration db table.        
        private void RefreshConfiguration()
        {
            try
            {             
                using (var context = new SynergeticContext())
                {
                    

                    IList<ApprovalType> ApprovalTypes = context.ApprovalTypes.OrderBy(t=>t.Description).ToList();
                    ddlApprovalType.Items.Clear();
                    ListItem item = new ListItem("<Choose..>", "");
                    ddlApprovalType.Items.Add(item);
                    foreach (var dbItem in ApprovalTypes)
                    {
                        item = new ListItem(dbItem.Description, dbItem.Code.ToString());
                        ddlApprovalType.Items.Add(item);
                    }

                    IList<Audio> Audios = context.Audios.OrderBy(t => t.Description).ToList();
                    ddlAudio.Items.Clear();
                    item = new ListItem("<Choose..>", "");
                    ddlAudio.Items.Add(item);
                    foreach (var dbItem in Audios)
                    {
                        item = new ListItem(dbItem.Description, dbItem.Code);
                        ddlAudio.Items.Add(item);
                    }

                    IList<AutoRecording> AutoRecordings = context.AutoRecordings.OrderBy(t => t.Description).ToList();
                    ddlAutoRecording.Items.Clear();
                    item = new ListItem("<Choose..>", "");
                    ddlAutoRecording.Items.Add(item);
                    foreach (var dbItem in AutoRecordings)
                    {
                        item = new ListItem(dbItem.Description, dbItem.Code);
                        ddlAutoRecording.Items.Add(item);
                    }

                    IList<MeetingType> MeetingTypes = context.MeetingTypes.OrderBy(t => t.Description).ToList();
                    ddlMeetingType.Items.Clear();
                    item = new ListItem("<Choose..>", "");
                    ddlMeetingType.Items.Add(item);
                    foreach (var dbItem in MeetingTypes)
                    {
                        item = new ListItem(dbItem.Description, dbItem.Code.ToString());
                        ddlMeetingType.Items.Add(item);
                    }

                    IList<RegistrationType> RegistrationTypes = context.RegistrationTypes.OrderBy(t => t.Description).ToList();
                    ddlRegistrationType.Items.Clear();
                    item = new ListItem("<Choose..>", "");
                    ddlRegistrationType.Items.Add(item);
                    foreach (var dbItem in RegistrationTypes)
                    {
                        item = new ListItem(dbItem.Description, dbItem.Code.ToString());
                        ddlRegistrationType.Items.Add(item);
                    }

                    Config config = context.Configs.Where(t=>t.active_flag).FirstOrDefault();
                    if (config != null)
                    {
                        txtScheduleSeq.Text = config.seq.ToString();
                             
                        txtJWTToken.Text = config.jwt_token;
                        txtMeetingTopic.Text = config.meeting_topic;
                        txtMeetingTopicFromDB.Text = config.meeting_topic;

                        // set Meeting Type.
                        foreach (ListItem meetingType in ddlMeetingType.Items)
                        {
                            if (meetingType.Value == config.meeting_type.ToString())
                            {
                                ddlMeetingType.SelectedItem =meetingType;
                                break;
                            }                                
                        }

                        // start time (only time info = T23:59:59 local time.)
                        txtMeetingStartTime.Text = config.start_time;
                        dtpPTI.Value = config.meeting_datetime;
                        dtpPTIFromDB.Value = config.meeting_datetime;

                        txtMeetingDuration.Text = config.meeting_duration.ToString();                        
                        txtScheduleFor.Text = config.schedule_for;
                        txtTimeZone.Text = config.meeting_time_zone;

                        txtPassword.Text = config.password;
                        txtMeetingAgenda.Text = config.meeting_agenda;

                        rbHostVideoYes.Checked = config.host_video;
                        rbHostVideoNo.Checked = !config.host_video;

                        rbPartticipantVideoYes.Checked = config.participant_video;
                        rbPartticipantVideoNo.Checked = !config.participant_video;

                        rbJoinBeforeHostYes.Checked = config.join_before_host;
                        rbJoinBeforeHostNo.Checked = !config.join_before_host;

                        rbMuteUponEntryYes.Checked = config.mute_upon_entry;
                        rbMuteUponEntryNo.Checked = !config.mute_upon_entry;

                        rbWaterMarkYes.Checked = config.watermark;
                        rbWaterMarkNo.Checked = !config.watermark;

                        rbUsePMIYes.Checked = config.use_pmi;
                        rbUsePMINo.Checked = !config.use_pmi;

                        // set approval type.
                        foreach (ListItem item2 in ddlApprovalType.Items)
                        {
                            if (item2.Value == config.approval_type.ToString())
                            {
                                ddlApprovalType.SelectedItem = item2;
                                break;
                            }
                        }
                        // set registration Type.
                        foreach (ListItem item2 in ddlRegistrationType.Items)
                        {
                            if (item2.Value == config.registration_type.ToString())
                            {
                                ddlRegistrationType.SelectedItem = item2;
                                break;
                            }
                        }
                        // set audio.
                        foreach (ListItem item2 in ddlAudio.Items)
                        {
                            if (item2.Value == config.audio)
                            {
                                ddlAudio.SelectedItem = item2;
                                break;
                            }
                        }
                        // set auto recording.
                        foreach (ListItem item2 in ddlAutoRecording.Items)
                        {
                            if (item2.Value == config.auto_recording)
                            {
                                ddlAutoRecording.SelectedItem = item2;
                                break;
                            }
                        }

                        txtAlternativeHosts.Text = config.alternative_hosts;

                        rbEnforceLoginYes.Checked = config.enforce_login;
                        rbEnforceLoginNo.Checked = !config.enforce_login;
                        txtEnforceLoginDomains.Text = config.enforce_login_domains;

                        rbCloseRegistrationYes.Checked = config.close_registration;
                        rbCloseRegistrationNo.Checked = !config.close_registration;

                        rbWaitingRoomYes.Checked = config.waiting_room;
                        rbWaitingRoomNo.Checked = !config.waiting_room;

                        txtGlobalDialCountries.Text = config.global_dial_countries;
                        txtcontactName.Text = config.contact_name;
                        txtContactEmail.Text = config.contact_email;

                        rbRegistrantsEmailNotificationYes.Checked = config.registraints_email_notification;
                        rbRegistrantsEmailNotificationNo.Checked = !config.registraints_email_notification;

                        rbMeetingAuthenticationYes.Checked = config.meeting_authentication;
                        rbMeetingAuthenticationNo.Checked = !config.meeting_authentication;

                        txtAuthenticationOption.Text = config.authentication_option;
                        txtAuthenticationDomains.Text = config.authentication_domains;

                    }


                }



            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(this, "There is an error caught. " + (ex.Message.Length > 150 ? ex.Message.Substring(0, 149) : ex.Message));
            }
            catch (SqlException sqlE)
            {
                MessageBox.Show(this, "There is an error caught. " + (sqlE.Message.Length > 150 ? sqlE.Message.Substring(0, 149) : sqlE.Message));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "There is an error caught. " + (ex.Message.Length > 150 ? ex.Message.Substring(0, 149) : ex.Message));
            }
        }
        /*
         * Save changes of configuration management area.
        */
        private void btnSaveConfig_Click(object sender, EventArgs e)
        {

            // New schedule will be created.
            if (rbCreateNewScheduleNo.Checked && MessageBox.Show(this, "Do you like to save the changes?", "Save", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            // An active existing schedule will be updated.
            if (rbCreateNewScheduleYes.Checked && MessageBox.Show(this, "Do you like to create a new schedule?", "Save", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (txtJWTToken.Text == "")
            {
                MessageBox.Show("Please enter a JWT token.");
                txtJWTToken.Focus();
                return;                    
            }
            
            if (this.txtMeetingTopic.Text == "")
            {
                MessageBox.Show("Please enter a meeting topic.");
                txtMeetingTopic.Focus();
                return;
            }
            if (txtMeetingTopic.Text.Trim() != "" && txtMeetingTopic.Text.IndexOf("{Staff Name}") < 0)
            {
                MessageBox.Show("Please inlcude the tag {Staff Name} in the title. eg. {Staff Name} PST Interview 23 Nov 2030.");
                txtMeetingTopic.Focus();
                return;
            }

            if (this.ddlMeetingType.SelectedIndex <= 0 )
            {
                MessageBox.Show("Please select a meeting type.");
                ddlMeetingType.Focus(); 
                return;
            }
            TimeSpan tempTimeSpan;
            if (this.txtMeetingStartTime.Text == "" || !TimeSpan.TryParse(txtMeetingStartTime.Text, out tempTimeSpan))
            {
                MessageBox.Show("Please enter a valid start time.");
                txtMeetingStartTime.Focus();
                return;
            }
            if (rbCreateNewScheduleYes.Checked && dtpPTI.Value <= System.DateTime.Now)
            {
                MessageBox.Show("Please select a meeting date later than now.");
                dtpPTI.Focus();
                return;
            }

            int intDuration = 0;            
            if (this.txtMeetingDuration.Text == "" || !int.TryParse(this.txtMeetingDuration.Text, out intDuration) || intDuration<=0)
            {
                MessageBox.Show("Please enter a valid meeting duration.");
                txtMeetingDuration.Focus();
                return;
            }
            if ( !rbHostVideoYes.Checked && !rbHostVideoNo.Checked)
            {
                MessageBox.Show("Please select an item of Host Video.");
                gbHostVideo.Focus();
                return;
            }
            if (!rbPartticipantVideoYes.Checked && !rbPartticipantVideoNo.Checked)
            {
                MessageBox.Show("Please select an item of Host Video.");
                gbParticipantVideo.Focus();
                return;
            }
            if (!rbJoinBeforeHostYes.Checked && !rbJoinBeforeHostNo.Checked)
            {
                MessageBox.Show("Please select an item of Host Video.");
                gbJoinBeforeHost.Focus();
                return;
            }
            if (!rbWaterMarkYes.Checked && !rbWaterMarkNo.Checked)
            {
                MessageBox.Show("Please select an item of Host Video.");
                gbWaterMark.Focus();
                return;
            }
            if (!rbUsePMIYes.Checked && !rbUsePMINo.Checked)
            {
                MessageBox.Show("Please select an item of Host Video.");
                gbUsePMI.Focus();
                return;
            }
            if (!rbMuteUponEntryYes.Checked && !rbMuteUponEntryNo.Checked)
            {
                MessageBox.Show("Please select an item of Host Video.");
                gbMuteUponEntry.Focus();
                return;
            }
            if (this.ddlApprovalType.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select an approval type.");
                ddlApprovalType.Focus();
                return;
            }
            if (!rbEnforceLoginYes.Checked && !rbEnforceLoginNo.Checked)
            {
                MessageBox.Show("Please select an item of Enforce Login");
                gbEnforceLogin.Focus();
                return;
            }
            if (rbEnforceLoginYes.Checked && txtEnforceLoginDomains.Text =="")
            {
                MessageBox.Show("Please enter a valid login domain.");
                txtEnforceLoginDomains.Focus();
                return;
            }
            if (this.ddlAudio.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select an audio.");
                ddlAudio.Focus();
                return;
            }
            if (this.ddlAutoRecording.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select an auto recording.");
                ddlAutoRecording.Focus();
                return;
            }
            if (!rbCloseRegistrationYes.Checked && !rbCloseRegistrationNo.Checked)
            {
                MessageBox.Show("Please select an item of Host Video.");
                gbCloseRegistration.Focus();
                return;
            }
            if (!rbWaitingRoomYes.Checked && !rbWaitingRoomNo.Checked)
            {
                MessageBox.Show("Please select an item of Host Video.");
                gbWaitingRoom.Focus();
                return;
            }

            try
            {
                using (var context = new SynergeticContext())
                {
                    Config config = context.Configs.Where(t=>t.active_flag).FirstOrDefault();
                    if (rbCreateNewScheduleYes.Checked && config != null) // Disable an existing active schedule if exists.
                    {
                        config.active_flag = false;
                        context.Configs.AddOrUpdate(config);
                        context.SaveChanges();
                    }
                        
                    if (rbCreateNewScheduleYes.Checked || config == null) // Create a new schedule if the check box is ticked or if there is no existing record.
                    {
                        config = new Config();

                        // This values will be configured via the main screen in the left. timezone can be configured in DB table.
                        //config.meeting_topic = "{Staff Name} PST Interview " + System.DateTime.Today.ToString("dd MMM yyyy");
                        //config.meeting_datetime = System.DateTime.Now;
                        config.meeting_time_zone = "Australia/Sydney";
                        
                    }
                    
                    config.jwt_token = txtJWTToken.Text;
                    config.meeting_topic = txtMeetingTopic.Text;

                    config.meeting_type = int.Parse(((ListItem)ddlMeetingType.SelectedItem).Value);
                    config.start_time = txtMeetingStartTime.Text;
                    config.meeting_datetime = dtpPTI.Value;
                    config.meeting_duration = int.Parse(txtMeetingDuration.Text);
                    config.schedule_for = txtScheduleFor.Text;
                    config.password = txtPassword.Text;

                    config.meeting_agenda = txtMeetingAgenda.Text;
                    
                    config.host_video = rbHostVideoYes.Checked;
                    config.participant_video = rbPartticipantVideoYes.Checked;

                    config.join_before_host = rbJoinBeforeHostYes.Checked;
                    config.mute_upon_entry = rbMuteUponEntryYes.Checked;
                    config.watermark = rbWaterMarkYes.Checked;
                    config.use_pmi = rbUsePMIYes.Checked;

                    
                    config.approval_type = int.Parse(((ListItem)ddlApprovalType.SelectedItem).Value);

                    if (ddlRegistrationType.SelectedIndex > 0)
                        config.registration_type = int.Parse(((ListItem)ddlRegistrationType.SelectedItem).Value);
                    else
                        config.registration_type = null;

                    config.audio = ((ListItem)ddlAudio.SelectedItem).Value;
                    config.auto_recording = ((ListItem)ddlAutoRecording.SelectedItem).Value;

                    config.alternative_hosts = txtAlternativeHosts.Text;

                    config.enforce_login = rbEnforceLoginYes.Checked;
                    
                    config.enforce_login_domains = rbEnforceLoginYes.Checked?txtEnforceLoginDomains.Text: "";

                    config.close_registration = rbCloseRegistrationYes.Checked;
                    config.waiting_room = rbWaitingRoomYes.Checked;

                    config.global_dial_countries = txtGlobalDialCountries.Text;
                    config.contact_name = txtcontactName.Text;
                    config.contact_email = txtContactEmail.Text;

                    config.registraints_email_notification = rbRegistrantsEmailNotificationYes.Checked;
                    config.meeting_authentication = rbMeetingAuthenticationYes.Checked;
                    config.authentication_option = txtAuthenticationOption.Text;
                    config.authentication_domains = txtAuthenticationDomains.Text;
                    config.active_flag = true;

                    context.Configs.AddOrUpdate(config);
                    context.SaveChanges();
                }

                // Set the check box of CreateNewSchedule radio button to default. False.
                rbCreateNewScheduleNo.Checked = true;

                RefreshConfiguration();// refresh the screen with new values from database.

                MessageBox.Show(this, "Saving the changes is complete.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private string ValidateZoomUserDataFromSynergetic()
        {
            try
            {
                using (var context = new SynergeticContext())
                {
                    // get a list of zoom candidates for PTI (vTagList).
                    var vUsers = context.vZoomUsers.OrderBy(t => t.last_name).ThenBy(t => t.first_name);
                    
                    foreach (var vUser in vUsers)
                    {
                        if (vUser.email == "")
                            return string.Format("The email is missing for {0}", vUser.staff_id);
                        if (vUser.last_name == "")
                            return string.Format("The last name is missing for {0}", vUser.staff_id);
                        if (vUser.first_name == "")
                            return string.Format("The first name is missing for {0}", vUser.staff_id);
                        if (vUser.staff_code == "")
                            return string.Format("The staff code is missing for {0}", vUser.staff_id);
                        
                    }

                    return "";
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error in ValidateZoom User Data " + e.Message);
            }
        }
    }
}
