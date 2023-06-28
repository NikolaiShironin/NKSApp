using NKSApp.Classes;
using NKSApp.Pages;
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

namespace NKSApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClassFrame.frmObj = frmMain;
            frmMain.Navigate(new Pages.Requests());
        }

        private void BtnForward_Click(object sender, RoutedEventArgs e)
        {
            frmMain.GoForward();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            frmMain.GoBack();
        }

        private void frmMain_ContentRendered(object sender, EventArgs e)
        {
            if (frmMain.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
            if (frmMain.CanGoForward)
            {
                BtnForward.Visibility = Visibility.Visible;
            }
            else
            {
                BtnForward.Visibility = Visibility.Hidden;
            }
        }

        private void ToRequest_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new Pages.Requests());
        }

        private void ToShutdown_Click(object sender, RoutedEventArgs e)
        {

            frmMain.Navigate(new Pages.Shutdowns());
        }

        private void ToExecuter_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new Pages.Executors());
        }

        private void ToOperator_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new Pages.Operators());
        }

        private void ToPlan_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new Pages.Plans());
        }
    }
}
