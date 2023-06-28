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
using Excel = Microsoft.Office.Interop.Excel;

namespace NKSApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Plans.xaml
    /// </summary>
    public partial class Plans : Page
    {
        public Plans()
        {
            InitializeComponent();
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Plan.ToList();
            CountReady.Text = NKSEntitie.GetContext().Plan.Where(x => x.Status.NStatus == "Готово").Count().ToString();
            CountInWork.Text = NKSEntitie.GetContext().Plan.Where(x => x.Status.NStatus == "В работе").Count().ToString();

            CmbType.ItemsSource = NKSEntitie.GetContext().Type.ToList();
            CmbType.SelectedValuePath = "TypeID";
            CmbType.DisplayMemberPath = "NType";

            CmbExecutor.ItemsSource = NKSEntitie.GetContext().Executor.ToList();
            CmbExecutor.SelectedValuePath = "ExecutorID";
            CmbExecutor.DisplayMemberPath = "NExecutor";
        }

        private void BtnCreatePlan_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AddANDRedactPlan(null));
        }

        private void BtnPrintPlan_Click(object sender, RoutedEventArgs e)
        {
            var app = new Excel.Application();

            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet worksheet = app.Worksheets.Item[1];
            int indexRows = 1;
            worksheet.Cells[1][indexRows] = "Номер Плана";
            worksheet.Cells[2][indexRows] = "Назначенное время";
            worksheet.Cells[3][indexRows] = "Содержание";
            worksheet.Cells[4][indexRows] = "Тип";
            worksheet.Cells[5][indexRows] = "Исполнитель";
            worksheet.Cells[6][indexRows] = "Адрес";
            worksheet.Cells[7][indexRows] = "Статус";
            var printItems = NKSEntitie.GetContext().Plan.ToList();
            foreach (var item in printItems)
            {
                worksheet.Cells[1][indexRows + 1] = item.PlanID;
                worksheet.Cells[2][indexRows + 1] = item.TimeNeed;
                worksheet.Cells[3][indexRows + 1] = item.ContentN;
                worksheet.Cells[4][indexRows + 1] = item.Type.NType;
                worksheet.Cells[5][indexRows + 1] = item.Executor.NExecutor;
                worksheet.Cells[6][indexRows + 1] = item.Adress;
                worksheet.Cells[7][indexRows + 1] = item.Status.NStatus;

                indexRows++;
            }
            worksheet.Cells[1][indexRows + 1].Formula = "Кол-во Записей =";
            worksheet.Cells[2][indexRows + 1].Formula = $"=Count(A2:A{indexRows})";
            worksheet.Cells[3][indexRows + 1].Formula = "Кол-во Готовых записей =";
            worksheet.Cells[4][indexRows + 1].Formula = CountReady.Text;
            worksheet.Cells[5][indexRows + 1].Formula = "Кол-во Не готовых записей =";
            worksheet.Cells[6][indexRows + 1].Formula = CountInWork.Text;

            Excel.Range rangeBorders = worksheet.Range[worksheet.Cells[7][indexRows + 1], worksheet.Cells[1][1]];
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

            worksheet.Columns.AutoFit();
            app.Visible = true;
        }

        private void BtnViewPlan_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PlanView((sender as Button).DataContext as Plan));
        }

        private void BtnDeleterPlan_Click(object sender, RoutedEventArgs e)
        {
            var OrdersForRemoving = DGridOrders.SelectedItems.Cast<Plan>().ToList();
            if (MessageBox.Show($"Удалить {OrdersForRemoving.Count()} запись?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    NKSEntitie.GetContext().Plan.RemoveRange(OrdersForRemoving);
                    NKSEntitie.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridOrders.ItemsSource = NKSEntitie.GetContext().Plan.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Plan.Where(x => x.ContentN.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            CmbType.Text = "Тип";
            CmbExecutor.Text = "Исполнитель";
            DPSince.Text = null;
            DPTo.Text = null;
            TxtSearch.Text = null;
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Plan.ToList();
        }

        private void CmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt32(CmbType.SelectedValue);
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Plan.Where(x => x.TypeID == id).ToList();
        }

        private void CmbExecutor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt32(CmbExecutor.SelectedValue);
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Plan.Where(x => x.ExecutorID == id).ToList();
        }

        private void Shows_Click(object sender, RoutedEventArgs e)
        {
            if (DPSince == null && DPTo == null)
            {
                MessageBox.Show("Укажите даты");
                return;
            }
            else
            {
                DGridOrders.ItemsSource = NKSEntitie.GetContext().Plan.Where(x => x.TimeNeed >= DPSince.SelectedDate && x.TimeNeed <= DPTo.SelectedDate).ToList();
            }
        }
    }
}
