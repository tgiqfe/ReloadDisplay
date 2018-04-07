using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Threading;

namespace ReloadDisplay
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementObject modis = new ManagementClass("Win32_PNPEntity").
                GetInstances().
                OfType<ManagementObject>().
                FirstOrDefault(x => x["PNPClass"] != null && x["PNPClass"] as string == "Display");
            modis.InvokeMethod("Disable", new object[] { 0 });
            Thread.Sleep(100);
            modis.InvokeMethod("Enable", new object[] { 0 });
        }
    }
}
