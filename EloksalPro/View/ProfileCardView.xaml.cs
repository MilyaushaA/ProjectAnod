using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
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
    /// Логика взаимодействия для ProfileCardView.xaml
    /// </summary>
    public partial class ProfileCardView : Window
    {
        double scale = 1.0;
        double minScale = 1.0;
        double maxScale = 2.0;
        private void onMouseWheel_Scroll(object sender, MouseWheelEventArgs e)
        {

            image.RenderTransform = null;
            var position = e.MouseDevice.GetPosition(image);

            if (e.Delta > 0)
                scale += 0.1;
            else
                scale -= 0.1;

            if (scale > maxScale)
                scale = maxScale;
            if (scale < minScale)
                scale = minScale;

            image.RenderTransform = new ScaleTransform(scale, scale, position.X, position.Y);

        }
        private void onMouseWheel_ScrollPalet(object sender, MouseWheelEventArgs e)
        {

            imagePallet.RenderTransform = null;
            var position = e.MouseDevice.GetPosition(imagePallet);

            if (e.Delta > 0)
                scale += 0.1;
            else
                scale -= 0.1;

            if (scale > maxScale)
                scale = maxScale;
            if (scale < minScale)
                scale = minScale;

            imagePallet.RenderTransform = new ScaleTransform(scale, scale, position.X, position.Y);

        }
        public ProfileCardView()
        {
            InitializeComponent();
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
       
    }

    }

