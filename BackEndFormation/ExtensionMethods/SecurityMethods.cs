namespace BackEndFormation.ExtensionMethods
{
    /// <summary>
    /// About security (cors, jwt)
    /// </summary>
    public static class SecurityMethods
    {
        #region Constants
        public const string DEFAULT_POLICY = "DEFAULT_POLICY";
        public const string DEFAULT_POLICY2 = "DEFAULT_POLICY2";
        public const string DEFAULT_POLICY3 = "DEFAULT_POLICY3";
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
                
                options.AddPolicy(DEFAULT_POLICY2, builder =>
                {
                    builder.WithOrigins("http://127.0.0.1:5501")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
                options.AddPolicy(DEFAULT_POLICY3, builder =>
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
