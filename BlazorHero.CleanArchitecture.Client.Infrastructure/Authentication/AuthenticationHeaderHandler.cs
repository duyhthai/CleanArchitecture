﻿using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace BlazorHero.CleanArchitecture.Client.Infrastructure.Authentication
{
	public class AuthenticationHeaderHandler : DelegatingHandler
	{
		private readonly ILocalStorageService localStorage;

		public AuthenticationHeaderHandler(ILocalStorageService localStorage)
			=> this.localStorage = localStorage;

		protected override async Task<HttpResponseMessage> SendAsync(
			HttpRequestMessage request,
			CancellationToken cancellationToken)
		{
			if (request.Headers.Authorization?.Scheme != "Bearer")
			{
				var savedToken = await this.localStorage.GetItemAsync<string>("authToken");

				if (!string.IsNullOrWhiteSpace(savedToken))
				{
					request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", savedToken);
				}
			}

			return await base.SendAsync(request, cancellationToken);
		}
	}
}