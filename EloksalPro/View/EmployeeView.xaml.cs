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
    /// Логика взаимодействия для CustomerView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        public EmployeeView()
        {
            InitializeComponent();
            tableViewEmployee.MouseLeftButtonUp += TableView_MouseLeftButtonUp;
        }

        private void TableView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = tableViewEmployee.FocusedRowHandle; // Получение индекса выбранной строки
            object id;
            if (selectedIndex < 0)
            {
                id = 0;
            }
            else
            {
                id = gridControlEmployee.GetCellValue(selectedIndex, "Id").ToString();
            }

            //int Id = Convert.ToInt32(id);
            txtEmployee.Text = id.ToString();
        }

    }
}
