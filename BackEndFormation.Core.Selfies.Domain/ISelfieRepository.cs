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
        ICollection<Selfie> GetAll(int? wookieId);

        /// <summary>
        /// Adds one selfie in DB
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Selfie AddOne(Selfie item);

        /// <summary>
        /// Add one picture in DB
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Picture AddOnePicture(string url);
    }
}
