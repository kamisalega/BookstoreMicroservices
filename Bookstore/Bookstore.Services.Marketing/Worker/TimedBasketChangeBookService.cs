using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.Services.Marketing.Entities;
using Bookstore.Services.Marketing.Repositories;
using Bookstore.Services.Marketing.Services;

namespace Bookstore.Services.Marketing.Worker
{
    public class TimedBasketChangeBookService
    {
        private Timer _timer;
        private readonly IBasketChangeBookService basketChangeBookService;
        private readonly BasketChangeBookRepository basketChangeBookRepository;
        private readonly IMapper mapper;
        private DateTime lastRun;

        public TimedBasketChangeBookService(IBasketChangeBookService basketChangeBookService, BasketChangeBookRepository basketChangeBookRepository, IMapper mapper)
        {
            this.basketChangeBookService = basketChangeBookService;
            this.basketChangeBookRepository = basketChangeBookRepository;
            this.mapper = mapper;
            lastRun = DateTime.Now;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(60));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            var Books = await basketChangeBookService.GetBasketChangeBooks(lastRun, 10);
            foreach (var basketChangeBook in Books)
            {
                await basketChangeBookRepository.AddBasketChangeBook(mapper.Map<BasketChangeBook>(basketChangeBook));
            }
            lastRun = DateTime.Now;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
