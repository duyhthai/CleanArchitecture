﻿using System;
using System.Threading.Tasks;
using BlazorHero.CleanArchitecture.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace BlazorHero.CleanArchitecture.Server.Permission
{
	internal class PermissionPolicyProvider : IAuthorizationPolicyProvider
	{
		public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

		public PermissionPolicyProvider(IOptions<AuthorizationOptions> options)
		{
			FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
		}

		public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => FallbackPolicyProvider.GetDefaultPolicyAsync();

		public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
		{
			if (policyName.StartsWith(ApplicationClaimTypes.Permission, StringComparison.OrdinalIgnoreCase))
			{
				var policy = new AuthorizationPolicyBuilder();
				policy.AddRequirements(new PermissionRequirement(policyName));
				return Task.FromResult(policy.Build());
			}
			return FallbackPolicyProvider.GetPolicyAsync(policyName);
		}

		public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => Task.FromResult<AuthorizationPolicy>(null);
	}
}