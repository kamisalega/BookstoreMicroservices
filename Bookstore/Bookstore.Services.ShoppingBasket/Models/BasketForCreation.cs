using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Services.ShoppingBasket.Models
{
    public class BasketForCreation
    {
        public Guid UserId { get; set; }
    }
}
