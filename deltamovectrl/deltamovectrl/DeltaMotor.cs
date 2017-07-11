using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;



namespace deltamovectrl
{
    public class DeltaMotor
    {
        internal PinBaoCard Card = new PinBaoCard();//creates an instance of the card to comunicate with
        //delete this comment
        private int cnt0_back, cnt1_back, cnt0_now, cnt1_now, count0, count1; //variables for angle counting
        private double origin, COUNTER, an, ab, angle360 = 0;
        private double votage_cal = 1;    //direction? -1 for small machines, 1 for bigger MTTMs
        private double test_speed = 0.5;  //main speed
        private double ad13bit = 2048;   //bin 0100000000000        this number starts at digit 12      MURA
        private double ad14bit = 4095;   //bin 0111111111111                                            MURA
        private double motor_speed_max = 3000;        //CHECKIFUSED
        private double slower = 630.8;   //factor used to calculate the actual signal to be sent for the speed   CHECKIFUSED
        private double originsum = 0;
        private double preset_origin = 0;
        private double encoder = 6308;
        private double pitch = 3.6;
        private double M1RPMBaseSpeed = 0.2;
        //private double angle360 = 161.71
        private int MTTMDirection = 1;   // CHeCKIFUSED

        public void Stop()
        {
            Card.Stop();
            return;
        }

        public void Move(double RPMspeed)
        {
            Card.ActivateMotor();
            double rawSpeed = ad13bit + ((RPMspeed * ad13bit * votage_cal) / (motor_speed_max / 630.8));
            Card.MoveCommand((int)rawSpeed);
        }

        // int pciad_addr = -7936;
        //int DATA = 2600;

        public void Reset8253()
        {
            cnt0_back = Card.Resetcnt0_back();
            cnt1_back = Card.Resetcnt1_back();
            cnt0_now = cnt0_back;
            cnt1_now = cnt1_back;
            count0 = 0;
            count1 = 0;
            origin = 0;
            COUNTER = 0;
            an = 0;
            ab = 0;
            angle360 = 0;
        }

        public void CardSet(int cardmodel)
        {
            switch (cardmodel){
                case 8253:
                    Card.Set8253();
                    break;
                case 8255:
                    Card.Set8255();
                    break;
                default:
                    Card.Set8253();
                    Card.Set8255();
                    break;
            }
            return;
        }
    }




    //class AngleControler(){
    //}



    internal class PinBaoCard
    {

        /// /////////////////////////////////////////////////////////////
        //Declib function imports (for pci cards usage)

        [DllImport("DecLib.dll", CharSet = CharSet.Unicode, EntryPoint = "_GetDevicePortAddress@8", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern int GetDevicePortAddress(int DeviceType, ref int BaseAddress);

        [DllImport("DecLib.dll", EntryPoint = "_outportb@8", CallingConvention = CallingConvention.StdCall)]
        private static extern int DecOutb(int PortAddress, byte State);

        [DllImport("DecLib.dll", EntryPoint = "_outport@8", CallingConvention = CallingConvention.StdCall)]
        private static extern int DecOutLong(int PortAddress, int State);

        [DllImport("DecLib.dll", CharSet = CharSet.Unicode, EntryPoint = "_inportb@4", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern byte DecInpb(int PortAddress);

        [DllImport("DecLib.dll", CharSet = CharSet.Unicode, EntryPoint = "_inport@4", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern byte DecInpLong(int PortAddress);



        ///INPOUT32 functions
        [DllImport("c:/windows/system32/inpout32.dll", CharSet = CharSet.Unicode, EntryPoint = "Inp32", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern int Inp(int PortAddress);

        [DllImport("c:/windows/system32/inpout32.dll", CharSet = CharSet.Unicode, EntryPoint = "Out32", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern int OUT(int PortAddress, int Value);


        /// <summary>
        ///         
        //[DllImport("inpout32.dll")]
        //private static extern void Out32(short PortAddress, short Data);

        //[DllImport("inpout32.dll")]
        //private static extern char Inp32(short PortAddress);
        /// </summary>

        private byte i,j;
        private int k;

        private const int DECISION_PCI_IND_CARD = 1;
        private const int DECISION_PCI_8255_CARD = 2;
        private const int DECISION_PCI_4P4R_CARD = 3;
        private const int DECISION_PCI_8P8R_CARD = 4;
        private const int DECISION_PCI_16P16R_CARD = 5;
        private const int DECISION_PCI_WATCHDOG_CARD = 6;
        private const int DECISION_PCI_M8255_CARD = 7;
        private const int DECISION_PCI_12ADDA_CARD = 8;
        private const int DECISION_PCI_14ADDA_CARD = 9;
        /// End of declib + io function definitions
        /// /////////////////////////////////////////////////////////////

        private static int ad_addr = 4096;
        private static int ad_bits = 12;
        private static int io_addr = 57344;
        private static int io_addr_Alt = 57344;
        private static int pciad_addr;//alternative
        private static int m = GetDevicePortAddress(DECISION_PCI_8255_CARD, ref io_addr);
        private static int m2 = GetDevicePortAddress(DECISION_PCI_12ADDA_CARD, ref pciad_addr);
        private static int ad13bit = 2048;   //'bin 0100000000000        this number starts at digit 12      MURA
        private static int ad14bit = 4095;  // 'bin 0111111111111                                            MURA

        public string CheckAddresses()
        {
            return (string)("ad_addr: " + ad_addr + "\n" + "io_addr: " + ad_addr + "  and should should be 57344 \n" + "pciad_addr: " + pciad_addr + "\n");
        }


        //'''io port addresses tag asignation
        private static int P1A = io_addr + 0;
        private static int P1B = io_addr + 1;
        private static int P1C = io_addr + 2;
        private static int P1CTRL = io_addr + 3;

        private static int P2A = io_addr + 4;
        private static int P2B = io_addr + 5;
        private static int P2C = io_addr + 6;
        private static int P2CTRL = io_addr + 7;

        private static int CNT0 = io_addr + 8;
        private static int CNT1 = io_addr + 9;
        private static int CNT2 = io_addr + 10;
        private static int CNT_CTRL = io_addr + 11;

        private static byte ZERO_SPEED = 0xF7;
        private static byte STOP_SPEED = 0x8;



        //'''setting  up card 8255
        //public static int k0 = DecOutb(P1CTRL, 0x8B);
        //public static int k1 = DecOutb(P2CTRL, 0x9B);
        //public static int k2 = DecOutb(P1A, 0xFF);
        //public static int k3 = DecOutb(P1A, 0x0);
        public void Set8255()
        {
            k = DecOutb(P1CTRL, 0x8B);
            k = DecOutb(P2CTRL, 0x9B);
            k = DecOutb(P1A, 0xFF);
            k = DecOutb(P1A, 0x0);
            return;
        }

        // set 8253
        //private static int k4 = DecOutb(CNT_CTRL, 0x30);
        //private static int k5 = DecOutb(CNT_CTRL, 0x70);
        //private static int k6 = DecOutb(CNT_CTRL, 0xB0);
        //private static byte i = DecInpb(CNT0), j = DecInpb(CNT0);
        //private static int k7 = DecOutb(CNT0, i), k8 = DecOutb(CNT0, j);
        //private static byte i1 = DecInpb(CNT1), j1 = DecInpb(CNT1);
        //private static int k9 = DecOutb(CNT1, i1), k10 = DecOutb(CNT1, j1);
        public void Set8253()
        {
            k = DecOutb(CNT_CTRL, 0x30);
            k = DecOutb(CNT_CTRL, 0x70);
            k = DecOutb(CNT_CTRL, 0xB0);
            i = DecInpb(CNT0);
            j = DecInpb(CNT0);
            k = DecOutb(CNT0, i);
            k = DecOutb(CNT0, j);
            i = DecInpb(CNT1);
            j = DecInpb(CNT1);
            k = DecOutb(CNT1, i);
            k = DecOutb(CNT1, j);
            return;
        }


        //stop lamp
        //private static byte i3 = DecInpb(P1A);
        //private static int k11 = DecOutb(P1A, (byte)(i3 | STOP_SPEED));//'STOP_SPEED=&H8
        public void Stop()
        {
            i = DecInpb(P1A);
            DecOutb(P1A, (byte)(i | STOP_SPEED));//'STOP_SPEED=&H8
            return;
        }


        public int UpdateIO_addr()
        {
            m = GetDevicePortAddress(DECISION_PCI_8255_CARD, ref io_addr);
            return m;
        }

        public int GetIO_addr()
        {
            return io_addr;
        }

        public int ReadAddress(string a)
        {
            switch (a)
            {
                case "CNT0":
                    return DecInpb(CNT0);

                default: return 0;
            }
        }

        public byte Resetcnt0_back()
        {
            byte cnt0back;
            k = DecOutb(CNT_CTRL, 0x0); //0000 0000
            cnt0back = DecInpb(CNT0);
            //cnt0back = cnt0back + (DecInpb(CNT0) << 8); check just in case this might be missing, find a way to implement it
            return cnt0back;
        }

        public byte Resetcnt1_back()
        {
            byte cnt1back;
            k = DecOutb(CNT_CTRL, 0x40); //0010 0000
            cnt1back = DecInpb(CNT1);
            //cnt1_back = cnt1_back + CLng(DecInpb(CNT1)) * 256    to   cnt1back = cnt0back + (DecInpb(CNT1) << 8); check just in case this might be missing, find a way to implement it
            return cnt1back;
        }

        public void ActivateMotor()
        {
            i = DecInpb(P1A);
            k = DecOutb(P1A, (byte)(i & ZERO_SPEED));  //  ZERO_SPEED=&HF7=11110111
        }

        public void MoveCommand(int SpeedRawValue)
        {
            if (SpeedRawValue >= ad14bit) { SpeedRawValue = ad14bit; };
            k = DecOutLong(pciad_addr + 4, SpeedRawValue);
        }


    }//namespace closing bracket

}//End of namespace