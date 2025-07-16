using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using EloksalPro.Models;
using System.Collections.Generic;

namespace EloksalPro.View.Report
{
    public partial class ReportClientAndNumber : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportClientAndNumber()
        {
            InitializeComponent();
        }
        public void InitData(string number, string client, List<ShotBlastingProfile> list, List<AnodizingProcessProfile> listAnod)
        {
            Client.Value =client;
            Number.Value = number;
            objectDataSource1.DataSource = list;
            objectDataSource2.DataSource = listAnod;
        }
    }
}
