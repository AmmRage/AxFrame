using System.Configuration;
using System.Linq;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace NancyTest
{

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            CustomStatusCode.AddCode(404);
            //CustomStatusCode.AddCode(ConfigurationManager.AppSettings["HttpErrorCodes"].Split(',').Select(x => int.Parse(x)));
            base.ApplicationStartup(container, pipelines);
        }
    }
}