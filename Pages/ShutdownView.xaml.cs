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
    /// Логика взаимодействия для ShutdownView.xaml
    /// </summary>
    public partial class ShutdownView : Page
    {
        private NKSEntitie _context = new NKSEntitie();
        private Shutdown _currentShutdown = new Shutdown();
        public ShutdownView(Shutdown selectedShutdown)
        {
            InitializeComponent();
            if (selectedShutdown != null)
                _currentShutdown = selectedShutdown;
            DataContext = _currentShutdown;
        }

        private void RedactShutdown_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AddANDRedactShutdown((sender as Button).DataContext as Shutdown));
        }

        private void PrintShutdown_Click(object sender, RoutedEventArgs e)
        {
            int Select = Convert.ToInt32(TxtRofl.Text);

            var requests = _context.Shutdown.Where(x => x.ShutdownID == Select).ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph orderParagrapth12 = document.Paragraphs.Add();
            Word.Range orderRange1 = orderParagrapth12.Range;

            foreach (var currentGoods in requests)
            {
                orderRange1.Text = "Отключение №" + currentGoods.ShutdownID.ToString();
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
                FinalPriceRange2.Text = "Время создания: " + _currentShutdown.TimeCreate;
                FinalPriceParagraph2.set_Style("Заголовок");
            }

            FinalPriceRange2.InsertParagraphAfter();

            Word.Paragraph orderParagrapth31 = document.Paragraphs.Add();
            Word.Range orderRange31 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph3 = document.Paragraphs.Add();
            Word.Range FinalPriceRange3 = FinalPriceParagraph3.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange3.Text = "Отключённый ресурс: " + _currentShutdown.Type.NType;
                FinalPriceParagraph3.set_Style("Заголовок");
            }
            FinalPriceRange3.InsertParagraphAfter();

            Word.Paragraph orderParagrapth32 = document.Paragraphs.Add();
            Word.Range orderRange32 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph4 = document.Paragraphs.Add();
            Word.Range FinalPriceRange4 = FinalPriceParagraph4.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange4.Text = "Тип отключения: " + _currentShutdown.TypeShutdown;
                FinalPriceParagraph4.set_Style("Заголовок");
            }
            FinalPriceRange4.InsertParagraphAfter();

            Word.Paragraph orderParagrapth33 = document.Paragraphs.Add();
            Word.Range orderRange33 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph5 = document.Paragraphs.Add();
            Word.Range FinalPriceRange5 = FinalPriceParagraph5.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange5.Text = "Время отключения: " + _currentShutdown.StartTime;
                FinalPriceParagraph5.set_Style("Заголовок");
            }
            FinalPriceRange5.InsertParagraphAfter();

            Word.Paragraph orderParagrapth34 = document.Paragraphs.Add();
            Word.Range orderRange34 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph6 = document.Paragraphs.Add();
            Word.Range FinalPriceRange6 = FinalPriceParagraph6.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange6.Text = "Время включения: " + _currentShutdown.EndTime;
                FinalPriceParagraph6.set_Style("Заголовок");
            }
            FinalPriceRange6.InsertParagraphAfter();

            Word.Paragraph orderParagrapth35 = document.Paragraphs.Add();
            Word.Range orderRange35 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph7 = document.Paragraphs.Add();
            Word.Range FinalPriceRange7 = FinalPriceParagraph7.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange7.Text = "Дома: " + _currentShutdown.Homes;
                FinalPriceParagraph7.set_Style("Заголовок");
            }
            FinalPriceRange7.InsertParagraphAfter();

            Word.Paragraph orderParagrapth36 = document.Paragraphs.Add();
            Word.Range orderRange36 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph8 = document.Paragraphs.Add();
            Word.Range FinalPriceRange8 = FinalPriceParagraph8.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange8.Text = "Оператор: " + _currentShutdown.Operator.NOperator;
                FinalPriceParagraph8.set_Style("Заголовок");
            }
            FinalPriceRange8.InsertParagraphAfter();

            Word.Paragraph orderParagrapth37 = document.Paragraphs.Add();
            Word.Range orderRange37 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph9 = document.Paragraphs.Add();
            Word.Range FinalPriceRange9 = FinalPriceParagraph9.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange9.Text = "Статус: " + _currentShutdown.Status.NStatus;
                FinalPriceParagraph9.set_Style("Заголовок");
            }
            FinalPriceRange9.InsertParagraphAfter();

            application.Visible = true;
        }
    }
}
