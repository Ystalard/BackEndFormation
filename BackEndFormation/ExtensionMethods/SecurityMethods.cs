﻿using BackEndFormation.Core.Selfies.Domain;
using BackEndFormation.Core.Selfies.Infrastructures.Configuration;
using BackEndFormation.Core.Selfies.Infrastructures.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

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
        public static IServiceCollection AddCustomSecurity(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddCustomCors(configuration);
            services.AddCustomAuthentication(configuration);

            return services;
        }

        public static void AddCustomAuthentication(this IServiceCollection services, IConfigurationManager configuration)
        {
            SecurityOptions securityOption = new();
            configuration.GetSection("Jwt").Bind(securityOption);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
                string myKey = securityOption.Key;
                options.SaveToken = true;

                options.TokenValidationParameters = new()
                {
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(myKey)),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateActor = false,
                    ValidateLifetime = true
                };
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            });

        }

        public static void AddCustomCors(this IServiceCollection services, IConfigurationManager configuration)
        {
            CorsOptions.Policy policy = new();
            configuration.GetSection("Cors:Policy").Bind(policy);


            services.AddCors(options =>
            {
                options.AddPolicy(DEFAULT_POLICY, builder =>
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    builder.WithOrigins(policy.Origin)
                           .AllowAnyHeader()
                           .AllowAnyMethod();
#pragma warning restore CS8604 // Possible null reference argument.
                });
            });
        }
        #endregion
    }
}
