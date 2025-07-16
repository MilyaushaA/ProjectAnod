using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using EloksalPro.Models;
using System.Collections.Generic;

namespace EloksalPro.View.Report
{
    public partial class ReportOffer : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportOffer()
        {
            InitializeComponent();
        }
        public void InitData(string clientName, DateTime dateOffer, string numberOffer,string userName,string numberPhone, List<CommercialOffer> listCommercialOffer)
        {
            ClientName.Value = clientName;
            DateOffer.Value = dateOffer;
            NumberOffer.Value = numberOffer;
            Manager.Value = userName;
            NumberPhone.Value = numberPhone;
            objectDataSource1.DataSource = listCommercialOffer;
        }
    }
}
