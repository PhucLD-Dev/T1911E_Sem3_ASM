using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using System.Collections.ObjectModel;
using Newsapi.Models;
using SQLite.Net.Attributes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Newsapi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string path;
        SQLite.Net.SQLiteConnection conn;
        ObservableCollection<Article> Articles;
        ObservableCollection<Contact> Articles1;
        public MainPage()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "database.sqlite");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<Bookmark12>();
            Articles = new ObservableCollection<Article>();
            FirstNameTextBox.Text = "tesla";
            LastNameTextBox.Text = "2021-02-19";
            LastNameTextBox1.Text = "publishedAt";

            callApi(FirstNameTextBox.Text, LastNameTextBox.Text, LastNameTextBox1.Text, "2c79c43f6e03453cacb022cdc3d7f765");

            

        }
        public class Bookmark12
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public async void callApi(string q, string from, string sortBy, string apiKey)
        {
            var url = string.Format("http://newsapi.org/v2/everything?q={0}&from={1}&sortBy={2}&apiKey={3}", q, from, sortBy, apiKey);
            var news = await NewsJSON.GetNews(url) as Root;
            news.articles.ForEach(n => {
                Articles.Add(n);
            });
        }       
    
       
        private void NewsItemGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            Article ar = e.ClickedItem as Article;
            Frame.Navigate(typeof(ArticleView1),ar);

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }        

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
         
            Article aq = e.OriginalSource as Article;

            var customer = conn.Insert(new Bookmark12()
            {
                
                

            }); 

        }

        private void HumburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }        

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (Financial.IsSelected)
            {
                Frame.Navigate(typeof(MainPage), new object());
            }
            else if (Food.IsSelected)
            {
                
                Frame.Navigate(typeof(Bookmark1));
            }
            

        }

        private void NewContactButton_Click(object sender, RoutedEventArgs e)
        {
            Articles.Add(new Article { FirstName = FirstNameTextBox.Text, LastName = LastNameTextBox.Text, AvatarPath = LastNameTextBox1.Text});

            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            LastNameTextBox1.Text = "";

            FirstNameTextBox.Focus(FocusState.Programmatic);
            LastNameTextBox.Focus(FocusState.Programmatic);
            LastNameTextBox1.Focus(FocusState.Programmatic);
            Frame.Navigate(typeof(MainPage), new object());
        }
    }
}
