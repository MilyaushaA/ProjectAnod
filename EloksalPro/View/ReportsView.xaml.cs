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
    /// Логика взаимодействия для ReportsView.xaml
    /// </summary>
    public partial class ReportsView : UserControl
    {
        public ReportsView()
        {
            InitializeComponent();
            checkBox.Checked += СheckBoxСhecked;
            checkBox.Unchecked += СheckBoxUnchecked;
            checkBox1.Checked += СheckBoxCheckedTwo;
            checkBox1.Unchecked += СheckBoxUncheckedTwo;
        }

        public void СheckBoxСhecked(object sender, EventArgs e)
        {
            if (checkBox.IsChecked == true)
                checkBox1.IsEnabled = false;
        }
        public void СheckBoxUnchecked(object sender, EventArgs e)
        {
            if (checkBox.IsChecked == false || checkBox.IsChecked == null)
            {
                checkBox1.IsEnabled = true;
            }
        }
        public void СheckBoxCheckedTwo(object sender, EventArgs e)
        {
            if (checkBox1.IsChecked == true)
                checkBox.IsEnabled = false;
        }
        public void СheckBoxUncheckedTwo(object sender, EventArgs e)
        {
            if (checkBox1.IsChecked == false || checkBox1.IsChecked == null)
            {
                checkBox.IsEnabled = true;
            }
        }
    }
}
