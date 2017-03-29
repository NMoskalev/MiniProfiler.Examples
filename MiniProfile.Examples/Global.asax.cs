using StackExchange.Profiling;
using StackExchange.Profiling.Mvc;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Linq;

namespace MiniProfile.Examples
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();


#if PROFILER
            GlobalFilters.Filters.Add(new ProfilingActionFilter());

            var copy = ViewEngines.Engines.ToList();
            ViewEngines.Engines.Clear();
            foreach (var item in copy)
            {
                ViewEngines.Engines.Add(new ProfilingViewEngine(item));
            }

            MiniProfiler.Settings.Results_List_Authorize = IsUserAllowedToSeeMiniProfilerUI;
            MiniProfiler.Settings.Results_Authorize = IsUserAllowedToSeeMiniProfilerUI;
            MiniProfiler.Settings.IgnoredPaths = new[]
            {
                "/JavaScriptLibraries/",
                "/signalr/",
                "/api/filter/",
                "/favicon.ico",
                "/bower_components/",
                "/Content/",
                "/bundles/",
                "/Util/",
                ".png"
            };
#endif

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

#if PROFILER
        protected void Application_BeginRequest()
        {
            MiniProfiler.Start();
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }

        private bool IsUserAllowedToSeeMiniProfilerUI(HttpRequest httpRequest)
        {
            return true;
        }
#endif
    }
}
