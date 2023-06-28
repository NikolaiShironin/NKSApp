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
    /// Логика взаимодействия для AddANDRedactRequest.xaml
    /// </summary>
    public partial class AddANDRedactRequest : Page
    {
        private Request _currentRequest = new Request();
        public AddANDRedactRequest(Request selectedRequest)
        {
            InitializeComponent();
            if (selectedRequest != null)
                _currentRequest = selectedRequest;
            DataContext = _currentRequest;

            CmbNStatus.ItemsSource = NKSEntitie.GetContext().Status.ToList();
            CmbNStatus.SelectedValuePath = "StatusID";
            CmbNStatus.DisplayMemberPath = "NStatus";

            CmbNType.ItemsSource = NKSEntitie.GetContext().Type.ToList();
            CmbNType.SelectedValuePath = "TypeID";
            CmbNType.DisplayMemberPath = "NType";

            CmbNSource.ItemsSource = NKSEntitie.GetContext().Source.ToList();
            CmbNSource.SelectedValuePath = "SourceID";
            CmbNSource.DisplayMemberPath = "NSource";

            CmbNExecutor.ItemsSource = NKSEntitie.GetContext().Executor.ToList();
            CmbNExecutor.SelectedValuePath = "ExecutorID";
            CmbNExecutor.DisplayMemberPath = "NExecutor";
        }

        private void BtnSaveRequest_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentRequest.Applicant))
                error.AppendLine("Укажите Заявителя!");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentRequest.RequestID == 0)
                NKSEntitie.GetContext().Request.Add(_currentRequest);
            try
            {
                NKSEntitie.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
                ClassFrame.frmObj.Navigate(new Requests());

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
            TxtDateStart.Text = dt.ToString();
        }
    }
}
