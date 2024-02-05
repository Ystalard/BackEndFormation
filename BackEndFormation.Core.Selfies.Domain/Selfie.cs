namespace BackEndFormation.Core.Selfies.Domain
{
    public class Selfie
    {
        #region public properties
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? ImagePath { get; set; }
        public required Wookie Wookie { get; set; }

        public int PicutreId { get; set; }
        public Picture? Picture { get; set; }
        #endregion
    }
}
