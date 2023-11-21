using AutoMapper;
using MediatR;
using Repository.Infrastructure;

namespace Application.Infrastructure;

public abstract class 
    Command<TRequest> : RepositoryMapperProvider, IRequestHandler<TRequest, Response>
    where TRequest : IRequest<Response>
{
    protected Command(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public abstract Task<Response> Handle(TRequest request, CancellationToken cancellationToken);
}