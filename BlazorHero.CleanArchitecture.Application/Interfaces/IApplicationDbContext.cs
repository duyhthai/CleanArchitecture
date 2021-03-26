using System.Threading;
using System.Threading.Tasks;
using BlazorHero.CleanArchitecture.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;

namespace BlazorHero.CleanArchitecture.Application.Interfaces
{
	public interface IApplicationDbContext
	{
		DbSet<Product> Products { get; set; }
		DbSet<Brand> Brands { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
