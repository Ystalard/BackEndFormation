namespace BackEndFormation.Core.Selfies.Domain
{
    public class Selfie
    {
        #region public properties
        public required int Id { get; set; }
        public required string Title { get; set; }
        public string? ImagePath { get; set; }
        public required Wookie Wookie { get; set; }
        #endregion
    }
}
