using Microsoft.Office.Interop.Word;
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
using Page = System.Windows.Controls.Page;
using Word = Microsoft.Office.Interop.Word;

namespace NKSApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PlanView.xaml
    /// </summary>
    public partial class PlanView : Page
    {
        private NKSEntitie _context = new NKSEntitie();
        private Plan _currentPlan = new Plan();
        public PlanView(Plan selectedPlan)
        {
            InitializeComponent();
            if (selectedPlan != null)
                _currentPlan = selectedPlan;
            DataContext = _currentPlan;
        }

        private void RedactPlan_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AddANDRedactPlan((sender as Button).DataContext as Plan));
        }

        private void PrintPlan_Click(object sender, RoutedEventArgs e)
        {
            int Select = Convert.ToInt32(TxtRofl.Text);

            var requests = _context.Plan.Where(x => x.PlanID == Select).ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph orderParagrapth12 = document.Paragraphs.Add();
            Word.Range orderRange1 = orderParagrapth12.Range;

            foreach (var currentGoods in requests)
            {
                orderRange1.Text = "План №" + currentGoods.PlanID.ToString();
                orderParagrapth12.set_Style("Заголовок");
            }
            orderRange1.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            orderRange1.InsertParagraphAfter();


            Word.Paragraph orderParagrapth = document.Paragraphs.Add();
            Word.Range orderRange = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph2 = document.Paragraphs.Add();
            Word.Range FinalPriceRange2 = FinalPriceParagraph2.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange2.Text = "Назначенное время: " + _currentPlan.TimeNeed;
                FinalPriceParagraph2.set_Style("Заголовок");
            }

            FinalPriceRange2.InsertParagraphAfter();

            Word.Paragraph orderParagrapth31 = document.Paragraphs.Add();
            Word.Range orderRange31 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph3 = document.Paragraphs.Add();
            Word.Range FinalPriceRange3 = FinalPriceParagraph3.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange3.Text = "Содержание: " + _currentPlan.ContentN;
                FinalPriceParagraph3.set_Style("Заголовок");
            }
            FinalPriceRange3.InsertParagraphAfter();

            Word.Paragraph orderParagrapth32 = document.Paragraphs.Add();
            Word.Range orderRange32 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph4 = document.Paragraphs.Add();
            Word.Range FinalPriceRange4 = FinalPriceParagraph4.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange4.Text = "Тип: " + _currentPlan.Type.NType;
                FinalPriceParagraph4.set_Style("Заголовок");
            }
            FinalPriceRange4.InsertParagraphAfter();

            Word.Paragraph orderParagrapth33 = document.Paragraphs.Add();
            Word.Range orderRange33 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph5 = document.Paragraphs.Add();
            Word.Range FinalPriceRange5 = FinalPriceParagraph5.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange5.Text = "Исполнитель: " + _currentPlan.Executor.NExecutor;
                FinalPriceParagraph5.set_Style("Заголовок");
            }
            FinalPriceRange5.InsertParagraphAfter();

            Word.Paragraph orderParagrapth34 = document.Paragraphs.Add();
            Word.Range orderRange34 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph6 = document.Paragraphs.Add();
            Word.Range FinalPriceRange6 = FinalPriceParagraph6.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange6.Text = "Адрес: " + _currentPlan.Adress;
                FinalPriceParagraph6.set_Style("Заголовок");
            }
            FinalPriceRange6.InsertParagraphAfter();

            Word.Paragraph orderParagrapth35 = document.Paragraphs.Add();
            Word.Range orderRange35 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph7 = document.Paragraphs.Add();
            Word.Range FinalPriceRange7 = FinalPriceParagraph7.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange7.Text = "Статус: " + _currentPlan.Status.NStatus;
                FinalPriceParagraph7.set_Style("Заголовок");
            }
            FinalPriceRange7.InsertParagraphAfter();

            application.Visible = true;
        }
    }
}
