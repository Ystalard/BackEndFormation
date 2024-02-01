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
        #region Constructors
        public DefaultSelfieRepository(SelfiesContext context)
        {
            _context = context;
        }
        #endregion
        #region public methods
        public ICollection<Selfie> GetAll()
        {
            return _context.Selfies.Include(item => item.Wookie).ToList();
        }
        #endregion
    }
}
