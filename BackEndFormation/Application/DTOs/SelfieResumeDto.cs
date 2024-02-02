namespace BackEndFormation.Application.DTOs
{
    public class SelfieResumeDto
    {
        #region properties
        public int NbSelfiesFromWookie { get; set; }
        public required string Title { get; set; }
        public required int WookieId { get; set; }
        #endregion
    }
}
