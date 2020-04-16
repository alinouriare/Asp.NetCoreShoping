using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shoping.Domain.Contract.Payments;
using Shoping.Domain.Contract.Repositories;
using Shoping.Web.UI.Models;

namespace Shoping.Web.UI.Controllers
{
    public class PaymentController : Controller
    {
        IPayment _payment;
        IOrderRepository _orderRepository;
        public PaymentController(IPayment payment, IOrderRepository orderRepository)
        {
            _payment = payment;
            _orderRepository = orderRepository;
        }


        public IActionResult Pay(int orderId, int price)
        {
            var result = _payment.pay(price.ToString());
            if (result.IsCorrect)
            {
                _orderRepository.SetTransactionId(orderId, result.transId);
                return Redirect("https://pay.ir/payment/gateway/" + result.transId);

            }

            return View(result);
        }


        public IActionResult Verify(PaymentResponse model)
        {
            if (model.IsCorrect)
            {
                var verifyResult = _payment.Verify(model.transId.ToString());
                if (verifyResult.IsCorrect)
                {
                    _orderRepository.SetPaymentDone(model.transId);
                    return View("PaymentCompelete", verifyResult);
                }


            }
            return View(model);
        }
    }
}