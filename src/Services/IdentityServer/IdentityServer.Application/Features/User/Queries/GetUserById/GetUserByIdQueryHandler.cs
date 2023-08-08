namespace IdentityServer.Application.Features.User.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ApplicationUserDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ApplicationUserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        ApplicationUser applicationUser = await _unitOfWork.Users.GetByIdAsync(request.Id);
        return _mapper.Map<ApplicationUserDto>(applicationUser);
    }
}