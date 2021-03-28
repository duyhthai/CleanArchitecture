using System.Threading.Tasks;
using BlazorHero.CleanArchitecture.Client.Infrastructure.Settings;
using MudBlazor;

namespace BlazorHero.CleanArchitecture.Client.Infrastructure.Managers.Preferences
{
	public interface IPreferenceManager
	{
		Task SetPreference(Preference preference);

		Task<Preference> GetPreference();

		Task<MudTheme> GetCurrentThemeAsync();

		Task<bool> ToggleDarkModeAsync();

		Task ChangeLanguageAsync(string languageCode);
	}
}