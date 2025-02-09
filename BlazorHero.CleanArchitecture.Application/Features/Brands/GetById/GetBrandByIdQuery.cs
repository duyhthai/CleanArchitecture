﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlazorHero.CleanArchitecture.Application.Interfaces.Repositories;
using BlazorHero.CleanArchitecture.Domain.Entities.Catalog;
using BlazorHero.CleanArchitecture.Shared.Wrapper;
using MediatR;

namespace BlazorHero.CleanArchitecture.Application.Features.Brands.Queries.GetById
{
	public class GetBrandByIdQuery : IRequest<Result<GetBrandByIdResponse>>
	{
		public int Id { get; set; }

		public class GetProductByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, Result<GetBrandByIdResponse>>
		{
			private readonly IUnitOfWork _unitOfWork;
			private readonly IMapper _mapper;

			public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
			{
				_unitOfWork = unitOfWork;
				_mapper = mapper;
			}

			public async Task<Result<GetBrandByIdResponse>> Handle(GetBrandByIdQuery query, CancellationToken cancellationToken)
			{
				var product = await _unitOfWork.Repository<Brand>().GetByIdAsync(query.Id);
				var mappedProduct = _mapper.Map<GetBrandByIdResponse>(product);
				return Result<GetBrandByIdResponse>.Success(mappedProduct);
			}
		}
	}
}