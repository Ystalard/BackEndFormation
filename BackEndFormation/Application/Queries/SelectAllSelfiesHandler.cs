using BackEndFormation.Application.DTOs;
using BackEndFormation.Core.Selfies.Domain;
using MediatR;

namespace BackEndFormation.Application.Queries
{
    /// <summary>
    /// Query to select all selfies with dto class
    /// </summary>
    public class SelectAllSelfiesHandler(ISelfieRepository repository) : IRequestHandler<SelectAllSelfiesQuery, List<SelfieResumeDto>>
    {
        #region Fields
        private readonly ISelfieRepository _repository = repository;
        #endregion

        #region public methods
        public Task<List<SelfieResumeDto>> Handle(SelectAllSelfiesQuery request, CancellationToken cancellationToken)
        {

            var selfiesList = this._repository.GetAll(request.WookieId);
            List<SelfieResumeDto> result = selfiesList.Select(item => new SelfieResumeDto() { Title = item.Title, WookieId = item.Wookie.Id, NbSelfiesFromWookie = item.Wookie.Selfies.Count }).ToList();
            return Task.FromResult(result);
        }
        #endregion
    }
}
