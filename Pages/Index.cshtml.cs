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
        public PerformanceCounter cpuCounter;
        public string cpuUsage;

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
        }

        public string getCPUUsage()
        {
            return cpuCounter.NextValue()+"%";
        }











        private void TimerFunction()
        {
            int seconds = 1 * 1000;
            var timer = new Timer(TimerFunc, null, 0, seconds);
        }

        void TimerFunc(object objectInfo)
        {
            Console.WriteLine("Update Call");
        }
    }
}
