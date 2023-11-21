using Application.Common;
using Application.Infrastructure;
using AutoMapper;
using Repository.Infrastructure;

namespace Application.Product.Command.AddProduct;

public class AddProductService : Command<AddProductRequest>
{
    public AddProductService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public override async Task<Response> Handle(AddProductRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // UnitOfWork.CreateTransaction();
            var product = Mapper.Map<Domain.Product>(request);
            await UnitOfWork.ProductRepository.Insert(product);
            await UnitOfWork.Save();
            // UnitOfWork.Commit();
            return new Response();
        }
        catch (Exception e)
        {
            // UnitOfWork.Rollback();
            Console.WriteLine(e);
            return new Response(IsSuccess: false, Message: e.Message);
        }
    }
}