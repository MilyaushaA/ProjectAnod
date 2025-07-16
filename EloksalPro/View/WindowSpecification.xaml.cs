using EloksalPro.View.Report;
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
using System.Windows.Shapes;
using DevExpress.XtraReports.UI;
using EloksalPro.Models;
using EloksalPro.EfStructures;
using DevExpress.Xpf.Printing;

namespace EloksalPro.View
{
    /// <summary>
    /// Логика взаимодействия для WindowSpecification.xaml
    /// </summary>
    public partial class WindowSpecification : Window
    {
        public WindowSpecification()
        {
            InitializeComponent();
        }
        public void PrintInvoice(string clientName,DateTime date,string numberSpecification,string numberContract,
                                                DateTime dateContract,List<SpecificationAllDescription> list,
                                                List<AppendixSpesification> listApp)
        {
            ReportSpecification report = new ReportSpecification();
            foreach (var p in report.Parameters)
            {
                p.Visible = false;
            }
            report.InitData(clientName, date, numberSpecification, numberContract, dateContract, list, listApp);
            report.CreateDocument();
            //documentPreviewControl.RequestDocumentCreation = true;
            //documentPreviewControl.DocumentSource = report;
            ReportDesigner.DocumentSource = report;
        }
        public void PrintInvoiceIndividualClient(string clientName, DateTime date, string numberSpecification, string numberContract,
                                             DateTime dateContract, List<SpecificationAllDescription> list,
                                             List<AppendixSpesification> listApp)
        {
            ReportSpecificationIndividualClient report = new ReportSpecificationIndividualClient();
            foreach (var p in report.Parameters)
            {
                p.Visible = false;
            }
            report.InitData(clientName, date, numberSpecification, numberContract, dateContract, list, listApp);
            report.CreateDocument();
            //documentPreviewControl.RequestDocumentCreation = true;
            //documentPreviewControl.DocumentSource = report;
            ReportDesigner.DocumentSource = report;
        }
        public void PrintInvoiceTwo(string clientName, DateTime date, string numberSpecification, string numberContract,
                                         DateTime dateContract, List<SpecificationAllDescription> list,
                                         List<AppendixSpesification> listApp)
        {
            ReportSpecificationTwo report = new ReportSpecificationTwo();
            foreach (var p in report.Parameters)
            {
                p.Visible = false;
            }
            report.InitData(clientName, date, numberSpecification, numberContract, dateContract, list, listApp);
            report.CreateDocument();
            //documentPreviewControl.RequestDocumentCreation = true;
            //documentPreviewControl.DocumentSource = report;
            ReportDesigner.DocumentSource = report;
        }

    }
}