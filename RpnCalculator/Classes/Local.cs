using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpnCalculator.Forms;

namespace RpnCalculator.Classes
{
    public static class Local
    {
        public static MainWindow window { get; set; }

        public static Stack<string> stack;

        static Local()
        {
        }
    }
}
