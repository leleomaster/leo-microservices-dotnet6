﻿using GeekShooping.New.Web.Models;
using GeekShooping.New.Web.Services.IServices;
using GeekShooping.New.Web.Services.Utils;
using System.Net.Http.Headers;

namespace GeekShooping.New.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<ProductModel>> FindAll(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(BasePath);

            return await response.RedContentAsync<List<ProductModel>>();
        }

        public async Task<ProductModel> FindById(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");

            return await response.RedContentAsync<ProductModel>();
        }

        public async Task<ProductModel> Create(ProductModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJson($"{BasePath}", model);

            if (response.IsSuccessStatusCode) return await response.RedContentAsync<ProductModel>();
            else throw new Exception("Something went worng when calling API");
        }

        public async Task<ProductModel> Update(ProductModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJson($"{BasePath}", model);

            if (response.IsSuccessStatusCode) return await response.RedContentAsync<ProductModel>();
            else throw new Exception("Something went worng when calling API");
        }

        public async Task<bool> Delete(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");

            if (response.IsSuccessStatusCode) return await response.RedContentAsync<bool>();
            else throw new Exception("Something went worng when calling API");
        }
    }
}
