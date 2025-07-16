using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using EloksalPro.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EloksalPro.View.Report
{
    public partial class ReportExtensiveReception : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportExtensiveReception()
        {
            InitializeComponent();
        }
        public void InitData(ObservableCollection<ExtensiveReceptionProfile> list,DateTime? date,string user)
        {
            Date.Value = date;
            UserName.Value = user;
            objectDataSource1.DataSource = list;
        }

    }
}
