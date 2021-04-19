using SQLite.Net.Attributes;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Newsapi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Bookmark1 : Page
    {
        string path;
        SQLite.Net.SQLiteConnection conn;
        public Bookmark1()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "database.sqlite");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<Bookmark12>();
            var query = conn.Table<Bookmark12>();
            string id = " ";
            string name = " ";

            foreach (var message in query)
            {
                id = id + "\t " + message.Id;
                name = name + "\t " + message.Name;

            }
            textBlock2.Text = "\nID:" + id + "\nName: " + name;

        }
        public class Bookmark12
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Name { get; set; }
        }


        private void btnHomePage1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), new object());

        }

        private void HumburgerButton1_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
        private void ListBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
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
    }
}
