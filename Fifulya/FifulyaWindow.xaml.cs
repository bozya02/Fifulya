using System;
using System.Collections.Generic;
using System.Linq;
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
using Fifulya.Pages;

namespace Fifulya
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FifulyaWindow : Window
    {
        public string pageTitle { get; set; }
        public FifulyaWindow()
        {
            InitializeComponent();
            frame.Navigated += Frame_Navigated;
            frame.NavigationService.Navigate(new AuthorizationPage());
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            var pageContent = frame.Content;
            pageTitle = (pageContent as Page).Title;
            tbTitle.Text = pageTitle;

            if (pageContent is AuthorizationPage)
                spButtons.Visibility = Visibility.Hidden;
            else if (pageContent is RegistrationPage)
            {
                spButtons.Visibility = Visibility.Visible;
                btnGoForward.Visibility = Visibility.Hidden;
            }
            else
            {
                spButtons.Visibility = Visibility.Visible;
                btnGoForward.Visibility = Visibility.Visible;
                btnGoBack.Visibility = Visibility.Visible;
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            if (frame.CanGoBack)
                frame.GoBack();
        }

        private void btnGoForward_Click(object sender, RoutedEventArgs e)
        {
            if (frame.CanGoBack)
                frame.GoBack();
        }
    }
}
