using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazorHero.CleanArchitecture.Client.Pages.Content
{
	public partial class Dashboard
	{
		[Parameter]
		public int ProductCount { get; set; }
		[Parameter]
		public int BrandCount { get; set; }
		[Parameter]
		public int UserCount { get; set; }
		[Parameter]
		public int RoleCount { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await LoadDataAsync();
		}

		private async Task LoadDataAsync()
		{
			var data = await _dashboardManager.GetDataAsync();
			if (data.Succeeded)
			{
				ProductCount = data.Data.ProductCount;
				BrandCount = data.Data.BrandCount;
				UserCount = data.Data.UserCount;
				RoleCount = data.Data.RoleCount;
			}
		}
	}
}
