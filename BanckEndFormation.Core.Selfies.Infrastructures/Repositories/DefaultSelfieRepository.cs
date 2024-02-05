using BackEndFormation.Core.FrameWork;
using BackEndFormation.Core.Selfies.Domain;
using BanckEndFormation.Core.Selfies.Infrastructures.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndFormation.Core.Selfies.Infrastructures.Repositories
{
    public class DefaultSelfieRepository : ISelfieRepository
    {
        #region Fields
        private readonly SelfiesContext _context;
        #endregion

        #region Properties
        public IUnitOfWork UnitOfWork => _context;
        #endregion

        #region Constructors
        public DefaultSelfieRepository(SelfiesContext context)
        {
            _context = context;
        }
        #endregion

        #region public methods
        public ICollection<Selfie> GetAll(int? wookieId)
        {
            return _context.Selfies.Include(item => item.Wookie).Where(item => wookieId.HasValue ? item.Wookie.Id == wookieId.Value : true).ToList();
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
