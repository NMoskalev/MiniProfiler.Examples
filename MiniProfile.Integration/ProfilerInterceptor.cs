using Castle.DynamicProxy;
using StackExchange.Profiling;

namespace MiniProfile.Integration
{
    public class ProfilerInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var profiler = MiniProfiler.Current;

            var methodName = invocation.Method.Name;
            var type = invocation.TargetType.Name;
            using (profiler.Step(string.Format("{0}:{1}", type, methodName)))
            {
                invocation.Proceed();
            }
        }
    }
}
