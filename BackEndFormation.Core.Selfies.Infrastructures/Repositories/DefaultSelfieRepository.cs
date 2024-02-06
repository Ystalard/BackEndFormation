using BackEndFormation.Core.FrameWork;
using BackEndFormation.Core.Selfies.Domain;
using BackEndFormation.Core.Selfies.Infrastructures.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndFormation.Core.Selfies.Infrastructures.Repositories
{
    public class DefaultSelfieRepository(SelfiesContext context) : ISelfieRepository
    {
        #region Fields
        private readonly SelfiesContext _context = context;
        #endregion

        #region Properties
        public IUnitOfWork UnitOfWork => _context;

        #endregion

        #region public methods
        public ICollection<Selfie> GetAll(int? wookieId)
        {
            return _context.Selfies.Include(item => item.Wookie).Where(item => !wookieId.HasValue || item.Wookie.Id == wookieId.Value).ToList();
        }

        public Selfie AddOne(Selfie item)
        {
            return this._context.Selfies.Add(item).Entity;
        }

        public Picture AddOnePicture(string url)
        {
            return this._context.Pictures.Add(new Picture()
            {
                Url = url
            }).Entity;
        }
        #endregion
    }
}
