using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using EloksalPro.Models;
using System.Collections.Generic;

namespace EloksalPro.View.Report
{
    public partial class ReportСuttingFacing : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportСuttingFacing()
        {
            InitializeComponent();
        }
        public void InitData(string shift, string date, List<СuttingFacingProfileReport> list,string name)
        {
            Shift.Value = shift;
            Date.Value = date;
            UserName.Value = name;
            objectDataSource1.DataSource = list;
        }
    }
}
