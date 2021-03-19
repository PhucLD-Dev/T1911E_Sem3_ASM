﻿using SQLite.Net.Attributes;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SQLiteAppDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string path;
        SQLite.Net.SQLiteConnection conn;
        public MainPage()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,"database.sqlite");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<Customer>();
        }
        public class Customer
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Age { get; set; }
        }

        private void GetData_Click(object sender, RoutedEventArgs e)
        {
            var query = conn.Table<Customer>();
            string id = " ";
            string name = " ";
            string age = " ";
            foreach(var message in query)
            {
                id = id + "\t " + message.Id;
                name = name + "\t " + message.Name;
                age = age + "\t " + message.Age;
            }
            textBlock2.Text = "\nID:" + id + "\nName: " + name + "\nAge:" + age;

        }

        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            var customer = conn.Insert(new Customer()
            {
                Name = textBox.Text,
                Age = textBox1.Text
            });

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var customer = conn.Delete(new Customer()
            {
                Id = 3
            });

        }
    }
}