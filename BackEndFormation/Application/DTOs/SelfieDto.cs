using BackEndFormation.Core.Selfies.Domain;

namespace BackEndFormation.Application.DTOs
{
    public class SelfieDto
    {
        #region properties
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string ImagePath { get; set; }
        public required Wookie Wookie { get; set; }
        public string? Description { get; set; }
        #endregion
    }
}
