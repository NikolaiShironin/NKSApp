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
    /// Логика взаимодействия для AddANDRedactPlan.xaml
    /// </summary>
    public partial class AddANDRedactPlan : Page
    {
        private Plan _currentPlan = new Plan();
        public AddANDRedactPlan(Plan selectedPlan)
        {
            InitializeComponent();
            if (selectedPlan != null)
                _currentPlan = selectedPlan;
            DataContext = _currentPlan;

            CmbStatus.ItemsSource = NKSEntitie.GetContext().Status.ToList();
            CmbStatus.SelectedValuePath = "StatusID";
            CmbStatus.DisplayMemberPath = "NStatus";

            CmbNType.ItemsSource = NKSEntitie.GetContext().Type.ToList();
            CmbNType.SelectedValuePath = "TypeID";
            CmbNType.DisplayMemberPath = "NType";

            CmbExecutor.ItemsSource = NKSEntitie.GetContext().Executor.ToList();
            CmbExecutor.SelectedValuePath = "ExecutorID";
            CmbExecutor.DisplayMemberPath = "NExecutor";

        }

        private void BtnSavePlan_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentPlan.ContentN))
                error.AppendLine("Укажите Содержание!");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentPlan.PlanID == 0)
                NKSEntitie.GetContext().Plan.Add(_currentPlan);
            try
            {
                NKSEntitie.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
                ClassFrame.frmObj.Navigate(new Plans());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void DP1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string t = cboTP.Text;
            string d = DP1.Text;
            DateTime dt = DateTime.Parse(d + " " + t);
            TxtTimeNeed.Text = dt.ToString();
        }
    }
}
