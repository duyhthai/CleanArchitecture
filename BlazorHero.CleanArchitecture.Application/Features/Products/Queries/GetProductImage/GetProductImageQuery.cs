﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorHero.CleanArchitecture.Application.Interfaces.Repositories;
using BlazorHero.CleanArchitecture.Domain.Entities.Catalog;
using BlazorHero.CleanArchitecture.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorHero.CleanArchitecture.Application.Features.Products.Queries.GetProductImage
{
	public class GetProductImageQuery : IRequest<Result<string>>
	{
		public int Id { get; set; }

		public GetProductImageQuery(int productId)
		{
			Id = productId;
		}
	}

	public class GetProductImageQueryHandler : IRequestHandler<GetProductImageQuery, Result<string>>
	{
		private readonly IUnitOfWork _unitOfWork;

		public GetProductImageQueryHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Result<string>> Handle(GetProductImageQuery request, CancellationToken cancellationToken)
		{
			var data = await _unitOfWork.Repository<Product>().Entities.Where(p => p.Id == request.Id).Select(a => a.ImageDataURL).FirstOrDefaultAsync();
			return Result<string>.Success(data: data);
		}
	}
}