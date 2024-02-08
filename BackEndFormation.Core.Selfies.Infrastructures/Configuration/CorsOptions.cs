using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndFormation.Core.Selfies.Infrastructures.Configuration
{
    /// <summary>
    /// Options to configure cors security
    /// </summary>
    public class CorsOptions
    {
         public class Policy
        {
            public string? Origin { get; set; }
        }
    }
}
