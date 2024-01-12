namespace BackEndFormation.Core.Selfies.Domain
{
    public class Selfie
    {
        #region public properties
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ImagePath { get; set; }
        public Wookie? Wookie { get; set; }
        #endregion
    }
}
