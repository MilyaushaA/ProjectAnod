using DevExpress.Xpf.Grid;
using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для ProductionProfileView.xaml
    /// </summary>
    public partial class ProductionProfileView : UserControl
    {
        public ProductionProfileView()
        {
            InitializeComponent();
            gridControlShotBlastingProfilesGenerals.SelectedItemChanged += gridControl_SelectedItemChangedShotBlastingProfilesGenerals;
            gridControlShotBlasting.SelectedItemChanged += gridControl_SelectedItemChangedShotBlastingProfileSummaryTable;
          
            gridControlAnodizingProcessProfile.SelectedItemChanged += gridControl_SelectedItemChangedAnodizingProcessProfile;
            gridControlAnodizingSummary.SelectedItemChanged += gridControl_SelectedItemChangedAnodizingProcessProfileSummaryTable;

            gridControlTypeProtectiveProcessProfile.SelectedItemChanged += gridControl_SelectedItemChangedTapeProtectiveProcessProfile;
            gridControlTypeProtectiveSummary.SelectedItemChanged += gridControl_SelectedItemChangedTapeProtectiveProcessProfileSummaryTable;

            gridControlСuttingFacingProfile.SelectedItemChanged += gridControl_SelectedItemChangedСuttingFacingGeneralProfile;
            gridControlСuttingFacingProfileSummary.SelectedItemChanged += gridControl_SelectedItemChangedСuttingFacingGeneralProfileSummaryTable;

            gridControlPackingAluminumProfile.SelectedItemChanged += gridControl_SelectedItemChangedPackingAluminumProfile;
            gridControlPackingAluminumProfileSummary.SelectedItemChanged += gridControl_SelectedItemChangedPackingAluminumProfileSummaryTable;
            //tableViewPackingAluminumProfile.MouseLeftButtonUp += TableViewFive_MouseLeftButtonUp;
            gridControlSummaryTableProfile.SelectedItemChanged += gridControl_SelectedItemChanged;
            gridControlSummaryTableProfileCutting.SelectedItemChanged += gridControl_SelectedItemChangedTwo;

            gridControlPackingAluminumProfile.ExpandGroupRow(-1, false);
            gridControlPackingAluminumProfileSummary.ExpandGroupRow(-1, false);
            gridControlСuttingFacingProfile.ExpandGroupRow(-1, false);
            gridControlСuttingFacingProfileSummary.ExpandGroupRow(-1, false);
            gridControlTypeProtectiveProcessProfile.ExpandGroupRow(-1, false);
            gridControlTypeProtectiveSummary.ExpandGroupRow(-1, false);
            gridControlAnodizingProcessProfile.ExpandGroupRow(-1, false);
            gridControlAnodizingSummary.ExpandGroupRow(-1, false);
            gridControlShotBlastingProfilesGenerals.ExpandGroupRow(-1, false);
            gridControlShotBlasting.ExpandGroupRow(-1, false);

        }
        public void gridControl_SelectedItemChangedShotBlastingProfilesGenerals(object sender, SelectedItemChangedEventArgs e)
        {

            ShotBlastingProfilesGeneral item = e.NewItem as ShotBlastingProfilesGeneral;
            if (item != null)
            {
                txtId.Text = item.Id.ToString();
            }
        }
        public void gridControl_SelectedItemChangedAnodizingProcessProfile(object sender, SelectedItemChangedEventArgs e)
        {

            AnodizingProcessProfileGeneral item = e.NewItem as AnodizingProcessProfileGeneral;
            if (item != null)
            {
                txtIdAnodizingProcessProfile.Text = item.Id.ToString();
            }
        }
        public void gridControl_SelectedItemChangedAnodizingProcessProfileSummaryTable(object sender, SelectedItemChangedEventArgs e)
        {

            AnodizingProcessProfileSummaryTable item = e.NewItem as AnodizingProcessProfileSummaryTable;
            if (item != null)
            {
                txtIdAnodSummary.Text = item.Id.ToString();
            }
        }

        public void gridControl_SelectedItemChangedShotBlastingProfileSummaryTable(object sender, SelectedItemChangedEventArgs e)
        {
            ShotBlastingProfileSummaryTable item = e.NewItem as ShotBlastingProfileSummaryTable;
            if (item != null)
            {
                txtIdShotBlasting.Text = item.Id.ToString();
            }
        }
        public void gridControl_SelectedItemChangedTapeProtectiveProcessProfileSummaryTable(object sender, SelectedItemChangedEventArgs e)
        {
            TapeProtectiveProcessProfileSummaryTable item = e.NewItem as TapeProtectiveProcessProfileSummaryTable;
            if (item != null)
            {
                txtIdTypeProtectiveSummary.Text = item.Id.ToString();
            }
        }

        
        //private void TableViewOne_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    int selectedIndex = tableViewHitchAluminumProfile.FocusedRowHandle; // Получение индекса выбранной строки
        //    object id;
        //    if (selectedIndex < 0)
        //    {
        //        id = 0;
        //    }
        //    else
        //    {
        //        id = gridControlHitchAluminumProfile.GetCellValue(selectedIndex, "Id").ToString();
        //    }

        //    //int Id = Convert.ToInt32(id);
        //    txtIdHitchAluminumProfile.Text = id.ToString();
        //}
        //private void TableViewTwo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    int selectedIndex = tableViewAnodizingProcessProfile.FocusedRowHandle; // Получение индекса выбранной строки
        //    object id;
        //    if (selectedIndex < 0)
        //    {
        //        id = 0;
        //    }
        //    else
        //    {
        //        id = gridControlAnodizingProcessProfile.GetCellValue(selectedIndex, "Id").ToString();
        //    }

        //    int Id = Convert.ToInt32(id);
        //    txtIdAnodizingProcessProfile.Text = id.ToString();
        //}
        private void gridControl_SelectedItemChangedTapeProtectiveProcessProfile(object sender, SelectedItemChangedEventArgs e)
        {
            TapeProtectiveProcessProfileGeneral item = e.NewItem as TapeProtectiveProcessProfileGeneral;
            if (item != null)
            {
                txtIdTypeProtectiveProcessProfile.Text = item.Id.ToString();
            }
        }
        private void gridControl_SelectedItemChangedСuttingFacingGeneralProfile(object sender, SelectedItemChangedEventArgs e)
        {
            СuttingFacingGeneralProfile item = e.NewItem as СuttingFacingGeneralProfile;
            if (item != null)
            {
                txtIdСuttingFacingProfile.Text = item.Id.ToString();
            }
        }
        private void gridControl_SelectedItemChangedСuttingFacingGeneralProfileSummaryTable(object sender, SelectedItemChangedEventArgs e)
        {
            СuttingFacingProfileSummaryTable item = e.NewItem as СuttingFacingProfileSummaryTable;
            if (item != null)
            {
                txtIdСuttingFacingProfileSummary.Text = item.Id.ToString();
            }
        }
        private void gridControl_SelectedItemChangedPackingAluminumProfile(object sender, SelectedItemChangedEventArgs e)
        {
            PackingAluminumProfileGeneral item = e.NewItem as PackingAluminumProfileGeneral;
            if (item != null)
            {
                txtIdPackingAluminumProfile.Text = item.Id.ToString();
            }
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
        //private void TableViewFive_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    int selectedIndex = tableViewPackingAluminumProfile.FocusedRowHandle; // Получение индекса выбранной строки
        //    object id;
        //    if (selectedIndex < 0)
        //    {
        //        id = 0;
        //    }
        //    else
        //    {
        //        id = gridControlPackingAluminumProfile.GetCellValue(selectedIndex, "Id").ToString();
        //    }

        //    //int Id = Convert.ToInt32(id);
        //    txtIdPackingAluminumProfile.Text = id.ToString();
        //}
      
    public void gridControl_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
    {

           SummaryTableProfile item = e.NewItem as SummaryTableProfile;
           if (item != null)
           {
            txtProfile.Text = item.NomenclatureProfile.TrimEnd();
           }
    }
        public void gridControl_SelectedItemChangedTwo(object sender, SelectedItemChangedEventArgs e)
        {

            SummaryTableProfileCutting item = e.NewItem as SummaryTableProfileCutting;
            if (item != null)
            {
                txtProfileCutting.Text = item.NomenclatureProfile.TrimEnd();
            }
        }

        private void ExcelGrid(object sender, RoutedEventArgs e)
        {
            //string path = @"C:\\\Users\\user\\Desktop\\\fail.csv";
            //string path = @"\\SERVER\\\ДанныеНасосы\\AllData.xlsx";
            //TreeView.ExportToXlsx(path);
            //MessageBox.Show("Данные выгружены");

            string path = "output.xlsx";
            tableViewSummaryTableProfile.ExportToXlsx(path);
            Process.Start(path);
        }
        private void ExcelGridCutting(object sender, RoutedEventArgs e)
        {
            //string path = @"C:\\\Users\\user\\Desktop\\\fail.csv";
            //string path = @"\\SERVER\\\ДанныеНасосы\\AllData.xlsx";
            //TreeView.ExportToXlsx(path);
            //MessageBox.Show("Данные выгружены");

            string path = "output.xlsx";
            tableViewSummaryTableProfileCutting.ExportToXlsx(path);
            Process.Start(path);
        }


        
        private void TreeList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                CopySelectedCells();
                e.Handled = true; // Предотвращаем дальнейшее распространение события
            }
       
        }
        private void TreeList_KeyDown_Packing(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                
                CopySelectedCellsPackingAluminumProfileSummary();
                e.Handled = true; // Предотвращаем дальнейшее распространение события
            }  
        }
        private void CopySelectedCells()
        {
            var selectedCells = tableViewSummaryTableProfile.GetSelectedCells(); // Получаем выделенные ячейки
            if (selectedCells.Count > 0)
            {
                StringBuilder clipboardData = new StringBuilder();

                foreach (var cell in selectedCells)
                {
                    {
                        clipboardData.Append(cell);
                        clipboardData.Append("\t"); // Используйте \t для разделения значений в строке
                    }

                    // Убираем последний разделитель
                    if (clipboardData.Length > 0)
                        clipboardData.Length--;

                    // Копируем данные в буфер обмена

                    Clipboard.SetText(clipboardData.ToString());   
                }
            }
        }
        private void CopySelectedCellsPackingAluminumProfileSummary()
        {
            var selectedCells = tableViewPackingAluminumProfileSummary.GetSelectedCells(); // Получаем выделенные ячейки
            if (selectedCells.Count > 0)
            {
                StringBuilder clipboardData = new StringBuilder();

                foreach (var cell in selectedCells)
                {
                    clipboardData.Append(cell);
                    clipboardData.Append("\t"); // Используйте \t для разделения значений в строке
                }

                // Убираем последний разделитель
                if (clipboardData.Length > 0)
                    clipboardData.Length--;

                // Копируем данные в буфер обмена
                Clipboard.SetText(clipboardData.ToString());
            }
        }

    }
}


  
