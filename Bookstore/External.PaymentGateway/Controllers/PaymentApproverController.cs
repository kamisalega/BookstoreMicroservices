using System;
using External.PaymentGateway.Model;
using Microsoft.AspNetCore.Mvc;

namespace External.PaymentGateway.Controllers
{
    public class PaymentApproverController  : Controller
    {
        [HttpPost]
        public IActionResult TryPayment([FromBody] PaymentDto payment)
        {

            int num = new Random().Next(1000);
            if (num > 500)
                return Ok(true);

            return Ok(false);
        }
    }
}
