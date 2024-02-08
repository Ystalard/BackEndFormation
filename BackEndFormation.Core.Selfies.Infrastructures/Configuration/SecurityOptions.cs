using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndFormation.Core.Selfies.Infrastructures.Configuration
{
    /// <summary>
    /// Getting data to use in security config
    /// </summary>
    public class SecurityOptions
    {
        #region Properties
        public string? Key { get; set; }
        #endregion
    }
}
