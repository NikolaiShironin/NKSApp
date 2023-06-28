using NKSApp.Classes;
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

namespace NKSApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddANDRedactShutdown.xaml
    /// </summary>
    public partial class AddANDRedactShutdown : Page
    {
        private Shutdown _currentShutdown = new Shutdown();
        public AddANDRedactShutdown(Shutdown selectedShutdown)
        {
            InitializeComponent();
            if (selectedShutdown != null)
                _currentShutdown = selectedShutdown;
            DataContext = _currentShutdown;

            CmbType.ItemsSource = NKSEntitie.GetContext().Type.ToList();
            CmbType.SelectedValuePath = "TypeID";
            CmbType.DisplayMemberPath = "NType";

            CmbStatus.ItemsSource = NKSEntitie.GetContext().Status.ToList();
            CmbStatus.SelectedValuePath = "StatusID";
            CmbStatus.DisplayMemberPath = "NStatus";

            CmbOperator.ItemsSource = NKSEntitie.GetContext().Operator.ToList();
            CmbOperator.SelectedValuePath = "OperatorID";
            CmbOperator.DisplayMemberPath = "NOperator";
        }

        private void BtnSaveShutdown_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentShutdown.TypeShutdown))
                error.AppendLine("Укажите тип отключения!");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentShutdown.ShutdownID == 0)
                NKSEntitie.GetContext().Shutdown.Add(_currentShutdown);
            try
            {
                NKSEntitie.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
                ClassFrame.frmObj.Navigate(new Shutdowns());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void DP2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string t = cboTP1.Text;
            string d = DP2.Text;
            DateTime dt = DateTime.Parse(d + " " + t);
            TxtStartTime.Text = dt.ToString();
        }

        private void DP3_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string t = cboTP2.Text;
            string d = DP3.Text;
            DateTime dt = DateTime.Parse(d + " " + t);
            TxtEndTime.Text = dt.ToString();
        }

        private void DP1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string t = cboTP.Text;
            string d = DP1.Text;
            DateTime dt = DateTime.Parse(d + " " + t);
            TxtTimeCreate.Text = dt.ToString();
        }
    }
}
