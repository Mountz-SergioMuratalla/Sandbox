using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3
{
    class PinBaoCard
    {

        /// /////////////////////////////////////////////////////////////
        //Declib function imports (for pci cards usage)

        [DllImport("DecLib.dll", CharSet = CharSet.Auto, EntryPoint = "_GetDevicePortAddress@8", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern int GetDevicePortAddress(int DeviceType, ref int BaseAddress);

        [DllImport("DecLib.dll", EntryPoint = "_outportb@8", CallingConvention = CallingConvention.StdCall)]
        private static extern int DecOutb(int PortAddress, byte State);

        [DllImport("DecLib.dll", EntryPoint = "_outport@8", CallingConvention = CallingConvention.StdCall)]
        private static extern int DecOutLong(int PortAddress, int State);

        [DllImport("DecLib.dll", CharSet = CharSet.Auto, EntryPoint = "_inportb@4", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern byte DecInpb(int PortAddress);

        [DllImport("DecLib.dll", CharSet = CharSet.Auto, EntryPoint = "_inport@4", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern byte DecInpLong(int PortAddress);



        ///INPOUT32 functions
        [DllImport("c:/windows/system32/inpout32.dll", CharSet = CharSet.Auto, EntryPoint = "Inp32", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern int Inp(int PortAddress);

        [DllImport("c:/windows/system32/inpout32.dll", CharSet = CharSet.Auto, EntryPoint = "Out32", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern int OUT(int PortAddress, int Value);


        /// <summary>
        ///         
        //[DllImport("inpout32.dll")]
        //private static extern void Out32(short PortAddress, short Data);

        //[DllImport("inpout32.dll")]
        //private static extern char Inp32(short PortAddress);
        /// </summary>
        
        private j, k;



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

            
        public static int ad_addr = 4096;
        public static int io_addr = 57344;
        public static int m = GetDevicePortAddress(DECISION_PCI_8255_CARD, ref io_addr);
        public static int ad13bit = 2048;   //'bin 0100000000000        this number starts at digit 12      MURA
        public static int ad14bit = 4095;  // 'bin 0111111111111                                            MURA

        //'''io port addresses tag asignation
        public static int P1A = io_addr + 0;
        public static int P1B = io_addr + 1;
        public static int P1C = io_addr + 2;
        public static int P1CTRL = io_addr + 3;

        public static int P2A = io_addr + 4;
        public static int P2B = io_addr + 5;
        public static int P2C = io_addr + 6;
        public static int P2CTRL = io_addr + 7;

        public static int CNT0 = io_addr + 8;
        public static int CNT1 = io_addr + 9;
        public static int CNT2 = io_addr + 10;
        public static int CNT_CTRL = io_addr + 11;


        //'''setting  up card 8255

        public static int k = DecOutb(P1CTRL, 0x8B);
        public static int k1 = DecOutb(P2CTRL, 0x9B);
        public static int k2 = DecOutb(P1A, 0xFF);
        public static int k3 = DecOutb(P1A, 0x0);



        // set 8253
        private static int k4 = DecOutb(CNT_CTRL, 0x30);
        private static int k5 = DecOutb(CNT_CTRL, 0x70);
        private static int k6 = DecOutb(CNT_CTRL, 0xB0);
        private static byte i = DecInpb(CNT0), j = DecInpb(CNT0);
        private static int k7 = DecOutb(CNT0, i), k8 = DecOutb(CNT0, j);
        private static byte i1 = DecInpb(CNT1), j1 = DecInpb(CNT1);
        private static int k9 = DecOutb(CNT1, i1), k10 = DecOutb(CNT1, j1);

        //stop lamp
        private static byte STOP_SPEED = 0x8;
        private static byte ZERO_SPEED = 0xF7;
        private static byte i3 = DecInpb(P1A);
        private static int k11 = DecOutb(P1A, (byte)(i3 | STOP_SPEED));//'STOP_SPEED=&H8

        //stop lamp
        public void StopLamp() {
           i= DecInpb(P1A);
           DecOutb(P1A, (byte)(i| STOP_SPEED));//'STOP_SPEED=&H8
        }



    

















    }
}
