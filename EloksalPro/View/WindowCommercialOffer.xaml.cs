using EloksalPro.Models;
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

namespace EloksalPro.View
{
    /// <summary>
    /// Логика взаимодействия для WindowCommercialOffer.xaml
    /// </summary>
    public partial class WindowCommercialOffer : Window
    {
        public WindowCommercialOffer()
        {
            InitializeComponent();
        }
        public void PrintInvoice(string clientName, DateTime date, string numberOffer,string userName,string numberPhone, List<CommercialOffer> list)
        {
            ReportOffer report = new ReportOffer();
            foreach (var p in report.Parameters)
            {
                p.Visible = false;
            }
            report.InitData(clientName, date, numberOffer, userName, numberPhone, list);
            report.CreateDocument();
            documentPreviewControl.RequestDocumentCreation = true;
            documentPreviewControl.DocumentSource = report;
            //ReportDesigner.DocumentSource = report;
        }
    }
}
