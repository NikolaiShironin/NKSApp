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
    /// Логика взаимодействия для Executors.xaml
    /// </summary>
    public partial class Executors : Page
    {
        private NKSEntitie _сontext = new NKSEntitie();
        public Executors()
        {
            InitializeComponent();
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Executor.ToList();
        }

        private void BtnCreateExexcutor_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AddANDRedactExexcutor(null));
        }

        private void BtnChangeExecutor_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AddANDRedactExexcutor((sender as Button).DataContext as Executor));
        }

        private void BtnDeleteExecutor_Click(object sender, RoutedEventArgs e)
        {
            var OrdersForRemoving = DGridOrders.SelectedItems.Cast<Executor>().ToList();
            if (MessageBox.Show($"Удалить {OrdersForRemoving.Count()} запись?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    NKSEntitie.GetContext().Executor.RemoveRange(OrdersForRemoving);
                    NKSEntitie.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridOrders.ItemsSource = NKSEntitie.GetContext().Executor.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }
    }
}
