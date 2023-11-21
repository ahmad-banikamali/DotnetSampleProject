using AutoMapper;
using Repository.Infrastructure;

namespace Application.Infrastructure;

public class RepositoryMapperProvider
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }

    protected RepositoryMapperProvider(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }
}