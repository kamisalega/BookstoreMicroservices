using System.Threading.Tasks;
using Bookstore.Services.Marketing.Entities;

namespace Bookstore.Services.Marketing.Repositories
{
    public interface IBasketChangeBookRepository
    {
        Task AddBasketChangeBook(BasketChangeBook basketChangeBook);
    }
}
