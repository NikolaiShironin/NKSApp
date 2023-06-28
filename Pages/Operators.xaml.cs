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
    /// Логика взаимодействия для Operators.xaml
    /// </summary>
    public partial class Operators : Page
    {
        private NKSEntitie _сontext = new NKSEntitie();
        public Operators()
        {
            InitializeComponent();
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Operator.ToList();
        }

        private void BtnCreateOperator_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AddANDRedactOperator(null));
        }

        private void BtnChangeOperator_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AddANDRedactOperator((sender as Button).DataContext as Operator));
        }

        private void BtnDeleteOperator_Click(object sender, RoutedEventArgs e)
        {
            var OrdersForRemoving = DGridOrders.SelectedItems.Cast<Operator>().ToList();
            if (MessageBox.Show($"Удалить {OrdersForRemoving.Count()} запись?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    NKSEntitie.GetContext().Operator.RemoveRange(OrdersForRemoving);
                    NKSEntitie.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridOrders.ItemsSource = NKSEntitie.GetContext().Operator.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }
    }
}
