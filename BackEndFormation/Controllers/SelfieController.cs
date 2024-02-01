using BackEndFormation.Core.Selfies.Domain;
using BanckEndFormation.Core.Selfies.Infrastructures.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BackEndFormation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelfieController : ControllerBase
    {
        #region Fields
        private readonly SelfiesContext _context;
        #endregion
        #region Constructor
        public SelfieController(SelfiesContext context) => this._context = context;
        #endregion

        #region public methods
        [HttpGet]
        public IActionResult Get()
        {
            var model = this._context.Selfies.Include(item => item.Wookie).ToList();
            return this.Ok(model);
        }
        #endregion
    }

    
}
