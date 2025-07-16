using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using EloksalPro.Models;
using System.Collections.Generic;

namespace EloksalPro.View.Report
{
    public partial class ReportShipment : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportShipment()
        {
            InitializeComponent();
        }
        public void InitData(string clientName, string date, string numberShip,string name,List<ProfileConsumptionWarehouse> list)
        {
            ClientName.Value = clientName;
            Date.Value = date;
            Number.Value = numberShip;
            NameWorker.Value = name;
            objectDataSource1.DataSource = list;
        }

    }
}
