using AutoMapper;
using MediatR;
using PostApp.Application.Common.Enums;
using PostApp.Application.Common.Interfaces;
using PostApp.Application.Common.Models;

namespace PostApp.Application.PostMachines.Queries.GetPostMachine;

public class GetPostMachineQuery : IRequest<ServiceMessage<GetPostMachineModel>>
{
    public int PostMachineId { get; set; }

    public GetPostMachineQuery(int postMachineId)
    {
        PostMachineId = postMachineId;
    }
}

public class GetAllPostMachinesQueryHandler : IRequestHandler<GetPostMachineQuery, ServiceMessage<GetPostMachineModel>>
{
    private readonly IPostMachineRepository _postMachineRepository;
    private readonly IMapper _mapper;

    public GetAllPostMachinesQueryHandler(IPostMachineRepository postMachineRepository, IMapper mapper)
    {
        _postMachineRepository = postMachineRepository;
        _mapper = mapper;
    }

    public async Task<ServiceMessage<GetPostMachineModel>> Handle(GetPostMachineQuery request, CancellationToken cancellationToken)
    {
        var serviceMessage = new ServiceMessage<GetPostMachineModel>();
        var result = await _postMachineRepository.GetAsync(request.PostMachineId, cancellationToken);
        serviceMessage.Content = _mapper.Map<GetPostMachineModel>(result);

        return serviceMessage;
    }
}