using AutoMapper;
using MediatR;
using PostApp.Application.Common.Interfaces;
using PostApp.Application.Common.Models;
using PostApp.Domain.Dictionaries;

namespace PostApp.Application.Dictionaries.Queries.GetStatusList;

public class GetStatusListQuery : IRequest<ServiceMessage<GetStatusListModel>> {}

public class GetStatusListQueryHandler : IRequestHandler<GetStatusListQuery, ServiceMessage<GetStatusListModel>>
{
    private readonly IDictionaryRepository _dictionaryRepository;
    private readonly IMapper _mapper;

    public GetStatusListQueryHandler(IDictionaryRepository dictionaryRepository, IMapper mapper)
    {
        _dictionaryRepository = dictionaryRepository;
        _mapper = mapper;
    }
    
    public async Task<ServiceMessage<GetStatusListModel>> Handle(GetStatusListQuery request, CancellationToken cancellationToken)
    {
        var serviceMessage = new ServiceMessage<GetStatusListModel>();
        serviceMessage.Content.Statuses = _dictionaryRepository
            .GetDictionary<Status>()
            .Select(d => _mapper.Map<GetStatusModel>(d))
            .ToList();
        return serviceMessage;
    }
}