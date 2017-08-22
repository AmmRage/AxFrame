using System.IO;
using System.Linq;
using Nancy;

namespace NancyTest
{
    public class StatusCodesModule : NancyModule
    {
        public StatusCodesModule()
            : base("error")
        {
            //Get["/add/{code}"] = x =>
            //{
            //    CustomStatusCode.AddCode(x.code);
            //    return "done";
            //};
            //Get["/remove/{code}"] = x =>
            //{
            //    CustomStatusCode.RemoveCode(x.code);
            //    return "done";
            //};
        }
    }
}