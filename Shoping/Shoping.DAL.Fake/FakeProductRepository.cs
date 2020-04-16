//using Shoping.Domain.Contract.Repositories;
//using Shoping.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Shoping.DAL.Fake
//{
//    public class FakeProductRepository : IProductRepository
//    {
//        public List<Product> GetAll()
//        {
//            return new List<Product> {


//            new Product{
//            Category = "لباس مردانه",
//                    Description = "پیراهن مردانه مرغوب تولید ملی",
//                    ImageUrl ="Product01.jpg",
//                    Name = "پیراهن مردانه",
//                    Price = 15,
//                    ProductID = 1

//            },
//            new Product{

//               Category = "لباس مردانه",
//                    Description = "پیراهن مردانه مرغوب تولید ملی",
//                    ImageUrl ="Product02.jpg",
//                    Name = "پیراهن مردانه قرمز",
//                    Price = 15,
//                    ProductID = 2

//            },

//            new Product
//            {

//                    Category = "کفش مردانه",
//                    Description = "کفش ملی، تولید ملی",
//                    ImageUrl ="Product02.jpg",
//                    Name = "کفش کالج",
//                    Price = 15,
//                    ProductID = 3

//            }


//            };
//        }

//        public List<string> GetAllCategories()
//        {
//            throw new NotImplementedException();
//        }

//        public Product GetById(int ProductId)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Product> GetPagedData(int pageNumber, int PageSize)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
