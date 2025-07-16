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
    /// Логика взаимодействия для TechnicalSupportView.xaml
    /// </summary>
    public partial class TechnicalSupportView : UserControl
    {
        public TechnicalSupportView()
        {
            InitializeComponent();
            gridControl.SelectedItemChanged += gridControl_SelectedItemChanged;


        }
        public void gridControl_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {

            TechnicalSupport item = e.NewItem as TechnicalSupport;
            if (item != null)
            {
                txtId.Text = item.Id.ToString();
            }
        }
    }
}
