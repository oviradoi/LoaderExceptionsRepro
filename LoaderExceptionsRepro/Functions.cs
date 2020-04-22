using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace LoaderExceptionsRepro
{
	public static class Functions
    {
        [NoAutomaticTrigger]
        public static void TestFunction()
        {
        }
    }
}
