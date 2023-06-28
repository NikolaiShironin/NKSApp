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
using System.Xml;

namespace NKSApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddANDRedactExexcutor.xaml
    /// </summary>
    public partial class AddANDRedactExexcutor : Page
    {
        private Executor _currentExecutor = new Executor();
        public AddANDRedactExexcutor(Executor selectedExecutor)
        {
            InitializeComponent();
            if (selectedExecutor != null)
                _currentExecutor = selectedExecutor;
            DataContext = _currentExecutor;
        }

        private void BtnSaveExecutor_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentExecutor.NExecutor))
                error.AppendLine("Укажите исполнителя!");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentExecutor.ExecutorID == 0)
                NKSEntitie.GetContext().Executor.Add(_currentExecutor);
            try
            {
                NKSEntitie.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
                ClassFrame.frmObj.Navigate(new Executors());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
