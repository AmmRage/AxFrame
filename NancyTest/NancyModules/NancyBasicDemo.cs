using System.IO;
using System.Linq;
using Nancy;

namespace NancyTest
{
    public class NancyBasicDemo : NancyModule
    {
        public static void EnableOptionalRoute()
        {
            OptionalRoute = true;
        }

        private static bool OptionalRoute;

        public NancyBasicDemo() //: base("error")
        {
            //this.Post["/"] = _ => "Received POST request";
            this.Get["/"] = ActiveX;
            //this.Get["/a"] = ActiveX;

            //Get["/p"] = parameters =>
            //{
            //    return View["products.html", MyModel.Query()];
            //};

            //this.Get["/(?<age>[.]{0,})"] = ResponseAny;

            //Get[@"/(?<num>[\d]{8})"] = parameters => "regex: " + parameters.num;

            //Get["/a"] = GetJobStat;

            //if (OptionalRoute)
            //    Get["/o"] = _ => "OptionalRoute set true";
        }

        private dynamic GetJobStat(dynamic parameters)
        {
            return "regex: " + parameters.date;
        }

        private dynamic ResponseAny(dynamic parameters)
        {
            return this.Request.Url.Path;
        }
        private dynamic ActiveX(dynamic parameters)
        {
            return View["ax.html"];
            return File.ReadAllText(@"ax.html");
        }
    }
}