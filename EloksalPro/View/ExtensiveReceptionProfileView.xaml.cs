using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для ExtensiveReceptionProfileView.xaml
    /// </summary>
    public partial class ExtensiveReceptionProfileView : Window
    {
        public ExtensiveReceptionProfileView()
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
        private void ExcelGrid(object sender, RoutedEventArgs e)
        {
            //string path = @"C:\\\Users\\user\\Desktop\\\fail.csv";
            //string path = @"\\SERVER\\\ДанныеНасосы\\AllData.xlsx";
            //TreeView.ExportToXlsx(path);
            //MessageBox.Show("Данные выгружены");

            string path = "output.xlsx";
            //tableView.AddNewRow();
            //int newRowHandle = DataControlBase.NewItemRowHandle;
            //gridControl.SetCellValue(newRowHandle, "BasketNumber", 1);
            //gridControl.SetCellValue(newRowHandle, "NumberSpecification", "New Company");
            //gridControl.SetCellValue(newRowHandle, "NomenclatureProfile", "New Product");
            //gridControl.SetCellValue(newRowHandle, "NumberSpecification", "New Company");
            //gridControl.SetCellValue(newRowHandle, "EloksalNoCommercial", "New Product");
            //gridControl.SetCellValue(newRowHandle, "ClientName", "New Company");
            //gridControl.SetCellValue(newRowHandle, "WeightMeter", 0);
            //gridControl.SetCellValue(newRowHandle, "LenghtProfile", 0);
            //gridControl.SetCellValue(newRowHandle, "QuantityProducedProfile", 0);
            //gridControl.SetCellValue(newRowHandle, "WeightProducedProfile", 0);

            tableView.ExportToXlsx(path);
            //var workbook = new Workbook();
            //workbook.LoadDocument("output.xlsx");
            //var worksheet = workbook.Worksheets[0];

            //// Добавить заголовок
            //worksheet.Cells[0, 0].Value = "Дополнительная информация";
            //worksheet.Cells[1, 0].Value = "Здесь может быть ваш текст";

            //workbook.SaveDocument("output_with_info.xlsx");
            Process.Start(path);

                 }

    }
}