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
            .WriteTo.MongoDB("mongodb://root:example@mongo:27017/Serilog", collectionName: "LogAPIExempleWithNancy")
            .CreateLogger();
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            ConfigureLog();
            Log.Information(string.Format("Entering on method {0}.{1}...", args.Method.DeclaringType.Name, args.Method.Name));
            Log.CloseAndFlush();
            args.FlowBehavior = FlowBehavior.Continue;
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
            Log.Information(string.Format("successfully completed method {0}.{1}", args.Method.DeclaringType.Name, args.Method.Name));
            Log.CloseAndFlush();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ConfigureLog();
            Log.Information(string.Format("successfully exited method {0}.{1}", args.Method.DeclaringType.Name, args.Method.Name));
            Log.CloseAndFlush();
        }
    }
}
