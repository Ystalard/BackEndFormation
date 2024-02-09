using BackEndFormation.Core.Selfies.Domain;
using BackEndFormation.Core.Selfies.Infrastructures.Repositories;
using System.Reflection;

namespace BackEndFormation.ExtensionMethods
{
    public static class DIMethods
    {
        #region Public methods
        /// <summary>
        /// Prepare customs dependency injections
        /// </summary>
        /// <param name="builder"></param>
        public static IServiceCollection AddInjections(this IServiceCollection services)
        {
            services.AddScoped<ISelfieRepository, DefaultSelfieRepository>();
            // add mediator for CQRS
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
        #endregion
    }
}
