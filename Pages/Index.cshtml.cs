using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace Sightseer.Pages
{
    public class IndexModel : PageModel
    {
        public List<Process> Processes { get; set; }

        // SPECIFIC TO WINDOWS
        private PerformanceCounter cpuCounter = null;
        private PerformanceCounter ramCounter = null;

        public float cpuUsage;
        public string ramUsage;

        private protected static bool running;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var items = Process.GetProcesses().Where(p => !String.IsNullOrEmpty(p.ProcessName) && !p.ProcessName.Contains("handle="));
            Processes = items.ToList();
            
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            // TimerFunction(); 

            if (!running)
            {
                InitCounters();
            }
        }

        private void InitCounters()
        {
            running = true;

            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes", String.Empty);
            
            int seconds = 2 * 1000;
            var timer = new Timer(timerTick, null, 0, seconds);
        }

        private void timerTick(Object sender)
        {
            cpuUsage = cpuCounter.NextValue();
            ramUsage = String.Format("{0} MB", ramCounter.NextValue());

            Console.WriteLine(cpuUsage + "%");
        }

        public float getCPU()
        {
            return cpuUsage;
        }






        // private void TimerFunction()
        // {
        //     int seconds = 1 * 1000;
        //     var timer = new Timer(TimerFunc, null, 0, seconds);
        // }

        // void TimerFunc(object objectInfo)
        // {
        //     cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            
        //     var first = cpuCounter.NextValue();
        //     Thread.Sleep(2500);
        //     cpuUsage = cpuCounter.NextValue()+"%";
        //     Console.WriteLine(cpuUsage);
        // }
    }
}
