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

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace QuickTester
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Windows.Storage.ApplicationData.Current.LocalSettings.Values["admin"] = "admin";
        }

        private void button_teacher_Click(object sender, RoutedEventArgs e)
        {
            var val = (string)Windows.Storage.ApplicationData.Current.LocalSettings.Values["admin"];
            string pass = password.Text;
            string log = login.Text;

            var settings = Windows.Storage.ApplicationData.Current.LocalSettings;
            var passes = Windows.Storage.ApplicationData.Current.LocalSettings.Values;
            if (!settings.Values.ContainsKey(log))
            {
                login.Text = "неверный логин!";
            }

            if (settings.Values.ContainsKey(log) && (string)Windows.Storage.ApplicationData.Current.LocalSettings.Values[log] == pass)
            {
                this.Frame.Navigate(typeof(teacher_page));
            }  
            else
            {
                password.Text = "неверный пароль!";               
            }      
                      
        }

        private void button_student_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(student_page));
        }
    }
}
