﻿using BackEndFormation.Application.DTOs;
using BackEndFormation.Core.Selfies.Infrastructures.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEndFormation.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        #region Fields
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SecurityOptions _options;
        #endregion

        #region Constructors
        public AuthenticateController(UserManager<IdentityUser> userManager, IConfiguration configuration, IOptions<SecurityOptions> options)
        {
            _userManager = userManager;
            _configuration = configuration;
            _options = options.Value;
        }
        #endregion

        #region public methods
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] AuthenticateUserDTo dtoUser)
        {
            IActionResult result = BadRequest();
            IdentityUser user = new()
            {
                UserName = dtoUser.Name,
                Email = dtoUser.Login
            };

            if(dtoUser.Password == null)
            {
                return result;
            }

            IdentityResult identityResult = await _userManager.CreateAsync(user, dtoUser.Password);
            
            if(identityResult.Succeeded)
            {
                dtoUser.Token = GenerateJwtToken(user);
                result = Ok(dtoUser);
            }

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthenticateUserDTo dtoUser)
        {
            IActionResult result = this.BadRequest();

            IdentityUser? user = await _userManager.FindByEmailAsync(dtoUser.Login);
            if(user != null && dtoUser.Password != null)
            {
                bool verif = await _userManager.CheckPasswordAsync(user, dtoUser.Password);
                if(verif && user.Email != null)
                {
                    result = Ok(new AuthenticateUserDTo()
                    {
                        Login = user.Email,
                        Name = user.UserName,
                        Token = GenerateJwtToken(user)
                    });
                }
            }
            return result;
        }
        #endregion

        #region Internal methods
        private string GenerateJwtToken(IdentityUser user)
        {
            // Now its ime to define the jwt token which will be responsible of creating our tokens
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            // We get our secret from the appsettings
#pragma warning disable CS8604 // Possible null reference argument.
            var key = Encoding.UTF8.GetBytes(_options.Key);
#pragma warning restore CS8604 // Possible null reference argument.

            // we define our token descriptor
            // We need to utilise claims which are properties in our token which gives information about the token
            // which belong to the specific user who it belongs to
            // so it could contain their id, name, email the good part is that these information
            // are generated by our server and identity framework which is valid and trusted
#pragma warning disable CS8604 // Possible null reference argument.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                // the JTI is used for our refresh token which we will be convering in the next video
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
                // the life span of the token needs to be shorter and utilise refresh token to keep the user signedin
                // but since this is a demo app we can extend it to fit our current need
                Expires = DateTime.UtcNow.AddHours(6),
                // here we are adding the encryption alogorithim information which will be used to decrypt our token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
#pragma warning restore CS8604 // Possible null reference argument.

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
        #endregion
    }
}
