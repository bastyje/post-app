using AutoMapper;
using MediatR;
using PostApp.Application.Common.Interfaces;
using PostApp.Application.Common.Models;
using PostApp.Domain.Entities;

namespace PostApp.Application.Users.Queries.GetUserByNamePattern;

public class GetUserByNamePatternQuery : IRequest<ServiceMessage<GetUserByNamePatternListModel>>
{
    public string Pattern { get; }

    public GetUserByNamePatternQuery(string pattern)
    {
        Pattern = pattern;
    }
}

public class GetUserByNamePatternQueryHandler : IRequestHandler<GetUserByNamePatternQuery, ServiceMessage<GetUserByNamePatternListModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserByNamePatternQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public Task<ServiceMessage<GetUserByNamePatternListModel>> Handle(GetUserByNamePatternQuery request, CancellationToken cancellationToken)
    {
        var result = _userRepository.GetFiltered(u =>
            u.Id.Contains(request.Pattern, StringComparison.CurrentCultureIgnoreCase)
            || u.FirstName.Contains(request.Pattern, StringComparison.CurrentCultureIgnoreCase)
            || u.LastName.Contains(request.Pattern, StringComparison.CurrentCultureIgnoreCase))
            .Take(5);
        
        var serviceMessage = new ServiceMessage<GetUserByNamePatternListModel>
        {
            Content = new GetUserByNamePatternListModel
            {
                Users = result.Select(r => _mapper.Map<GetUserByNamePatternModel>(r)).ToList()
            }
        };
        
        return Task.FromResult(serviceMessage);
    }
}