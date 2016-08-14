using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;

namespace Server.Timers
{
    class KeepNetworkAlive : IDisposable
    {
        double Interval = 30 * 1000;
        System.Timers.Timer timer = new System.Timers.Timer();

        public KeepNetworkAlive()
        {
            timer.Elapsed += Elapsed;
            timer.Interval = Interval;
        }

        private async void Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            await Program.Network.keepAlive();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Pause()
        {
            timer.Stop();
        }

        public void Dispose()
        {
            timer.Dispose();
        }
    }
}
