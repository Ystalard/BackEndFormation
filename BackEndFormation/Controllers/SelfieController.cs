using BackEndFormation.Core.Selfies.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndFormation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelfieController : ControllerBase
    {
        #region public methods
        [HttpGet]
        public IActionResult Get()
        {
            var model = Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });

            return this.NotFound(model);
        }
        #endregion
    }

    
}
