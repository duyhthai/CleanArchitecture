﻿namespace BlazorHero.CleanArchitecture.Client.Infrastructure.Routes
{
	public static class ProductsEndpoint
	{
		public static string GetAllPaged(int pageNumber, int pageSize)
		{
			return $"api/v1/products?pageNumber={pageNumber}&pageSize={pageSize}";
		}

		public static string GetCount = "api/v1/products/count";

		public static string GetProductImage(int productId)
		{
			return $"api/v1/products/image/{productId}";
		}

		public static string Save = "api/v1/products";
		public static string Delete = "api/v1/products";
		public static string ChangePassword = "api/identity/account/changepassword";
		public static string UpdateProfile = "api/identity/account/updateprofile";
	}
}