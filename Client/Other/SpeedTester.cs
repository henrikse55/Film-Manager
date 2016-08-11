using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Client.Other
{
    class SpeedTester
    {
        static TimeSpan bench;
        static bool started = false;
        static Stopwatch watch = new Stopwatch();
        public static void Click()
        {
            if (started)
            {
                watch.Stop();
                bench = watch.Elapsed;
                MessageBox.Show(bench.ToString());
                watch.Reset();
                started = false;
            }

            
            if (!started)
            {
                watch.Start();
                started = true;
            }
        }
    }
}
