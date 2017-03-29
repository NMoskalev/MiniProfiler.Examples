using System.Web.Mvc;

namespace MiniProfile.Examples.Helpers
{
    public static class HtmlHelperExtentions
    {
        public static bool HideUncaughtJsExceptions(this HtmlHelper htmlHelper)
        {
#if DEBUG
            return false;
#else
            return true;
#endif
        }

        public static bool IsProfiler(this HtmlHelper htmlHelper)
        {
#if PROFILER
            return true;
#else
            return false;
#endif
        }
    }
}