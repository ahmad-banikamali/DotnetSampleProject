using AutoMapper;
using MediatR;
using Repository.Infrastructure;

namespace Application.Infrastructure;

public abstract class Query<TRequest, TResponse> : RepositoryMapperProvider,
    IRequestHandler<TRequest, Response<TResponse>>  where TRequest : IRequest<Response<TResponse>>
{ 

    protected Query(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    { 
    }

    public abstract Task<Response<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);
}