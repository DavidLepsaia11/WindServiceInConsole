using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace HeartBeaterService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x => 
            {
                x.Service<HeartBeat>(s => 
                {
                    s.ConstructUsing(heartBeat => new HeartBeat());
                    s.WhenStarted(heartBeat => { heartBeat.Start();});
                    s.WhenStopped(heartBeat => { heartBeat.Stop();});
                });
                x.RunAsLocalService();
                x.SetServiceName("HeartBeatService");
                x.SetDescription("Heart Beat service sample");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode,exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
