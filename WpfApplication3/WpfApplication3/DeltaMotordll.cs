using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace Trois
{
    class DeltaMotordll
    {
        [DllImport("deltamovectrl.dll", CharSet = CharSet.Auto, EntryPoint = "CardSet", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern void _Set(int model);

        [DllImport("deltamovectrl.dll", CharSet = CharSet.Auto, EntryPoint = "Move", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern void _Move(double RPMs);

        [DllImport("deltamovectrl.dll", CharSet = CharSet.Auto, EntryPoint = "Stop", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern void _Stop();

        [DllImport("deltamovectrl.dll", CharSet = CharSet.Auto, EntryPoint = "Reset8253", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern void _Reset8253();

        public void Set(int model) {
            _Set(model);
            return;
        }

        public void Move(int RPMSpeed)
        {
            _Move(RPMSpeed);
            return;
        }

        public void Stop()
        {
            _Stop();
            return;
        }
        public void Reset8253()
        {
            _Reset8253();
            return;
        }

    }
}
