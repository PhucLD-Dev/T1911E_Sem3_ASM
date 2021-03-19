using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using APIGoogleYoutubeV3.Model;
using Windows.UI.Popups;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace APIGoogleYoutubeV3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VideoPage : Page
    {
        Video video;
        public VideoPage()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    
                }
                else
                {
                    MessageDialog msg = new MessageDialog("Check your internet connection");
                    await msg.ShowAsync();
                    this.Frame.GoBack();
                }
            }
            catch { }
            base.OnNavigatedTo(e);
        }

        private void btnHomePage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), new object());
        }
    }
}
