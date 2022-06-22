//create a class that shows all running process 
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClearMem2
{
    internal class Program
    {
        static NotifyIcon notifyIcon = new NotifyIcon();
  
        static void Main(string[] args)
        {

            var form = new BaseForm(); 
            notifyIcon.Icon = form.Icon;
            notifyIcon.Visible = true;
            notifyIcon.Text = Application.ProductName;

            var builder = new ConfigurationBuilder()
                              .AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build();
            int timeInMiliseconds = Convert.ToInt32(config["TimeInMiliseconds"]);
     
            while (true)
            {
                Process[] process = Process.GetProcesses();
                foreach (Process p in process)
                {
                    try
                    {
                        SetProcessWorkingSetSize64Bit(p.Handle, -1, -1);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            SetProcessWorkingSetSize32Bit(p.Handle, -1, -1);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                
                Thread.Sleep(timeInMiliseconds);
            }
        }
                

        [DllImport("KERNEL32.DLL", EntryPoint =
       "SetProcessWorkingSetSize", SetLastError = true,
       CallingConvention = CallingConvention.StdCall)]
        internal static extern bool SetProcessWorkingSetSize32Bit
       (IntPtr pProcess, int dwMinimumWorkingSetSize,
       int dwMaximumWorkingSetSize);

        [DllImport("KERNEL32.DLL", EntryPoint =
           "SetProcessWorkingSetSize", SetLastError = true,
           CallingConvention = CallingConvention.StdCall)]
        internal static extern bool SetProcessWorkingSetSize64Bit
           (IntPtr pProcess, long dwMinimumWorkingSetSize,
           long dwMaximumWorkingSetSize);

    }
}