using System.Reflection;

namespace NominaCheck.Data.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddAllServicesAvailable(this IServiceCollection services, string @namespace = "NominaCheck.Data.Services")
        {
            List<Type> serviceClassList = Assembly.GetExecutingAssembly().GetTypes().Where(t => !t.IsAbstract && t.IsClass && t.Namespace == @namespace && t.Name.EndsWith("Services")).ToList();
            foreach (Type service in serviceClassList)
            {
                services.AddTransient(service);
            }
        }
    }
}
