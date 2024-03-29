﻿using GeekShooping.New.Web.Models;

namespace GeekShooping.New.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAll(string token);
        Task<ProductModel> FindById(long id, string token);
        Task<ProductModel> Create(ProductModel model, string token);
        Task<ProductModel> Update(ProductModel model, string token);
        Task<bool> Delete(long id, string token);

    }
}
