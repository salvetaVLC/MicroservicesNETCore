﻿using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
	public class OrderService : IOrderService
	{
		private readonly HttpClient _httpClient;

		public OrderService(HttpClient httpClient)
		{
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
		}

		public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
		{
			var response = await _httpClient.GetAsync($"/Order/{userName}");
			return await response.ReadContentAs<List<OrderResponseModel>>();
		}
	}
}
