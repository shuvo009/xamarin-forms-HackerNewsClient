using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using HackerNewsClient.Core.Interface;

namespace HackerNewsClient.Service.CommonServices
{
    public class CrashReportService : ICrashReportService
    {
        public async Task ReportException(Exception exception)
        {
            Debug.WriteLine(exception);
        }
    }
}
