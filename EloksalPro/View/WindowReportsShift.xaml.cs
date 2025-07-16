using EloksalPro.Models;
using EloksalPro.View.Report;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace EloksalPro.View
{
    /// <summary>
    /// Логика взаимодействия для WindowReportsShift.xaml
    /// </summary>
    public partial class WindowReportsShift : Window
    {
        public WindowReportsShift()
        {
            InitializeComponent();
        }
        public void PrintInvoice(string date,string shift, List<ShotBlastingProfileReport> list, List<AnodizingProcessProfileReport> listAnod, int downAnod, int  downShot)
        {
            ReportShotAndAnod report = new ReportShotAndAnod();
            foreach (var p in report.Parameters)
            {
                p.Visible = false;
            }
            report.InitData(shift, date, list, listAnod, downAnod, downShot);
            report.CreateDocument();
            documentPreviewControl.RequestDocumentCreation = true;
            documentPreviewControl.DocumentSource = report;
            //ReportDesigner.DocumentSource = report;
        }
        public void PrintInvoice(string date, string shift, List<TapeProtectiveProcessProfileReport> list)
        {
            ReportTypeProtective report = new ReportTypeProtective();
            foreach (var p in report.Parameters)
            {
                p.Visible = false;
            }
            report.InitData(shift, date, list);
            report.CreateDocument();
            documentPreviewControl.RequestDocumentCreation = true;
            documentPreviewControl.DocumentSource = report;
            //ReportDesigner.DocumentSource = report;
        }
        public void PrintInvoice(string date, string shift, List<СuttingFacingProfileReport> list,string name)
        {
            ReportСuttingFacing report = new ReportСuttingFacing();
            foreach (var p in report.Parameters)
            {
                p.Visible = false;
            }
            report.InitData(shift, date, list,name);
            report.CreateDocument();
            documentPreviewControl.RequestDocumentCreation = true;
            documentPreviewControl.DocumentSource = report;
            //ReportDesigner.DocumentSource = report;
        }
        public void PrintInvoice(string date, string shift, List<PackingAluminumProfileReport> list)
        {
            ReportPackingProfile report = new ReportPackingProfile();
            foreach (var p in report.Parameters)
            {
                p.Visible = false;
            }
            report.InitData(shift, date, list);
            report.CreateDocument();
            documentPreviewControl.RequestDocumentCreation = true;
            documentPreviewControl.DocumentSource = report;
            //ReportDesigner.DocumentSource = report;
        }
        public void PrintInvoiceShip(string clientName, string date, string numberShip,string name,List<ProfileConsumptionWarehouse> list)
        {
            ReportShipment report = new ReportShipment();
            foreach (var p in report.Parameters)
            {
                p.Visible = false;
            }
            report.InitData(clientName, date, numberShip,name,list);
            report.CreateDocument();
            documentPreviewControl.RequestDocumentCreation = true;
            documentPreviewControl.DocumentSource = report;
            //ReportDesigner.DocumentSource = report;
        }
        public void PrintLabelProfile(PackingAluminumProfile list)
        {
            LabelProfileReport1 report = new LabelProfileReport1();
            foreach (var p in report.Parameters)
            {
                p.Visible = false;
            }
            report.InitData(list);
            report.CreateDocument();
            documentPreviewControl.RequestDocumentCreation = true;
            documentPreviewControl.DocumentSource = report;
            //ReportDesigner.DocumentSource = report;
        }
        public void PrintExtensiveReceptionProfile(ObservableCollection<ExtensiveReceptionProfile> list, DateTime? date, string user)
        {
            ReportExtensiveReception report = new ReportExtensiveReception();
            foreach (var p in report.Parameters)
            {
                p.Visible = false;
            }
            report.InitData(list,date,user);
            report.CreateDocument();
            documentPreviewControl.RequestDocumentCreation = true;
            documentPreviewControl.DocumentSource = report;
            //ReportDesigner.DocumentSource = report;
        }
        public void PrintListNumberAndClient(string number, string client, List<ShotBlastingProfile> listShot, List<AnodizingProcessProfile> listAnod)
        {
            ReportClientAndNumber report = new ReportClientAndNumber();
            foreach (var p in report.Parameters)
            {
                p.Visible = false;
            }
            report.InitData(number, client,listShot, listAnod);
            report.CreateDocument();
            documentPreviewControl.RequestDocumentCreation = true;
            documentPreviewControl.DocumentSource = report;
            //ReportDesigner.DocumentSource = report;
        }
    }
}
