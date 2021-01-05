using System;
using System.Collections.Generic;
using System.Text;
using PostSharp.Aspects;
using PostSharp.Serialization;
using Serilog;
using Serilog.Events;

namespace Logging.Attributes
{
    [PSerializable]
    public class LoggingAttribute : OnMethodBoundaryAspect
    {
        internal void ConfigureLog()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.File(string.Format("LOG/loggger{0}.log", DateTime.Now.ToString("yyyy-MM-dd")), restrictedToMinimumLevel: LogEventLevel.Debug)
            .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug)
            .CreateLogger();
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            ConfigureLog();
            Log.Logger.Information("Entering ...");
        }
        public override void OnException(MethodExecutionArgs args)
        {
            Log.Logger.Error(args.Exception.Message);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            Log.Logger.Information("successfully completed");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Log.Logger.Information("successfully exited");
        }
    }
}
