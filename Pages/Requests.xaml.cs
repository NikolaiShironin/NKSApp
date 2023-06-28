using Microsoft.Office.Core;
using System.Data.Entity.Core.Objects;
using NKSApp.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;

namespace NKSApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Requests.xaml
    /// </summary>
    public partial class Requests : Page
    {
        private NKSEntitie _сontext = new NKSEntitie();
        public Requests()
        {
            InitializeComponent();
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Request.ToList();
            CountReady.Text = NKSEntitie.GetContext().Request.Where(x => x.Status.NStatus == "Готово").Count().ToString();
            CountInWork.Text = NKSEntitie.GetContext().Request.Where(x => x.Status.NStatus == "В работе").Count().ToString();

            CmbType.ItemsSource = NKSEntitie.GetContext().Type.ToList();
            CmbType.SelectedValuePath = "TypeID";
            CmbType.DisplayMemberPath = "NType";

            CmbSource.ItemsSource = NKSEntitie.GetContext().Source.ToList();
            CmbSource.SelectedValuePath = "SourceID";
            CmbSource.DisplayMemberPath = "NSource";

            CmbExecutor.ItemsSource = NKSEntitie.GetContext().Executor.ToList();
            CmbExecutor.SelectedValuePath = "ExecutorID";
            CmbExecutor.DisplayMemberPath = "NExecutor";
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new RequesView((sender as Button).DataContext as Request));
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AddANDRedactRequest(null));
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var app = new Excel.Application();

            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet worksheet = app.Worksheets.Item[1];
            int indexRows = 1;
            worksheet.Cells[1][indexRows] = "Номер Заявки";
            worksheet.Cells[2][indexRows] = "Время создания";
            worksheet.Cells[3][indexRows] = "Содержание";
            worksheet.Cells[4][indexRows] = "Тип";
            worksheet.Cells[5][indexRows] = "Источник";
            worksheet.Cells[6][indexRows] = "Заявитель";
            worksheet.Cells[7][indexRows] = "Исполнитель";
            worksheet.Cells[8][indexRows] = "Адрес";
            worksheet.Cells[9][indexRows] = "Удобное время";
            worksheet.Cells[10][indexRows] = "Статус";
            var printItems = NKSEntitie.GetContext().Request.ToList();
            foreach (var item in printItems)
            {
                worksheet.Cells[1][indexRows + 1] = item.RequestID;
                worksheet.Cells[2][indexRows + 1] = item.DateStart;
                worksheet.Cells[3][indexRows + 1] = item.ContentN;
                worksheet.Cells[4][indexRows + 1] = item.Type.NType;
                worksheet.Cells[5][indexRows + 1] = item.Source.NSource;
                worksheet.Cells[6][indexRows + 1] = item.Applicant;
                worksheet.Cells[7][indexRows + 1] = item.Executor.NExecutor;
                worksheet.Cells[8][indexRows + 1] = item.Adress;
                worksheet.Cells[9][indexRows + 1] = item.СonvenientTime;
                worksheet.Cells[10][indexRows + 1] = item.Status.NStatus;

                indexRows++;
            }
            worksheet.Cells[1][indexRows + 1].Formula = "Кол-во Заявок =";
            worksheet.Cells[2][indexRows + 1].Formula = $"=Count(A2:A{indexRows})";
            worksheet.Cells[3][indexRows + 1].Formula = "Кол-во Готовых заявок =";
            worksheet.Cells[4][indexRows + 1].Formula = CountReady.Text;
            worksheet.Cells[5][indexRows + 1].Formula = "Кол-во Не готовых заявок =";
            worksheet.Cells[6][indexRows + 1].Formula = CountInWork.Text;

            Excel.Range rangeBorders = worksheet.Range[worksheet.Cells[10][indexRows + 1], worksheet.Cells[1][1]];
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

            worksheet.Columns.AutoFit();
            app.Visible = true;
        }

        private void BtnDeleterRequest_Click(object sender, RoutedEventArgs e)
        {
            var OrdersForRemoving = DGridOrders.SelectedItems.Cast<Request>().ToList();
            if (MessageBox.Show($"Удалить {OrdersForRemoving.Count()} запись?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    NKSEntitie.GetContext().Request.RemoveRange(OrdersForRemoving);
                    NKSEntitie.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridOrders.ItemsSource = NKSEntitie.GetContext().Request.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Request.Where(x => x.Applicant.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            TxtSearch.Text = null;
            DPSince.Text = null;
            DPTo.Text = null;
            CmbType.Text = "Тип";
            CmbSource.Text = "Источник";
            CmbExecutor.Text = "Исполнитель";
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Request.ToList();
        }

        private void CmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt32(CmbType.SelectedValue);
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Request.Where(x => x.TypeID == id).ToList();
        }

        private void CmbSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt32(CmbSource.SelectedValue);
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Request.Where(x => x.SourceID == id).ToList();
        }

        private void CmbExecutor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt32(CmbExecutor.SelectedValue);
            DGridOrders.ItemsSource = NKSEntitie.GetContext().Request.Where(x => x.ExecutorID == id).ToList();
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
                
                DGridOrders.ItemsSource = NKSEntitie.GetContext().Request.Where(x => x.DateStart >= DPSince.SelectedDate && x.DateStart <= DPTo.SelectedDate).ToList();
            }
        }
    }
}