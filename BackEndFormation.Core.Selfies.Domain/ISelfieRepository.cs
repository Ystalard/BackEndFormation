using BackEndFormation.Core.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndFormation.Core.Selfies.Domain
{
    /// <summary>
    /// Repository to manage selfies
    /// </summary>
    public interface ISelfieRepository: IRepository
    {
        /// <summary>
        /// Get all the selfies
        /// </summary>
        /// <returns></returns>
        ICollection<Selfie> GetAll();

        /// <summary>
        /// Adds one selfie in DB
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Selfie AddOne(Selfie item);
    }
}
