using NKSApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace NKSApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Shutdowns.xaml
    /// </summary>
    public partial class Shutdowns : Page
    {
        private NKSEntitie _сontext = new NKSEntitie();

        public Shutdowns()
        {
            InitializeComponent();
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Shutdown.ToList();
            CountReady.Text = NKSEntitie.GetContext().Shutdown.Where(x => x.Status.NStatus == "Готово").Count().ToString();
            CountInWork.Text = NKSEntitie.GetContext().Shutdown.Where(x => x.Status.NStatus == "В работе").Count().ToString();

            CmbType.ItemsSource = NKSEntitie.GetContext().Type.ToList();
            CmbType.SelectedValuePath = "TypeID";
            CmbType.DisplayMemberPath = "NType";

            CmbOperator.ItemsSource = NKSEntitie.GetContext().Operator.ToList();
            CmbOperator.SelectedValuePath = "OperatorID";
            CmbOperator.DisplayMemberPath = "NOperator";

            DateTime thisDay = DateTime.Today;

            //if (DGridOrders.ItemsSource = NKSEntitie.GetContext().Shutdown.Where(x => x.TimeCreate > thisDay) == )
            //{

            //}
        }

        private void BtnViewShutdown_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new ShutdownView((sender as Button).DataContext as Shutdown));
        }

        private void BtnCreateShutdown_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AddANDRedactShutdown(null));
        }

        private void BtnPrintShutdown_Click(object sender, RoutedEventArgs e)
        {
            var app = new Excel.Application();

            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet worksheet = app.Worksheets.Item[1];
            int indexRows = 1;
            worksheet.Cells[1][indexRows] = "Номер отключения";
            worksheet.Cells[2][indexRows] = "Время создания";
            worksheet.Cells[3][indexRows] = "Отключённый ресурс";
            worksheet.Cells[4][indexRows] = "Тип отключения";
            worksheet.Cells[5][indexRows] = "Время отключения";
            worksheet.Cells[6][indexRows] = "Время включения";
            worksheet.Cells[7][indexRows] = "Дома";
            worksheet.Cells[8][indexRows] = "Оператор";
            worksheet.Cells[9][indexRows] = "Статус";
            var printItems = NKSEntitie.GetContext().Shutdown.ToList();
            foreach (var item in printItems)
            {
                worksheet.Cells[1][indexRows + 1] = item.ShutdownID;
                worksheet.Cells[2][indexRows + 1] = item.TimeCreate;
                worksheet.Cells[3][indexRows + 1] = item.Type.NType;
                worksheet.Cells[4][indexRows + 1] = item.TypeShutdown;
                worksheet.Cells[5][indexRows + 1] = item.StartTime;
                worksheet.Cells[6][indexRows + 1] = item.EndTime;
                worksheet.Cells[7][indexRows + 1] = item.Homes;
                worksheet.Cells[8][indexRows + 1] = item.Operator.NOperator;
                worksheet.Cells[9][indexRows + 1] = item.Status.NStatus;

                indexRows++;
            }
            worksheet.Cells[1][indexRows + 1].Formula = "Кол-во Записей =";
            worksheet.Cells[2][indexRows + 1].Formula = $"=Count(A2:A{indexRows})";
            worksheet.Cells[3][indexRows + 1].Formula = "Кол-во Готовых записей =";
            worksheet.Cells[4][indexRows + 1].Formula = CountReady.Text;
            worksheet.Cells[5][indexRows + 1].Formula = "Кол-во Не готовых записей =";
            worksheet.Cells[6][indexRows + 1].Formula = CountInWork.Text;

            Excel.Range rangeBorders = worksheet.Range[worksheet.Cells[9][indexRows + 1], worksheet.Cells[1][1]];
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

            worksheet.Columns.AutoFit();
            app.Visible = true;
        }

        private void BtnDeleterShutdowns_Click(object sender, RoutedEventArgs e)
        {
            var OrdersForRemoving = DGridOrders.SelectedItems.Cast<Shutdown>().ToList();
            if (MessageBox.Show($"Удалить {OrdersForRemoving.Count()} запись?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    NKSEntitie.GetContext().Shutdown.RemoveRange(OrdersForRemoving);
                    NKSEntitie.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridOrders.ItemsSource = NKSEntitie.GetContext().Shutdown.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Shutdown.Where(x => x.TypeShutdown.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            CmbType.Text = "Отключённый ресурс";
            CmbOperator.Text = "Оператор";
            DPSince.Text = null;
            DPTo.Text = null;
            TxtSearch.Text = null;
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Shutdown.ToList();

        }

        private void CmbOperator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt32(CmbOperator.SelectedValue);
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Shutdown.Where(x => x.OperatorID == id).ToList();
        }

        private void CmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt32(CmbType.SelectedValue);
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Shutdown.Where(x => x.TypeID == id).ToList();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            if (DPSince == null && DPTo == null)
            {
                MessageBox.Show("Укажите даты");
                return;
            }
            else
            {
                DGridOrders.ItemsSource = NKSEntitie.GetContext().Shutdown.Where(x => x.TimeCreate >= DPSince.SelectedDate && x.TimeCreate <= DPTo.SelectedDate).ToList();
            }
        }
    }
}
