using System.Security.Claims;
using System.Threading.Tasks;
using BlazorHero.CleanArchitecture.Application.Requests.Identity;
using BlazorHero.CleanArchitecture.Shared.Wrapper;

namespace BlazorHero.CleanArchitecture.Client.Infrastructure.Managers.Identity.Authentication
{
	public interface IAuthenticationManager : IManager
	{
		Task<IResult> Login(TokenRequest model);

		Task<IResult> Logout();
		Task<string> RefreshToken();
		Task<string> TryRefreshToken();

		Task<ClaimsPrincipal> CurrentUser();
	}
}