using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading;
using ElectronNET.API;

namespace Sightseer.Pages
{
    public class IndexModel : PageModel
    {
        public List<Process> Processes { get; set; }

        // Ensure only one timer is running
        private protected static bool running;

        // SPECIFIC TO WINDOWS 
        private PerformanceCounter cpuCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        private PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");

        public float cpuUsage;
        // public string ramUsage;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var items = Process.GetProcesses().Where(p => !String.IsNullOrEmpty(p.ProcessName) && !p.ProcessName.Contains("handle="));
            Processes = items.ToList();

            if (!running)
            {
                InitCounters();
            }

            test();
        }

        private async void test()
        {
            Console.WriteLine(Electron.HostHook.CallAsync<string>("redraw") + "AHAHAHAHAs"); 
            // var resultFromTypeScript = await Electron.HostHook.CallAsync<object>("showOpenDialogMain");
        }

        private void InitCounters()
        {
            running = true;
            
            int seconds = 2 * 1000;
            var timer = new Timer(timerTick, null, 0, seconds);
        }

        private void timerTick(Object sender)
        {
            cpuUsage = cpuCounter.NextValue();
            // ramUsage = String.Format("{0} MB", ramCounter.NextValue());

            Console.WriteLine(cpuUsage + "%");
        }

        public float getCPU()
        {
            return cpuUsage;
        }
    }
}
