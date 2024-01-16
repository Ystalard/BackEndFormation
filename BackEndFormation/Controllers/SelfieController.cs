using BackEndFormation.Core.Selfies.Domain;
using BanckEndFormation.Core.Selfies.Infrastructures.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndFormation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelfieController : ControllerBase
    {
        #region Fields
        private readonly SelfiesContext? _context = null;
        #endregion
        #region Constructor
        public SelfieController(SelfiesContext context) => this._context = context;
        #endregion

        #region public methods
        [HttpGet]
        public IActionResult Get()
        {
            var query = from Wookie in this._context?.Selfies
                        select Wookie;
            return this.Ok(query.ToList());
        }
        #endregion
    }

    
}
