﻿using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorHero.CleanArchitecture.Application.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddApplicationLayer(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			//services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddMediatR(Assembly.GetExecutingAssembly());
			//services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
		}
	}
}