using BackEndFormation.Application.DTOs;
using BackEndFormation.Core.Selfies.Domain;
using BackEndFormation.Core.Selfies.Infrastructures.Data;
using BackEndFormation.ExtensionMethods;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BackEndFormation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(SecurityMethods.DEFAULT_POLICY)]
    public class SelfieController(ISelfieRepository repository, IWebHostEnvironment webHostEnvironment) : ControllerBase
    {
        #region Fields
        private readonly ISelfieRepository _repository = repository;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        #endregion
        #region Constructor

        #endregion

        #region public methods
        [HttpGet]
        [DisableCors()]
        public IActionResult GetAll([FromQuery] int? wookieId)
        {
            var selfiesList = this._repository.GetAll(wookieId);
            var model = selfiesList.Select(item => new SelfieResumeDto() { Title = item.Title, WookieId = item.Wookie.Id, NbSelfiesFromWookie = item.Wookie.Selfies.Count }).ToList();
            return this.Ok(model);
        }

        [Route("photos")]
        [HttpPost]
        public async Task<IActionResult> AddPicture(IFormFile picture)
        {
            string filePath = Path.Combine(this._webHostEnvironment.ContentRootPath, @"images\selfies");

            if(!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            filePath = Path.Combine(filePath, picture.FileName);
            using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            await picture.CopyToAsync(stream);

            var itemFile = this._repository.AddOnePicture(filePath);
            _repository.UnitOfWork.SaveChanges();
            return this.Ok(itemFile);
        }

        [HttpPost]
        public IActionResult AddOne(SelfieDto selfieDto)
        {
            IActionResult result = this.BadRequest();
            Selfie AddedSelfie = this._repository.AddOne(new Selfie
            {
                Title = selfieDto.Title,
                ImagePath = selfieDto.ImagePath,
                Wookie = selfieDto.Wookie,
                Description = selfieDto.Description
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
