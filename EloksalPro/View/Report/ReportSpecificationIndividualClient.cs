using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using EloksalPro.Models;
using System.Collections.Generic;

namespace EloksalPro.View.Report
{
    public partial class ReportSpecificationIndividualClient : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportSpecificationIndividualClient()
        {
            InitializeComponent();
        }
        public void InitData(string clientName, DateTime dateSpecification, string numberSpecification, string numberContract, DateTime dateContract,
                           List<SpecificationAllDescription> listSpecificationAllDescription, List<AppendixSpesification> listAppendixSpesification)
        {
            ClientName.Value = clientName;
            DateSpecification.Value = dateSpecification;
            NumSpecification.Value = numberSpecification;
            NumContract.Value = numberContract;
            DateContract.Value = dateContract;
            objectDataSource1.DataSource = listSpecificationAllDescription;
            objectDataSource2.DataSource = listAppendixSpesification;
        }
    }
}
