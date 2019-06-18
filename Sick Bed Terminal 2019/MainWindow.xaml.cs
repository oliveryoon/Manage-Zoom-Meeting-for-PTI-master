using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Sick_Bed_Terminal_2019.Models;
using Sick_Bed_Terminal_2019.Models.SickBays;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens;
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



namespace Sick_Bed_Terminal_2019
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //
        // The Client ID is used by the application to uniquely identify itself to Azure AD.
        // The Tenant is the name of the Azure AD tenant in which this application is registered.
        // The AAD Instance is the instance of Azure, for example public Azure or Azure China.
        // The Authority is the sign-in URL of the tenant.
        //
        const string tenant = "joeysorg.onmicrosoft.com";// "[Enter tenant name, e.g. contoso.onmicrosoft.com]";
        const string tenantId = "315c37fc-27dc-4021-9c67-a92e8878d455";// "[Enter tenant name, e.g. contoso.onmicrosoft.com]";
        const string clientId = "d446190b-740f-4ec3-b249-fc0b85f2ebbf";// "[Enter client ID as obtained from Azure Portal, e.g. 82692da5-a86f-44c9-9d53-2f88d52b478b]";
        const string aadInstance = "https://login.microsoftonline.com/{0}";

        //private static string appKey = "wDMzCHPBWklGr2RjSmrvml4l+8Pli06y7Eolg8MPUUQ=";        
        private static string clientSecret = "N+fr2qatwEw7m30iU+gZrIbwk*ETMk+G";
                
        static string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenantId);
        //  
        // To authenticate to the To Do list service, the client needs to know the service's App ID URI.
        // To contact the To Do list service we need it's URL as well.
        //
        const string joeysWebApiResourceId = "https://joeysorg.onmicrosoft.com/JoeysWebApi";//"[Enter App ID URI of TodoListService, e.g. https://contoso.onmicrosoft.com/TodoListService]";
        //const string joeysWebApiBaseAddress = "https://webapi.joeys.org";
        private static string joeysWebApiBaseAddress = "http://localhost:5000";


        private static IConfidentialClientApplication clientCredential = null;
        private static HttpClient httpClient = new HttpClient();
        private static AuthenticationContext authContext = null;

        private Uri redirectURI = null;

        public MainWindow()
        {
            InitializeComponent();
            var credentials = GetCredentials(tenantId, clientId, clientSecret);
            int Id = 0;
            txtCardNumber.Text = "8213";
            int.TryParse(txtCardNumber.Text, out Id);
            UpdateSickBay(Id);
        }
        public static async Task<AuthenticationResult> GetCredentials(string tenantId, string clientId, string clientSecret)
        {
            //string authority = $"https://login.microsoftonline.com/{tenantId}/";
            string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenantId);
            IConfidentialClientApplication app;
            app = ConfidentialClientApplicationBuilder.Create(clientId)
                                                      .WithClientSecret(clientSecret)
                                                      .WithAuthority(new Uri(authority))
                                                      .Build();

            IEnumerable<string> scopes = new List<string>() { "https://management.core.windows.net//.default" };
            var result = await app.AcquireTokenForClient(scopes)
                  .ExecuteAsync();
            return result;
        }
        private void txtCardNumber_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txt = (TextBox)txtCardNumber;
            if (e != null && e.Key == Key.Enter)
            {

                if (txt.Text != "")
                { 
                    DisplayPreSignInSignOut();
                    int Id = 0;
                    txtCardNumber.Text = "8213";
                    int.TryParse(txtCardNumber.Text, out Id);
                    UpdateSickBay(Id);
                }

                

            }
            txt.Focus();
        }
        private void DisplayPreSignInSignOut()
        {

        }
        private async void UpdateSickBay(int Id)
        {
            // Create an absence record.
            try
            {
                string strApiPath = "/api/Sickbays";

                //object data = new
                //{
                //    cardNumber = "1664702938"
                //};
                SickBaySimple data = new SickBaySimple();
                data.Id = Id; // Student ID.                
                data.IncidentDate = DateTime.Today;
                data.Time = DateTime.Now.TimeOfDay;
                data.UsernameModified = @"joeys\oyoon";
                

                var stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(joeysWebApiBaseAddress + strApiPath, stringContent); // student );

                RequestStatus result = null;
                if (response.IsSuccessStatusCode)
                {
                    var resultApi = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<RequestStatus>(resultApi);
                }


                if (response.IsSuccessStatusCode && result != null && result.StatusNumber > 0)
                {
                    //MessageDialog dialog = new MessageDialog(result.StatusDescription);
                    //await dialog.ShowAsync();
                    popupSuccess.Background = new SolidColorBrush(Colors.Green);
                    //PopupTextBlock.Foreground = new SolidColorBrush(Windows.UI.Colors.Wheat);
                    //PopupTextBlock.Text = result.StatusDescription;
                    //BlinkPopup.Begin();
                    //PopupTextBlock.Visibility = Visibility.Visible;
                }
                else
                {
                    //MessageDialog dialog = new MessageDialog(result.StatusDescription);
                    //await dialog.ShowAsync();
                    popupSuccess.Background = new SolidColorBrush(Colors.Green);
                    //PopupTextBlock.Foreground = new SolidColorBrush(Windows.UI.Colors.Wheat);
                    //PopupTextBlock.Text = result.StatusDescription;
                    //BlinkPopup.Begin();
                    //PopupTextBlock.Visibility = Visibility.Visible;
                }
                if (!response.IsSuccessStatusCode)
                {
                    //var playbackList = new MediaPlaybackList();
                    //playbackList.AutoRepeatEnabled = false;

                    //var source = MediaSource.CreateFromUri(new Uri("ms-winsoundevent:Notification.Reminder"));
                    //playbackList.Items.Add(new MediaPlaybackItem(source));


                    //BackgroundMediaPlayer.Current.Source = playbackList;


                    //if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    //{
                    //    // If the To Do list service returns access denied, clear the token cache and have the user sign-in again.
                    //    //MessageDialog dialog = new MessageDialog("Sorry, you don't have access to the web api.  Please sign-in again.");
                    //    //await dialog.ShowAsync();
                    //    //authContext.TokenCache.Clear();
                    //    popup.Background = new SolidColorBrush(Colors.Wheat);
                    //    PopupTextBlock.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    //    PopupTextBlock.Text = "Sorry, you don't have access to the web api.  Please sign-in again.";
                    //    BlinkPopup.Begin();
                    //    PopupTextBlock.Visibility = Visibility.Visible;
                    //}
                    //else
                    //{
                    //    popup.Background = new SolidColorBrush(Colors.Wheat);
                    //    PopupTextBlock.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    //    PopupTextBlock.Text = "Sorry. Absence record not created.!!";
                    //    BlinkPopup.Begin();
                    //    PopupTextBlock.Visibility = Visibility.Visible;
                    //    //MessageDialog dialog = new MessageDialog("Sorry. Absence record not created.!!");
                    //    //await dialog.ShowAsync();
                    //}
                }
            }

            catch (Exception e)
            {
                //MessageDialog dialog = new MessageDialog(string.Format("If the error continues, please contact your administrator.\n\nError Description:\n\n{0}", e.Message), "Sorry, an error occurred while signing you in.");
                //ShowError(dialog);
            }


        }
    }
}
