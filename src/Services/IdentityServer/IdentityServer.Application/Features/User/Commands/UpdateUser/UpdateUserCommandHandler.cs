namespace IdentityServer.Application.Features.User.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateUserCommandHandler> _logger;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateUserCommandHandler> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        ApplicationUser applicationUser = await _unitOfWork.Users.GetByIdAsync(request.Id);
        if (applicationUser == null)
        {                
            throw new KeyNotFoundException(nameof(ApplicationUser));
        }

        ApplicationUser updatedItem = _mapper.Map(request, applicationUser);

        await _unitOfWork.Users.UpdateAsync(updatedItem);
        
        _logger.LogInformation(Constants.Logs.UserUpdated, applicationUser.Name);

        return Unit.Value;
    }
}