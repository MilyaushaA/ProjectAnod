using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using EloksalPro.Models;
using System.Collections.Generic;

namespace EloksalPro.View.Report
{
    public partial class ReportTypeProtective : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportTypeProtective()
        {
            InitializeComponent();
        }
        public void InitData(string shift, string date, List<TapeProtectiveProcessProfileReport> list)
        {
            Shift.Value = shift;
            Date.Value = date;
            objectDataSource1.DataSource = list;
        }
    }
}
