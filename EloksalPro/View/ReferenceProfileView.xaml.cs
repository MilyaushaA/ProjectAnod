using DevExpress.Xpf.Grid;
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
    /// Логика взаимодействия для ReferenceProfileView.xaml
    /// </summary>
    public partial class ReferenceProfileView : UserControl
    {
        public ReferenceProfileView()
        {
            InitializeComponent();
            tableView.MouseLeftButtonUp += TableView_MouseLeftButtonUp;
            tableViewClient.MouseLeftButtonUp += TableViewClient_MouseLeftButtonUp;
        }
       
        private void TableView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = tableView.FocusedRowHandle; // Получение индекса выбранной строки
            object id;
            if (selectedIndex <0)
            {
               id = 0;
            }
           else
            {
                id = gridControl.GetCellValue(selectedIndex, "Id").ToString();
            }
            
            //int Id = Convert.ToInt32(id);
            idEloksal.Text = id.ToString();
        }
        private void TableViewClient_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = tableViewClient.FocusedRowHandle; // Получение индекса выбранной строки
            object id;
            if (selectedIndex < 0)
            {
                id = 0;
            }
            else
            {
                id = gridControlClient.GetCellValue(selectedIndex, "Id").ToString();
            }

            //int Id = Convert.ToInt32(id);
            idClient.Text = id.ToString();
        }
        void expandNode(object sender, RoutedEventArgs e)
        {
            gridControl.ExpandAllGroups();
        }
        void collapseNode(object sender, RoutedEventArgs e)
        {

            gridControl.CollapseAllGroups();
        }
    }
}
