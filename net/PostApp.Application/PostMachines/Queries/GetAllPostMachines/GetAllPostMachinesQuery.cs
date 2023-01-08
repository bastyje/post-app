using AutoMapper;
using MediatR;
using PostApp.Application.Common.Interfaces;
using PostApp.Application.Common.Models;

namespace PostApp.Application.PostMachines.Queries.GetAllPostMachines;

public class GetAllPostMachinesQuery : IRequest<ServiceMessage<GetAllPostMachinesListModel>>
{
    public PaginationRequest PaginationRequest { get; }

    public GetAllPostMachinesQuery(PaginationRequest paginationRequest)
    {
        PaginationRequest = paginationRequest;
    }
}

public class GetAllPostMachinesQueryHandler : IRequestHandler<GetAllPostMachinesQuery, ServiceMessage<GetAllPostMachinesListModel>>
{
    private readonly IPostMachineRepository _postMachineRepository;
    private readonly IMapper _mapper;

    public GetAllPostMachinesQueryHandler(IPostMachineRepository postMachineRepository, IMapper mapper)
    {
        _postMachineRepository = postMachineRepository;
        _mapper = mapper;
    }

    public async Task<ServiceMessage<GetAllPostMachinesListModel>> Handle(GetAllPostMachinesQuery request, CancellationToken cancellationToken)
    {
        var serviceMessage = new ServiceMessage<GetAllPostMachinesListModel>
        {
            Content = new GetAllPostMachinesListModel
            {
                PostMachines = _mapper.Map<PaginationResponse<GetAllPostMachinesModel>>(await _postMachineRepository.GetPaged(request.PaginationRequest, cancellationToken))
            }
        };

        return serviceMessage;
    }
}