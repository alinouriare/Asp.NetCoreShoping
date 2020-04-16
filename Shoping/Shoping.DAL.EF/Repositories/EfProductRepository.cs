using Shoping.Domain.Contract.Repositories;
using Shoping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shoping.DAL.EF.Repositories
{
    public class EfProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public EfProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntity = _context.Products.FirstOrDefault(c => c.ProductID == productID);
            if (dbEntity !=null)
            {
                _context.Remove(dbEntity);
                _context.SaveChanges();
            }
            return dbEntity;
        }

        public List<Product> Find(string query)
        {
            return _context.Products.
             Where(c => c.Name.StartsWith(query)).OrderBy(c => c.Name).Take(10).ToList();
        }

        public List<Product> GetAll()
        {
          return  _context.Products.ToList();
        }

        public List<string> GetAllCategories()
        {
            return _context.Products.Select(c => c.Category).Distinct().ToList();
        }

        public Product GetById(int ProductId)
        {
            return _context.Products.Find(ProductId);
        }

        public PagedResult<Product> GetPagedData(string category,int pageNumber, int PageSize)
        {
            var query = _context.Products.Where(c => string.IsNullOrWhiteSpace(category) || c.Category == category);
            PagedResult<Product> result = new PagedResult<Product>();

            result.pagingData.CurrentPage = pageNumber;
            result.pagingData.ItemsPerPage = PageSize;
            result.pagingData.TotalItems = query.Count();
            result.Items= query.OrderBy(c => c.ProductID).Skip((pageNumber - 1) * PageSize).Take(PageSize).ToList();

            return result;
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID==0)
            {
                _context.Products.Add(product);
            }
            else
            {
                Product dbEntity = _context.Products.FirstOrDefault(c => c.ProductID == product.ProductID);
                if (dbEntity !=null)
                {
                    dbEntity.Price = product.Price;
                    dbEntity.Description = product.Description;
                    dbEntity.Name = product.Name;
                    dbEntity.Category = product.Category;
                }
            }
            _context.SaveChanges();
        }

        public List<Product> Search(string name)
        {
            return _context.Products.Where(c => c.Category.Contains(name) && c.Name.Contains(name)).ToList();
        }
    }
}
