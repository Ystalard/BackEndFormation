using BackEndFormation.Application.DTOs;
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
            var model = selfiesList.Select(item => new SelfieResumeDto() { Title = item.Title, WookieId = item.Wookie.Id, NbSelfiesFromWookie = item.Wookie.Selfies.Count }).ToList();
            return this.Ok(model);
        }

        [HttpPost]
        public IActionResult AddOne(SelfieDto selfieDto)
        {
            IActionResult result = this.BadRequest();
            Selfie AddedSelfie = this._repository.AddOne(new Selfie
            {
                Title = selfieDto.Title,
                ImagePath = selfieDto.ImagePath,
                Wookie = selfieDto.Wookie
            });

            _repository.UnitOfWork.SaveChanges();

            if(AddedSelfie != null)
            {
                selfieDto.Id = AddedSelfie.Id;
                result = this.Ok(selfieDto);
            }

            return result;
        }
        #endregion
    }

    
}
