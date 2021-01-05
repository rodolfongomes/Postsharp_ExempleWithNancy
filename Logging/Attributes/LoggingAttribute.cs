using System;
using System.Collections.Generic;
using System.Text;
using PostSharp.Aspects;
using PostSharp.Serialization;
using Serilog;
using Serilog.Context;
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
            Log.Information("Entering ...");
            Log.CloseAndFlush();
        }
        public override void OnException(MethodExecutionArgs args)
        {
            ConfigureLog();
            Log.Error(args.Exception.Message);
            Log.CloseAndFlush();
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ConfigureLog();
            Log.Information("successfully completed");
            Log.CloseAndFlush();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ConfigureLog();
            Log.Information("successfully exited");
            Log.CloseAndFlush();
        }
    }
}
