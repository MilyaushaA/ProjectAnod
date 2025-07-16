using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using EloksalPro.Models;
using System.Collections.Generic;

namespace EloksalPro.View.Report
{
    public partial class ReportShotAndAnod : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportShotAndAnod()
        {
            InitializeComponent();
        }
          public void InitData(string shift, string date, List<ShotBlastingProfileReport> list, List<AnodizingProcessProfileReport> listAnod, int downAnod,int  downShot)
        {
             Shift.Value = shift;
             Date.Value = date;
             DownTimeAnod.Value = downAnod;
             DownTimeShot.Value = downShot;
             objectDataSource1.DataSource = list;
             objectDataSource2.DataSource = listAnod;
        }
    }
    }

