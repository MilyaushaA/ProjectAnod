using DevExpress.Xpf.Grid;
using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EloksalPro.View
{
    /// <summary>
    /// Логика взаимодействия для StorehouseView.xaml
    /// </summary>
    public partial class StorehouseView : UserControl
    {
        public StorehouseView()
        {
            InitializeComponent();
            tableViewConsumptionWarehouse.MouseLeftButtonUp += TableView_MouseLeftButtonUp;
            tableViewReception.MouseLeftButtonUp += TableViewReception_MouseLeftButtonUp;
            gridControlPackingAluminumProfileSummary.SelectedItemChanged += gridControl_SelectedItemChangedPackingAluminumProfileSummaryTable;

            gridControlReception.ExpandGroupRow(-1, false);
            gridControlPackingAluminumProfileSummary.ExpandGroupRow(-1, false);
            gridControlConsumptionWarehouse.ExpandGroupRow(-1, false);
        }
        private void TableView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = tableViewConsumptionWarehouse.FocusedRowHandle; // Получение индекса выбранной строки
            object id;
            if (selectedIndex < 0)
            {
                id = 0;
            }
            else
            {
                id = gridControlConsumptionWarehouse.GetCellValue(selectedIndex, "Id").ToString();
            }

            //int Id = Convert.ToInt32(id);
            txtIdConsumptionWarehouse.Text = id.ToString();
        }
        private void TableViewReception_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = tableViewReception.FocusedRowHandle; // Получение индекса выбранной строки
            object id;
            if (selectedIndex < 0)
            {
                id = 0;
            }
            else
            {
                id = gridControlReception.GetCellValue(selectedIndex, "Id").ToString();
            }
            //int Id = Convert.ToInt32(id);
            txtidReceptionSpecification.Text = id.ToString();
        }

        void expandNode(object sender, RoutedEventArgs e)
        {
            gridControlReception.ExpandAllGroups();
            gridControlConsumptionWarehouse.ExpandAllGroups();
        }
        void collapseNode(object sender, RoutedEventArgs e)
        {

            gridControlReception.CollapseAllGroups();
            gridControlConsumptionWarehouse.CollapseAllGroups();
        }
        private void gridControl_SelectedItemChangedPackingAluminumProfileSummaryTable(object sender, SelectedItemChangedEventArgs e)
        {
            PackingAluminumProfileSummaryTable item = e.NewItem as PackingAluminumProfileSummaryTable;
            if (item != null)
            {
                txtIdPackingAluminumProfileSummary.Text = item.Id.ToString();
                txtBasketSummary.Text = item.BasketNumber.ToString();
            }
        }
    }
}
