using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Util.DI;

namespace Util;
public static class Startup
{
    public static IServiceCollection ResgisterServices(this IServiceCollection services)
    {
        var files = Directory.GetFiles(AppContext.BaseDirectory, "*.dll");
        foreach (var file in files)
        {
            try
            {
                var ass = Assembly.LoadFrom(file);
                
                foreach (var t in ass.GetTypes())
                {
                    if (!t.IsClass)
                        continue;

                    if (t.GetInterface(typeof(IServiceScoped).Name) != null)
                    {
                        if (t.GetInterface("I" + t.Name) is var I && I != null)
                            services.AddScoped(I, t);
                        else
                            services.AddScoped(t);
                    }
                    else if (t.GetInterface(typeof(IServiceSingleton).Name) != null)
                    {
                        if (t.GetInterface("I" + t.Name) is var I && I != null)
                            services.AddSingleton(I, t);
                        else
                            services.AddSingleton(t);
                    }
                    else if (t.GetInterface(typeof(IServiceTransient).Name) != null)
                    {
                        if (t.GetInterface("I" + t.Name) is var I && I != null)
                            services = services.AddTransient(I, t);
                        else
                            services = services.AddTransient(t, t);
                    }
                }
            }
            catch { }
        }

        services.AddHttpContextAccessor();

        return services;
    }
}
