using Shoping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shoping.Domain.Contract.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        List<string> GetAllCategories();
        Product GetById(int ProductId);
        PagedResult<Product> GetPagedData(string category, int pageNumber, int PageSize);

        void SaveProduct(Product product);
        Product DeleteProduct(int productID);
        List<Product> Find(string query);

        List<Product> Search(string name);
    }
}
