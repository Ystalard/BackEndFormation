using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackEndFormation.Core.Selfies.Domain
{
    public class Picture
    {
        #region properties
        public int Id { get; set; }
        public required string Url { get; set; }
        public List<Selfie> Selfies { get; set; } = new List<Selfie>();
        #endregion
    }
}
