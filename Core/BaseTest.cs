using ReportPortal.Serilog;
using Serilog;

namespace Core
{
    public abstract class BaseTest
    {
        static BaseTest()
        {
            Log.Logger = new LoggerConfiguration()
               .WriteTo.ReportPortal()
               .WriteTo.Console()
               .WriteTo.File("log.txt")
               .CreateLogger();
        }
    }
}

