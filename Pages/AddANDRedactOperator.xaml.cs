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
    /// Логика взаимодействия для AddANDRedactOperator.xaml
    /// </summary>
    public partial class AddANDRedactOperator : Page
    {
        private Operator _currentOperator = new Operator();
        public AddANDRedactOperator(Operator selectedOperator)
        {
            InitializeComponent();
            if (selectedOperator != null)
                _currentOperator = selectedOperator;
            DataContext = _currentOperator;
        }

        private void BtnSaveOperator_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentOperator.NOperator))
                error.AppendLine("Укажите оператора!");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentOperator.OperatorID == 0)
                NKSEntitie.GetContext().Operator.Add(_currentOperator);
            try
            {
                NKSEntitie.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
                ClassFrame.frmObj.Navigate(new Operators());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
