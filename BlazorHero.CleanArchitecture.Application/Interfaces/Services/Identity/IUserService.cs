﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorHero.CleanArchitecture.Application.Interfaces.Common;
using BlazorHero.CleanArchitecture.Application.Requests.Identity;
using BlazorHero.CleanArchitecture.Application.Responses.Identity;
using BlazorHero.CleanArchitecture.Shared.Wrapper;

namespace BlazorHero.CleanArchitecture.Application.Interfaces.Services.Identity
{
	public interface IUserService : IService
	{
		Task<Result<List<UserResponse>>> GetAllAsync();

		Task<int> GetCountAsync();

		Task<IResult<UserResponse>> GetAsync(string userId);

		Task<IResult> RegisterAsync(RegisterRequest request, string origin);

		Task<IResult> ToggleUserStatusAsync(ToggleUserStatusRequest request);

		Task<IResult<UserRolesResponse>> GetRolesAsync(string id);

		Task<IResult> UpdateRolesAsync(UpdateUserRolesRequest request);

		Task<IResult<string>> ConfirmEmailAsync(string userId, string code);

		Task<IResult> ForgotPasswordAsync(string emailId, string origin);

		Task<IResult> ResetPasswordAsync(ResetPasswordRequest request);
	}
}