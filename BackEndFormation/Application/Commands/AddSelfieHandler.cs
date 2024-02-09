using BackEndFormation.Application.DTOs;
using BackEndFormation.Core.FrameWork;
using BackEndFormation.Core.Selfies.Domain;
using MediatR;

namespace BackEndFormation.Application.Commands
{
    /// <summary>
    /// Command to add a selfie on DB
    /// </summary>
    public class AddSelfieHandler(ISelfieRepository repository) : IRequestHandler<AddSelfieCommand, SelfieDto>
    {
        #region Fields
        private readonly ISelfieRepository _repository = repository;
        #endregion

        #region public methods
        public Task<SelfieDto> Handle(AddSelfieCommand request, CancellationToken cancellationToken)
        {
            Selfie AddedSelfie = this._repository.AddOne(new Selfie
            {
                Title = request.Selfie.Title,
                ImagePath = request.Selfie.ImagePath,
                Wookie = request.Selfie.Wookie,
                Description = request.Selfie.Description
            });

            _repository.UnitOfWork.SaveChanges();

            if (AddedSelfie != null)
            {
                request.Selfie.Id = AddedSelfie.Id;
            }

            return Task.FromResult(request.Selfie);
        }
        #endregion
    }
}
