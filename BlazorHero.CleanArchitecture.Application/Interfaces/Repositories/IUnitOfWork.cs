using System;
using System.Threading;
using System.Threading.Tasks;
using BlazorHero.CleanArchitecture.Domain.Contracts;

namespace BlazorHero.CleanArchitecture.Application.Interfaces.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		IRepositoryAsync<T> Repository<T>() where T : AuditableEntity;

		Task<int> Commit(CancellationToken cancellationToken);

		Task Rollback();
	}
}