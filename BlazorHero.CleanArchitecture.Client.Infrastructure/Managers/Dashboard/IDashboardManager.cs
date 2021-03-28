using System.Threading.Tasks;
using BlazorHero.CleanArchitecture.Application.Features.Dashboard.GetData;
using BlazorHero.CleanArchitecture.Shared.Wrapper;

namespace BlazorHero.CleanArchitecture.Client.Infrastructure.Managers.Dashboard
{
	public interface IDashboardManager : IManager
	{
		Task<IResult<DashboardDataResponse>> GetDataAsync();
	}
}