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
        public static void AddCustomSecurity(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(DEFAULT_POLICY, builder =>
                {
                    builder.WithOrigins("http://127.0.0.1:5500")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }
        #endregion
    }
}
