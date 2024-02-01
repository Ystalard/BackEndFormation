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
        private readonly ISelfieRepository _repository;
        #endregion
        #region Constructor
        public SelfieController(ISelfieRepository repository) => _repository = repository;

        #endregion

        #region public methods
        [HttpGet]
        public IActionResult Get()
        {
            var selfiesList = this._repository.GetAll();
            var model = selfiesList.Select(item => new { item.Title, WookieId = item.Wookie.Id, NbSelfiesFromWookie = item.Wookie.Selfies.Count }).ToList();
            return this.Ok(model);
        }
        #endregion
    }

    
}
