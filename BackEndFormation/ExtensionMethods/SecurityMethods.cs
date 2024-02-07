namespace BackEndFormation.ExtensionMethods
{
    /// <summary>
    /// About security (cors, jwt)
    /// </summary>
    public static class SecurityMethods
    {
        #region Constants
        public const string DEFAULT_POLICY = "DEFAULT_POLICY";
        #endregion
        #region public methods
        /// <summary>
        /// Add cors and jwt configuration
        /// </summary>
        /// <param name="services"></param>
        public static void AddCustomSecurity(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(DEFAULT_POLICY, builder =>
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    builder.WithOrigins(configuration["Cors:Policy:Origin"])
                           .AllowAnyHeader()
                           .AllowAnyMethod();
#pragma warning restore CS8604 // Possible null reference argument.
                });
            });
        }
        #endregion
    }
}
