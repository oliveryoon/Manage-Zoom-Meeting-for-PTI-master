using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Sick_Bed_Terminal_2019.Models;
using Sick_Bed_Terminal_2019.Models.SickBays;
using Sick_Bed_Terminal_2019.Models.Students;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
//using System.Windows.Media;//..Core;
using System.Windows.Threading;
using System.Reflection;
using System.Media;
using System.Diagnostics;
using System.Windows.Interop;

namespace Sick_Bed_Terminal_2019
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ////
        //// The Client ID is used by the application to uniquely identify itself to Azure AD.
        //// The Tenant is the name of the Azure AD tenant in which this application is registered.
        //// The AAD Instance is the instance of Azure, for example public Azure or Azure China.
        //// The Authority is the sign-in URL of the tenant.
        ////
        //const string tenant = "joeysorg.onmicrosoft.com";// "[Enter tenant name, e.g. contoso.onmicrosoft.com]";
        //const string tenantId = "315c37fc-27dc-4021-9c67-a92e8878d455";// "[Enter tenant name, e.g. contoso.onmicrosoft.com]";
        //const string clientId = "d446190b-740f-4ec3-b249-fc0b85f2ebbf";// "[Enter client ID as obtained from Azure Portal, e.g. 82692da5-a86f-44c9-9d53-2f88d52b478b]";
        //const string aadInstance = "https://login.microsoftonline.com/{0}";

        ////private static string appKey = "wDMzCHPBWklGr2RjSmrvml4l+8Pli06y7Eolg8MPUUQ=";        
        //private static string clientSecret = "N+fr2qatwEw7m30iU+gZrIbwk*ETMk+G";

        //static string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenantId);
        ////  
        //// To authenticate to the To Do list service, the client needs to know the service's App ID URI.
        //// To contact the To Do list service we need it's URL as well.
        ////
        //const string joeysWebApiResourceId = "https://joeysorg.onmicrosoft.com/JoeysWebApi";//"[Enter App ID URI of TodoListService, e.g. https://contoso.onmicrosoft.com/TodoListService]";
        ////const string joeysWebApiBaseAddress = "https://webapi.joeys.org";
        //private static string joeysWebApiBaseAddress = "http://localhost:5000";


        //private static IConfidentialClientApplication clientCredential = null;
        //private static HttpClient httpClient = new HttpClient();
        //private static AuthenticationContext authContext = null;

        //private Uri redirectURI = null;

        //Set the API Endpoint to Graph 'me' endpoint
        string graphAPIEndpoint = "https://graph.microsoft.com/v1.0/me";

        //Set the scope for API call to user.read
        //string[] scopes = new string[] { "user.read" };
        string[] scopes = new string[] { "https://joeysorg.onmicrosoft.com/WebApi/user_impersonation" };       


        private MediaPlayer mediaPlayer = new MediaPlayer();
        //private static HttpClient httpClient = new HttpClient();

        const string WebApiBaseAddress = "http://localhost:5000";
        //const string WebApiBaseAddress = "https://webapi.joeys.org";
        //private static AuthenticationContext authContext = null;

        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += timer_Tick;
            timer.Start();

        }
        void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToString("HH:mm:ss");
        }
        /// <summary>
        /// Call AcquireToken - to acquire a token requiring user to sign-in
        /// </summary>
        private async Task<string> GetToken()
        {
            AuthenticationResult authResult = null;
            var app = App.PublicClientApp;
            lblMsg.Content = string.Empty;

            var accounts = await app.GetAccountsAsync();
            var firstAccount = accounts.FirstOrDefault();

            try
            {
                authResult = await app.AcquireTokenSilent(scopes, firstAccount)
                    .ExecuteAsync();
            }
            catch (MsalUiRequiredException ex)
            {
                // A MsalUiRequiredException happened on AcquireTokenSilent. 
                // This indicates you need to call AcquireTokenInteractive to acquire a token
                System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");

                try
                {
                    authResult = await app.AcquireTokenInteractive(scopes)
                        .WithAccount(accounts.FirstOrDefault())
                        .WithParentActivityOrWindow(new WindowInteropHelper(this).Handle) // optional, used to center the browser on the window
                        .WithPrompt(Prompt.SelectAccount)
                        .ExecuteAsync();
                }
                catch (MsalException msalex)
                {
                    lblMsg.Content = $"Error Acquiring Token:{System.Environment.NewLine}{msalex}";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Content = $"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}";
                return "";
            }

            if (authResult != null)
            {
                //lblMsg.Content = await GetHttpContentWithToken(graphAPIEndpoint, authResult.AccessToken);
                //DisplayBasicTokenInfo(authResult);
                //this.SignOutButton.Visibility = Visibility.Visible;
                return authResult.AccessToken;
            }
            return "";
        }
        
        /// <summary>
        /// Perform an HTTP GET request to a URL using an HTTP Authorization header
        /// </summary>
        /// <param name="url">The URL</param>
        /// <param name="token">The token</param>
        /// <returns>String containing the results of the GET operation</returns>
        public async Task<string> GetHttpContentWithToken(string url, string token)
        {
            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;
            try
            {
                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);
                //Add the token in Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                response = await httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        /// <summary>
        /// Sign out the current user
        /// </summary>
        private async void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            var accounts = await App.PublicClientApp.GetAccountsAsync();
            if (accounts.Any())
            {
                try
                {
                    await App.PublicClientApp.RemoveAsync(accounts.FirstOrDefault());
                    //this.ResultText.Text = "User has signed-out";
                    //this.CallGraphButton.Visibility = Visibility.Visible;
                    //this.SignOutButton.Visibility = Visibility.Collapsed;
                }
                catch (MsalException ex)
                {
                    lblMsg.Content = $"Error signing-out user: {ex.Message}";
                }
            }
        }
        /// <summary>
        /// Display basic information contained in the token
        /// </summary>
        private void DisplayBasicTokenInfo(AuthenticationResult authResult)
        {
            //TokenInfoText.Text = "";
            if (authResult != null)
            {
                //TokenInfoText.Text += $"Username: {authResult.Account.Username}" + Environment.NewLine;
                //TokenInfoText.Text += $"Token Expires: {authResult.ExpiresOn.ToLocalTime()}" + Environment.NewLine;
            }
        }
        private async void txtCardNumber_KeyUp(object sender, KeyEventArgs e)
        {

            
            PasswordBox txt = (PasswordBox)txtCardNumber;
            if (e != null && e.Key == Key.Enter)
            {

                if (txt.Password != "")
                {
                    //get a token.
                    token = await GetToken();


                    int studentId = 0;
                    //txtCardNumber.Password = "8213";
                    int.TryParse(txtCardNumber.Password, out studentId);
                    StudentId = studentId;
                    DisplayStudentDetails(StudentId, token);
                    DisplayStudentMedicalIncidentStatus(StudentId, token);
                    //                    UpdateSickBay(Id);
                }



            }
            txt.Focus();
        }
        private int StudentId { get; set; }
        private string RequestedJobCode { get; set; }
        private string token { get; set; }

        private async void DisplayStudentDetails(int Id, string token)
        {
            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;



            try
            {
                string url = WebApiBaseAddress + "/api/Students/{0}";
                //url = WebApiBaseAddress + "/api/values";
                url = string.Format(url, Id);
                               

                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);
                //Add the token in Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                response = await httpClient.SendAsync(request);
                StudentDTO student;

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<StudentDTO>(content);

                    // Show Failed message.
                    if (student == null)
                    {

                        ActionWhenFailed(true, "Student Not found");

                        return;
                    }
                    else
                    {
                        txtStudentName.Text = student.Given1 + " " + student.Surname;
                        if (student.Photo != null)
                        {
                            using (MemoryStream ms = new MemoryStream(student.Photo))
                            {
                                BitmapImage bitmapImage = new BitmapImage();

                                var imageSource = new BitmapImage();
                                imageSource.BeginInit();
                                imageSource.StreamSource = ms;
                                imageSource.CacheOption = BitmapCacheOption.OnLoad;
                                imageSource.EndInit();

                                // Assign the Source property of your image
                                imgStudentPhoto.Source = imageSource;


                            }
                        }
                    }

                }
                else
                {
                    ActionWhenFailed(true, response.StatusCode.ToString());
                }
            }
            catch (Exception e)
            {
                ActionWhenFailed(true, e.Message);
            }
        }

        private async void DisplayStudentMedicalIncidentStatus(int Id, string token)
        {

            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;

            try
            {
                // Initialize buttons.
                btnSignInOut.IsEnabled = false;
                btnCancel.IsEnabled = false;
                lblMsg.Content = "";

                string url = WebApiBaseAddress + "/api/SickBays/{0}/StatusById";
                url = string.Format(url, Id);
                                
                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);
                //Add the token in Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                response = await httpClient.SendAsync(request);

                SickBayStatusDTO status;
                if (response.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();
                    status = JsonConvert.DeserializeObject<SickBayStatusDTO>(content);

                    // Show Failed message.
                    if (status == null)
                    {
                        ActionWhenFailed(true, status.Description);

                        return;
                    }
                    else
                    {
                        if (status.Code == "SI") // current status is SI, then requested job will be sign out.
                        {
                            RequestedJobCode = "SO"; // need this code when update requested.
                        }
                            
                        else if (status.Code == "SO")
                            RequestedJobCode = "SI"; // need this code when update requested.
                        else
                            RequestedJobCode = "";

                        if (status.Code == "SI" || status.Code == "SO")
                        {
                            btnSignInOut.Content = RequestedJobCode == "SO"? "Sign Out": "Sign In";
                            btnSignInOut.IsEnabled = true;
                            btnCancel.IsEnabled = true;
                            
                        }

                        else //if (status.Code == "PN" || "ER" )
                        {
                            btnCancel.IsEnabled = true;
                            btnSignInOut.IsEnabled = false;
                            lblMsg.Content = status.Description;

                            ActionWhenFailed(true, status.Description);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ActionWhenFailed(true, ex.Message);
            }
        }
        private void ActionWhenFailed(bool clearAllFlag, string message)
        {
            
            Uri uri = ResourceAccessor.GetFileUri("Assets/Fail sound effect 3.wav");
            PlaySound(uri);

            if (clearAllFlag)
            {
                ClearAllControls();
            }

            lblMsg.Content = message;

        }
        private void ActionWhenSucceeded()
        {
            Uri uri = ResourceAccessor.GetFileUri("Assets/You win sound effect 3.wav");
            PlaySound(uri);


            ClearAllControls();
        }
        private void ClearAllControls()
        {
            //txtCardNumber.Password = "";
            Uri uri = ResourceAccessor.GetFileUri("Assets/Joeys Terminal.JPG");
            imgStudentPhoto.Source = new BitmapImage(uri);

            ////txtStudentName.Text = string.Empty;


            //StudentId = 0;
            RequestedJobCode = string.Empty;
            lblMsg.Content = string.Empty;
            btnCancel.IsEnabled = false;
            btnSignInOut.IsEnabled = false;

            txtCardNumber.Focus();
        }
        private void PlaySound(Uri uri)//            --async private Task PlaySound(Uri uri)
        {
            Debug.Print(uri.ToString());

            mediaPlayer.MediaFailed += (o, args) =>
            {
                MessageBox.Show("Media Failed!!" + args.ErrorException.Message);
            };
            mediaPlayer.Open(uri);
            mediaPlayer.Play();




        }

        private async void UpdateSickBay(int Id)
        {

            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;

            try
            {
                SickBaySimple data = new SickBaySimple();
                data.Id = Id; // Student ID.                
                data.IncidentDate = DateTime.Today;
                data.Time = DateTime.Now.TimeOfDay;
                data.UsernameModified = @"joeys\oyoon";
                data.RequestedJobCode = RequestedJobCode;
                
                string url = WebApiBaseAddress + "/api/SickBays";
                //url = string.Format(url, Id);

                //get a token.
                string token = await GetToken();

                var strContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Post, url);
                request.Content = strContent;

                //Add the token in Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    ActionWhenSucceeded();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    SickBay sickBay = JsonConvert.DeserializeObject<SickBay>(content);
                    if (sickBay != null)
                        ActionWhenFailed(false, sickBay.Description);
                    else
                        ActionWhenFailed(false, "Failed. Try again");
                }
            }
            catch (Exception e)
            {
                ActionWhenFailed(false, e.Message);
            }


        }



        private void BtnSignInOut_Click(object sender, RoutedEventArgs e)
        {
            txtCardNumber.Focus();
            UpdateSickBay(StudentId);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtCardNumber.Focus();
            ClearAllControls();
        }

        internal static class ResourceAccessor
        {
            public static Uri GetFileUri(string path)
            {
                var uri = string.Format(
                    "pack://siteoforigin:,,,/{0}"
                    , path
                );

                return new Uri(uri);
            }
            //public static Uri GetImageUri(string path)
            //{
            //    var uri = string.Format(
            //        "pack://application:,,,/{0};component/{1}"
            //        , Assembly.GetExecutingAssembly().GetName().Name
            //        , path
            //    );

            //    return new Uri(uri);
            //}
        }
    }
}
