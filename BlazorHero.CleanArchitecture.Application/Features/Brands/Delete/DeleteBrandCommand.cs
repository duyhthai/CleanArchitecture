using BlazorHero.CleanArchitecture.Application.Interfaces.Repositories;
using BlazorHero.CleanArchitecture.Domain.Entities.Catalog;
using BlazorHero.CleanArchitecture.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorHero.CleanArchitecture.Application.Features.Brands.Delete
{
    public class DeleteBrandCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteBrandCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteBrandCommand command, CancellationToken cancellationToken)
            {
                var isBrandUsed = await _unitOfWork.Repository<Product>()
                    .Entities.Where(p => p.BrandId == command.Id).AnyAsync();

                if (!isBrandUsed)
                {
                    var brand = await _unitOfWork.Repository<Brand>().GetByIdAsync(command.Id);
                    await _unitOfWork.Repository<Brand>().DeleteAsync(brand);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(brand.Id, "Brand Deleted");
                }
                else
                {
                    return Result<int>.Fail("Brand is still in use.");
                }
            }
        }
    }
}