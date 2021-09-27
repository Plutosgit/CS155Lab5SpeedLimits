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

namespace CS155Lab5SpeedLimits
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Speed Limits";
            lblStatus.Content = "";
            txtSpeedLimit.Text = "65";

            txtMySpeed.Focus();

        }

        private void txtSpeedLimit_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSpeedLimit.SelectAll();
        }

        private void txtMySpeed_GotFocus(object sender, RoutedEventArgs e)
        {
            txtMySpeed.SelectAll();
        }

        private void cmdCheckSpeedLimit_OnClick(object sender, RoutedEventArgs e)
        {
            double dSpeedLimit, dMySpeed;
            bool bResult;

            bResult = Double.TryParse(txtSpeedLimit.Text, out dSpeedLimit);
            if (!bResult)
            {
                MessageBox.Show("Please enter a valid Speed Limit!");
                return;
            }

            bResult = Double.TryParse(txtMySpeed.Text, out dMySpeed);
            if (!bResult)
            {
                MessageBox.Show("Please enter a valid Speed for you!");
                return;
            }

            if (dMySpeed <= dSpeedLimit)
            {
                canvasMain.Background = Brushes.Green;
                lblStatus.Content = "Status: Legal Speed";
            }
            else if ((dMySpeed - dSpeedLimit) < 5.0)
            {
                canvasMain.Background = Brushes.Yellow;
                lblStatus.Content = "Status: Warning - Speeding, no Penalty";
            }
            else
            {
                canvasMain.Background = Brushes.Red;
                lblStatus.Content = "Status: Warning - Speeding, Penalty";

            }


        }
    }
}
