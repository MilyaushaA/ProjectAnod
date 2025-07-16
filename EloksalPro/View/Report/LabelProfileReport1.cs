using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using EloksalPro.Models;
using System.Collections.Generic;

namespace EloksalPro.View.Report
{
    public partial class LabelProfileReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public LabelProfileReport1()
        {
            InitializeComponent();
        }
        public void InitData(PackingAluminumProfile listCommercialOffer)
        {
            objectDataSource1.DataSource = listCommercialOffer;
        }

    }
}
