using Shoping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shoping.Domain.Contract.Repositories
{
   public interface IOrderRepository
    {


        List<Order> GetList(bool? shipped);
        Order GetById(int orderId);

        void SaveOrder(Order order);
        void SetTransactionId(int orderId, string transId);
        void SetPaymentDone(int transId);
    }
}
