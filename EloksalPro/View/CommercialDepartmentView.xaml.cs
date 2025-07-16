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
    /// Логика взаимодействия для CommercialDepartmentView.xaml
    /// </summary>
    public partial class CommercialDepartmentView : UserControl
    {
        public CommercialDepartmentView()
        {
            InitializeComponent();
            tableViewProfilePrice.MouseLeftButtonUp += TableView_MouseLeftButtonUp;
            tableViewSpecification.MouseLeftButtonUp += tableViewSpecification_MouseLeftButtonUp;
           
            tableViewCommercialOffer.MouseLeftButtonUp += tableViewOffer_MouseLeftButtonUp;

            gridControlCommercialOffer.ExpandGroupRow(-1, false);
            gridControlSpecification.ExpandGroupRow(-1, false);


        }

        private void TableView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = tableViewProfilePrice.FocusedRowHandle; // Получение индекса выбранной строки
            object id;
            if (selectedIndex < 0)
            {
                id = 0;
            }
            else
            {
                id = gridControlPrice.GetCellValue(selectedIndex, "Id").ToString();
            }
            //int Id = Convert.ToInt32(id);
            idPrice.Text = id.ToString();
        }
        private void tableViewSpecification_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = tableViewSpecification.FocusedRowHandle; // Получение индекса выбранной строки
            object id;
            if (selectedIndex < 0)
            {
                id = 0;
            }
            else
            {
                id = gridControlSpecification.GetCellValue(selectedIndex, "Id").ToString();
            }

            //int Id = Convert.ToInt32(id);
            txtidSpecification.Text = id.ToString();
        }
  
        private void tableViewOffer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = tableViewCommercialOffer.FocusedRowHandle; // Получение индекса выбранной строки
            object id;
            if (selectedIndex < 0)
            {
                id = 0;
            }
            else
            {
                id = gridControlCommercialOffer.GetCellValue(selectedIndex, "Id").ToString();
            }
            //int Id = Convert.ToInt32(id);
            idCommercialOffer.Text = id.ToString();
        }

        void expandNode(object sender, RoutedEventArgs e)
        {
            gridControlSpecification.ExpandAllGroups();
            gridControlPrice.ExpandAllGroups();
            gridControlCommercialOffer.ExpandAllGroups();
        }
        void collapseNode(object sender, RoutedEventArgs e)
        {

            gridControlSpecification.CollapseAllGroups();
            gridControlPrice.CollapseAllGroups();
            gridControlCommercialOffer.CollapseAllGroups();
        }
    }
}
