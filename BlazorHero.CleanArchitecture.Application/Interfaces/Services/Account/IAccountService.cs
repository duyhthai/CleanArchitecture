﻿using System.Threading.Tasks;
using BlazorHero.CleanArchitecture.Application.Interfaces.Common;
using BlazorHero.CleanArchitecture.Application.Requests.Identity;
using BlazorHero.CleanArchitecture.Shared.Wrapper;

namespace BlazorHero.CleanArchitecture.Application.Interfaces.Services.Account
{
	public interface IAccountService : IService
	{
		Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, string userId);

		Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, string userId);

		Task<IResult<string>> GetProfilePictureAsync(string userId);

		Task<IResult> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
	}
}