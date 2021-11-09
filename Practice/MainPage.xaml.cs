using Practice.Entity;
using Practice.Models;
using Practice.Pages;
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

namespace Practice
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newContact = new Contact
            {
                Name = txt_Name.Text,
                Phone = txt_Phone.Text,
            };
            ContactModels.Save(newContact);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var contactSearch = ContactModels.SearchByName(txt_Name1.Text);
            if (contactSearch != null)
            {
                txt_Phone1.Text = contactSearch.Phone;
            }
            else
            {
                txt_Phone1.Text ="Khong co sdt";
            }
        }

        public void GetContactList(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(List));
        }
    }
}
