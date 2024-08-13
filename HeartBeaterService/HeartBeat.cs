using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;

namespace HeartBeaterService
{
    public class HeartBeat
    {
        private readonly Timer _timer;
        private readonly string _filePath;
        public HeartBeat()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _filePath = @"D:\test.txt";
            _timer.Elapsed += TimerElapsedEv;
        }

        private void TimerElapsedEv(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(_filePath,lines);
        }

        public void Start() 
        { 
          _timer.Start();   
        }

        public void Stop() 
        {
          _timer.Stop();
        }
    }
}
