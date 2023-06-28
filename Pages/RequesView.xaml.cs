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
using Word = Microsoft.Office.Interop.Word;

namespace NKSApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RequesView.xaml
    /// </summary>
    public partial class RequesView : Page
    {
        private NKSEntitie _context = new NKSEntitie();
        private Request _currentRequest = new Request();
        public RequesView(Request selectedRequest)
        {
            InitializeComponent();
            
            if (selectedRequest != null)
                _currentRequest = selectedRequest;
            DataContext = _currentRequest;
        }

        private void RedactRequest_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AddANDRedactRequest((sender as Button).DataContext as Request));
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrintRequest_Click(object sender, RoutedEventArgs e)
        {
            
            int Select = Convert.ToInt32(TxtRofl.Text);

            var requests = _context.Request.Where(x => x.RequestID == Select).ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph orderParagrapth12 = document.Paragraphs.Add();
            Word.Range orderRange1 = orderParagrapth12.Range;

            foreach (var currentGoods in requests)
            {
                orderRange1.Text = "Заявка №" + currentGoods.RequestID.ToString();
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
                FinalPriceRange2.Text = "Время создания: " + _currentRequest.DateStart;
                FinalPriceParagraph2.set_Style("Заголовок");
            }

            FinalPriceRange2.InsertParagraphAfter();

            Word.Paragraph orderParagrapth31 = document.Paragraphs.Add();
            Word.Range orderRange31 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph3 = document.Paragraphs.Add();
            Word.Range FinalPriceRange3 = FinalPriceParagraph3.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange3.Text = "Статус: " + _currentRequest.Status.NStatus;
                FinalPriceParagraph3.set_Style("Заголовок");
            }
            FinalPriceRange3.InsertParagraphAfter();

            Word.Paragraph orderParagrapth32 = document.Paragraphs.Add();
            Word.Range orderRange32 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph4 = document.Paragraphs.Add();
            Word.Range FinalPriceRange4 = FinalPriceParagraph4.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange4.Text = "Тип: " + _currentRequest.Type.NType;
                FinalPriceParagraph4.set_Style("Заголовок");
            }
            FinalPriceRange4.InsertParagraphAfter();

            Word.Paragraph orderParagrapth33 = document.Paragraphs.Add();
            Word.Range orderRange33 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph5 = document.Paragraphs.Add();
            Word.Range FinalPriceRange5 = FinalPriceParagraph5.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange5.Text = "Содержание: " + _currentRequest.ContentN;
                FinalPriceParagraph5.set_Style("Заголовок");
            }
            FinalPriceRange5.InsertParagraphAfter();

            Word.Paragraph orderParagrapth34 = document.Paragraphs.Add();
            Word.Range orderRange34 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph6 = document.Paragraphs.Add();
            Word.Range FinalPriceRange6 = FinalPriceParagraph6.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange6.Text = "Источник: " + _currentRequest.Source.NSource;
                FinalPriceParagraph6.set_Style("Заголовок");
            }
            FinalPriceRange6.InsertParagraphAfter();

            Word.Paragraph orderParagrapth35 = document.Paragraphs.Add();
            Word.Range orderRange35 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph7 = document.Paragraphs.Add();
            Word.Range FinalPriceRange7 = FinalPriceParagraph7.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange7.Text = "Заявитель: " + _currentRequest.Applicant;
                FinalPriceParagraph7.set_Style("Заголовок");
            }
            FinalPriceRange7.InsertParagraphAfter();

            Word.Paragraph orderParagrapth36 = document.Paragraphs.Add();
            Word.Range orderRange36 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph8 = document.Paragraphs.Add();
            Word.Range FinalPriceRange8 = FinalPriceParagraph8.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange8.Text = "Исполнитель: " + _currentRequest.Executor.NExecutor;
                FinalPriceParagraph8.set_Style("Заголовок");
            }
            FinalPriceRange8.InsertParagraphAfter();

            Word.Paragraph orderParagrapth37 = document.Paragraphs.Add();
            Word.Range orderRange37 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph9 = document.Paragraphs.Add();
            Word.Range FinalPriceRange9 = FinalPriceParagraph9.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange9.Text = "Адрес: " + _currentRequest.Adress;
                FinalPriceParagraph9.set_Style("Заголовок");
            }
            FinalPriceRange9.InsertParagraphAfter();

            Word.Paragraph orderParagrapth38 = document.Paragraphs.Add();
            Word.Range orderRange38 = orderParagrapth.Range;

            Word.Paragraph FinalPriceParagraph10 = document.Paragraphs.Add();
            Word.Range FinalPriceRange10 = FinalPriceParagraph10.Range;

            foreach (var currentGoodsss in requests)
            {
                FinalPriceRange10.Text = "Удобное время: " + _currentRequest.СonvenientTime;
                FinalPriceParagraph10.set_Style("Заголовок");
            }
            FinalPriceRange10.InsertParagraphAfter();

            application.Visible = true;
        }
    }
}
