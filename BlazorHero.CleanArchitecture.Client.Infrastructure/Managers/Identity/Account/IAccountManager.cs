﻿using System.Threading.Tasks;
using BlazorHero.CleanArchitecture.Application.Requests.Identity;
using BlazorHero.CleanArchitecture.Shared.Wrapper;

namespace BlazorHero.CleanArchitecture.Client.Infrastructure.Managers.Identity.Account
{
	public interface IAccountManager : IManager
	{
		Task<IResult> ChangePasswordAsync(ChangePasswordRequest model);

		Task<IResult> UpdateProfileAsync(UpdateProfileRequest model);

		Task<IResult<string>> GetProfilePictureAsync(string userId);

		Task<IResult> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
	}
}