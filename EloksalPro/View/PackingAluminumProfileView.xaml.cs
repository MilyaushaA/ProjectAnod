using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EloksalPro.View
{
    /// <summary>
    /// Логика взаимодействия для PackingAluminumProfileView.xaml
    /// </summary>
    public partial class PackingAluminumProfileView : Window
    {
        public PackingAluminumProfileView()
        {
            InitializeComponent();
            tableView.MouseLeftButtonUp += TableView_MouseLeftButtonUp;
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
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }
        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }
    }
}