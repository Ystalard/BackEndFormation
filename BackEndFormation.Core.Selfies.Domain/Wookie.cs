using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndFormation.Core.Selfies.Domain
{
    public  class Wookie
    {
        #region proertiers
        public int Id { get; set; }
        public List<Selfie>? Selfies { get; set; }
        #endregion
    }
}
