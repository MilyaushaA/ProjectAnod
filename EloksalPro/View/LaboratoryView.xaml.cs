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
    /// Логика взаимодействия для Laboratory.xaml
    /// </summary>
    public partial class LaboratoryView : UserControl
    {
        public LaboratoryView()
        {
            InitializeComponent();
            tableView.MouseLeftButtonUp += TableView_MouseLeftButtonUp;
            gridControl.ExpandGroupRow(-1, false);
        }
    private void TableView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        int selectedIndex = tableView.FocusedRowHandle; // Получение индекса выбранной строки
        object id;
        if (selectedIndex < 0)
        {
            id = 0;
        }
        else
        {
            id = gridControl.GetCellValue(selectedIndex, "Id").ToString();
        }

        //int Id = Convert.ToInt32(id);
        txtId.Text = id.ToString();
    }
}
}
