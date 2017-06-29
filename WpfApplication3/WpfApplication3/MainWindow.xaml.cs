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

using System.Runtime.InteropServices;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>



    public partial class MainWindow : Window
    {
       



        PinBaoCard 





        public MainWindow()
        {
            InitializeComponent();
        }







        private void Button_Click(object sender, RoutedEventArgs e)
        {

            int DATA;
            int pciad_addr = -7936;
            DATA = 2600;

            byte i = DecInpb(P1A);         //   'saves whatever is already in the port
            int k1 = DecOutLong(P1A, (i & ZERO_SPEED));
            int b = (i & ZERO_SPEED);
            System.Windows.MessageBox.Show(b.ToString());

          
            
                       
            int k2= DecOutLong(pciad_addr + 4, DATA);
            this.StatusTextBox.Text = k1.ToString() + " " + k2.ToString()+ " "+(pciad_addr+4).ToString()+ " " + DATA.ToString();

        }
    }
}
