using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using EloksalPro.Models;
using System.Collections.Generic;

namespace EloksalPro.View.Report
{
    public partial class ReportPackingProfile : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportPackingProfile()
        {
            InitializeComponent();
        }
        public void InitData(string shift, string date, List<PackingAluminumProfileReport> list)
        {
            Shift.Value = shift;
            Date.Value = date;
            objectDataSource1.DataSource = list;
        }

    }
}
