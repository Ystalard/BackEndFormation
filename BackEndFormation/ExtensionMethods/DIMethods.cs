using BackEndFormation.Core.Selfies.Domain;
using BackEndFormation.Core.Selfies.Infrastructures.Repositories;
using BanckEndFormation.Core.Selfies.Infrastructures.Data;

namespace BackEndFormation.ExtensionMethods
{
    public static class DIMethods
    {
        #region Public methods
        /// <summary>
        /// Prepare customs dependency injections
        /// </summary>
        /// <param name="builder"></param>
        public static void AddInjections(this IServiceCollection services)
        {
            services.AddScoped<ISelfieRepository, DefaultSelfieRepository>();
        }
        #endregion
    }
}
