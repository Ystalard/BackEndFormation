using BackEndFormation.Core.Selfies.Infrastructures.Configuration;

namespace BackEndFormation.ExtensionMethods
{
    /// <summary>
    /// Custom options from the configuration file
    /// </summary>
    public static class optionsMethods
    {
        #region public methods
        /// <summary>
        /// Add cors and jwt configuration
        ///     
        public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SecurityOptions>(configuration.GetSection("Jwt"));
        }
        #endregion
    }
}
