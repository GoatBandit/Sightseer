using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Sightseer.Pages
{
    public class IndexModel : PageModel
    {
        public List<Process> Processes { get; set; }

        public string TEST = "ThisIsTheTestVariable.";

        // // SPECIFIC TO WINDOWS
        // public PerformanceCounter cpuCounter;


        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var items = Process.GetProcesses().Where(p => !String.IsNullOrEmpty(p.ProcessName) && !p.ProcessName.Contains("handle="));
            Processes = items.ToList();

            // cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }
    }
}
