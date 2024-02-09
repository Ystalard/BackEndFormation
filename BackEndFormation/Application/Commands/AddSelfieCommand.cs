using BackEndFormation.Application.DTOs;
using MediatR;

namespace BackEndFormation.Application.Commands
{
    public class AddSelfieCommand(SelfieDto selfie): IRequest<SelfieDto>
    {
        #region Properties
        public SelfieDto Selfie { get; set; } = selfie;
        #endregion
    }
}
