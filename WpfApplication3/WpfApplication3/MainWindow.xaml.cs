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

namespace Trois
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    


    public partial class MainWindow : Window
    {
        private DeltaMotor _m2;

        public MainWindow()
        {
            InitializeComponent();
            _m2 = new DeltaMotor();
            _m2.Card.Set8255();
            _m2.Card.Set8253();

            _m2.Stop();

            _m2.Card.CheckAddresses();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            _m2.Move(1);

            //int DATA;
            //int pciad_addr = -7936;
            //DATA = 2600;

            //byte i = DecInpb(P1A);         //   'saves whatever is already in the port
            //int k1 = DecOutLong(P1A, (i & ZERO_SPEED));
            ////int b = (i & ZERO_SPEED);
            //System.Windows.MessageBox.Show(b.ToString());
                       
            //int k2= DecOutLong(pciad_addr + 4, DATA);
            //this.StatusTextBox.Text = k1.ToString() + " " + k2.ToString()+ " "+(pciad_addr+4).ToString()+ " " + DATA.ToString();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _m2.Stop();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
