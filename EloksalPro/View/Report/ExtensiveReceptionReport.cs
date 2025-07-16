using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using EloksalPro.Models;

namespace EloksalPro.View.Report
{
    public partial class ExtensiveReceptionReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ExtensiveReceptionReport()
        {
            InitializeComponent();
        }
        public void InitData(List<ExtensiveReceptionProfile> list)
        {
            objectDataSource1.DataSource = list;
        }
    }
}
