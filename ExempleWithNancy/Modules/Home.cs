using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ExempleWithNancy.Modules
{
    public class Home : NancyModule
    {
        public Home()
        {
            Get("/", _ => "Hello World!!");
        }
    }
}
