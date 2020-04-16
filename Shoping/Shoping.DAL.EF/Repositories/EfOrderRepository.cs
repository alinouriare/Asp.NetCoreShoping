using Microsoft.EntityFrameworkCore;
using Shoping.Domain.Contract.Repositories;
using Shoping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shoping.DAL.EF.Repositories
{
    public class EfOrderRepository : IOrderRepository
    {
        private readonly ApplicationContext context;
        public EfOrderRepository(ApplicationContext ctx)
        {
            context = ctx;
        }
        public Order GetById(int orderId)
        {
            return context.Orders.Include(c => c.Lines).ThenInclude(l=> l.Product).FirstOrDefault(c => c.OrderID == orderId);
        }

        public List<Order> GetList(bool? shipped)
        {
            return context.Orders.Where(c => !shipped.HasValue || c.Shipped == shipped.Value)
                .Include(c => c.Lines).ThenInclude(l => l.Product).ToListAsync().Result;
        }

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(c => c.Product));
            if (order.OrderID==0)
            {
                context.Add(order);
            }
            context.SaveChanges();
        }

        public void SetPaymentDone(int transId)
        {
            var order = context.Orders.FirstOrDefault(c => c.PaymentId == transId.ToString());
            if (order !=null)
            {
                order.PaymentDate = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void SetTransactionId(int orderId, string transId)
        {
            var order = context.Orders.Find(orderId);
            if (order != null)
            {
                order.PaymentId = transId;
                context.SaveChanges();
            }
        }
    }
}
