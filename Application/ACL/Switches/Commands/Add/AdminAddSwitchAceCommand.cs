using Application.ACL.Switches.Commands.Common;
using Application.Common.Exceptions;
using Application.CurrentUserService.Interfaces;
using Application.DbContext;
using Application.DbContext.Models.ACE.Switch;
using MapsterMapper;
using MediatR;

namespace Application.ACL.Switches.Commands.Add
{
    public class AdminAddSwitchAceCommand : IRequest<int>
    {
        public int SwitchId { get; set; }

        public string GroupId { get; set; }

        public SwitchRightsMask RightsMask { get; set; }


        public class Handler : IRequestHandler<AdminAddSwitchAceCommand, int>
        {
            private readonly ISwitchManagmentDbContext _dbContext;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService _currentUserService;

            public Handler(ISwitchManagmentDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService)
            {
                _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
            }

            public async Task<int> Handle(AdminAddSwitchAceCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    if (!_currentUserService.IsAdmin)
                        throw new AccessDeniedAppException("Add switches ACE can only admins.");

                    var trak = await _dbContext.SwitchesACL.AddAsync(_mapper.Map<AdminAddSwitchAceCommand, SwitchAceEntity>(request), cancellationToken);

                    await _dbContext.SaveChangesAsync(cancellationToken);

                    return trak.Entity.Id;
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (AppException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    throw new AppException("An unknown error occurred while adding the switchAce, see innerException.", e);
                }
            }
        }
    }
}
