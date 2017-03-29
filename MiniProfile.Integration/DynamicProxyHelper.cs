using Castle.DynamicProxy;
using System;

namespace MiniProfile.Integration
{
    public class DynamicProxyHelper
    {
        private static readonly Lazy<ProxyGenerator> proxy = new Lazy<ProxyGenerator>(() => new ProxyGenerator());
        public static TInterface CreateInterfaceProxyWithTargetInterface<TInterface>(TInterface concreteObject) where TInterface : class
        {
#if PROFILER
            try
            {
                var result = proxy.Value.CreateInterfaceProxyWithTarget(concreteObject, new[] { new ProfilerInterceptor() });

                return result;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                return concreteObject;
            }
#else
            return concreteObject;
#endif
        }
    }
}
