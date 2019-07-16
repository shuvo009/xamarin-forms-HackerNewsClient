using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HackerNewsClient.Core.Interface
{
    public interface ICrashReportService
    {
        Task ReportException(Exception exception);
    }
}
