using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LoaderExceptionsRepro
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder();
            builder.ConfigureLogging((context, b) => b.AddConsole());
            builder.ConfigureWebJobs(b => b.AddAzureStorage());

            var host = builder.Build();
            using (host)
            {
                host.Run();
            }
        }
    }
}
