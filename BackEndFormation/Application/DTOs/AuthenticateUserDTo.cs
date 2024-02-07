namespace BackEndFormation.Application.DTOs
{
    public class AuthenticateUserDTo
    {
        #region properties
        public required string Login { get; set; }
        public string? Password { get; set; }

        public string? Name { get; set; }
        public string? Token { get; set; }
        #endregion
    }
}
