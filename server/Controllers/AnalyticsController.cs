using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Dto;
using shopOnline;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        ///private readonly shopProgramDbContext _context;

        private readonly ILogger<AnalyticsController> _logger;
        private readonly IDbContextFactory<shopProgramDbContext> _ShopRepository;
        private readonly IMapper _mapper;
        public AnalyticsController(ILogger<AnalyticsController> logger, IDbContextFactory<shopProgramDbContext> ShopRepository, IMapper mapper)
        {
            _logger = logger;
            _ShopRepository = ShopRepository;
            _mapper = mapper;

        }

        [HttpGet("Test1")]
        public async Task<List<shopGetDto>> GetTest1(int number)
        {
            // _logger.LogInformation("Get passengers without baggage");
            await using var context = await _ShopRepository.CreateDbContextAsync();
            _logger.LogInformation("Get passengers without baggage");

            return await (from shops in context.shop
                          where shops.order_number == number
                          select _mapper.Map<shopGetDto>(shops)).ToListAsync();
            //Assert.Equal(1, quare);
            /*Console.WriteLine(quare);
            var request = (from flight in _ShopRepository.Flights
                           from ticket in _ShopRepository.Tickets
                           from passenger in _ShopRepository.Passengers
                           from t in passenger.Tickets
                           where (flight.Cipher == chipher) && (ticket.BaggageWeight == 0) && (t.Number == ticket.Number)
                           select _mapper.Map<PassengerGetDto>(passenger));*/
            ///return quare;


        }

        [HttpGet("Test2")]
        public async Task<IEnumerable<shopGetDto>> GetTest2()
        {
            await using var context = await _ShopRepository.CreateDbContextAsync();
            return await
            (from shops in context.shop
             where shops.status == "доставлен"
             orderby shops.date_time_order
             //orderby shops.date_time_order
             select _mapper.Map<shopGetDto>(shops)).ToListAsync();
            //_logger.LogInformation("Get flights with specified source and destination");

            ///return quare;

        }

        [HttpGet("Test3")]
        public async Task<IEnumerable<Test3Dto>> GetTest3(DateTime deliveryDate)
        {
            await using var context = await _ShopRepository.CreateDbContextAsync();

            return await (
                from shop in context.shop
                join courier in context.courier on shop.courierId equals courier.Id
                where shop.date_time_delivery.Date == deliveryDate.Date
                select new Test3Dto
                {
                    Id = shop.Id,
                    courierId = shop.courierId,
                    FIO = courier.FIO,
                    telephone = courier.telephone,
                    date_time_order = shop.date_time_order,
                    date_time_delivery = shop.date_time_delivery,
                    date_time_delivery_actual = shop.date_time_delivery_actual,
                    order_number = shop.order_number,
                    status = shop.status,
                    typeId = shop.typeId,
                }).ToListAsync();
        }

        [HttpGet("Test4")]
        public async Task<IEnumerable<Test4Dto>> GetTest4()
        {
            await using var context = await _ShopRepository.CreateDbContextAsync();
            //_logger.LogInformation("Get flights with max count of passengers");
            return await (
                         from shop in context.shop
                         join productType in context.ProductType on shop.typeId equals productType.Id
                         where shop.status == "доставлен"
                         group shop by productType.type into g
                         select new Test4Dto { Category = g.Key, Count = g.Count() }
                         ).ToListAsync();
            ///return query.ToList();
        }


        [HttpGet("Test5")]
        public async Task<IEnumerable<Test5Dto>> GetTest5()
        {
            await using var context = await _ShopRepository.CreateDbContextAsync();

            // Получаем данные из базы данных
            var query = await (
                from shops in context.shop
                join couriers in context.courier on shops.courierId equals couriers.Id
                select new { Shop = shops, Courier = couriers })
                .ToListAsync();

            // Группируем данные в памяти
            var groupedData = query.GroupBy(item => item.Courier)
                .Select(group => new { Courier = group.Key, OrderCount = group.Count() })
                .OrderByDescending(x => x.OrderCount)
                .ToList();



            // Находим максимальное количество заказов
            var maxOrderCount = groupedData.First().OrderCount;

            // Выбираем курьеров с максимальным количеством заказов
            var couriersWithMaxOrders = groupedData.Where(x => x.OrderCount == maxOrderCount)
                .Select(x => new Test5Dto { Category = x.Courier.FIO, tel = x.Courier.telephone, Count = x.OrderCount })
                .ToList();

            return couriersWithMaxOrders;
        }


        [HttpGet("Test6")]
        public async Task<IEnumerable<Test6Dto>> GetTest6()
        {
            await using var context = await _ShopRepository.CreateDbContextAsync();

            var fifteenMinutes = TimeSpan.FromMinutes(15);

            var query = await (
                    from shops in context.shop
                    join couriers in context.courier on shops.courierId equals couriers.Id
                    select new
                    {
                        Id = shops.Id,
                        clientId = shops.clientId,
                        FIO = couriers.FIO,
                        telephone = couriers.telephone,
                        carId = couriers.carId,
                        date_time_delivery = shops.date_time_delivery,
                        date_time_delivery_actual = shops.date_time_delivery_actual
                    })
                    .ToListAsync();
            var couriersWithMaxOrders = query.Where(x => x.date_time_delivery_actual > x.date_time_delivery + fifteenMinutes)
                    .Select(x => new Test6Dto
                    {
                        Id = x.Id,
                        clientId = x.clientId,
                        FIO = x.FIO,
                        telephone = x.telephone,
                        carId = x.carId,
                        date_time_delivery = x.date_time_delivery,
                        date_time_delivery_actual = x.date_time_delivery_actual
                    }).ToList();
            return couriersWithMaxOrders;

            /*return await (
        from shops in context.Shops
        join couriers in context.Couriers on shops.CourierId equals couriers.Id
        where shops.DateTimeDeliveryActual > shops.DateTimeDelivery + fifteenMinutes
        orderby (shops.DateTimeDeliveryActual - shops.DateTimeDelivery) ascending
        select new Test6Dto 
        { 
            Id = shops.Id, 
            ClientId = shops.ClientId, 
            FIO = couriers.FIO, 
            Telephone = couriers.Telephone, 
            CarId = couriers.CarId, 
            DateTimeDelivery = shops.DateTimeDelivery 
        }).ToListAsync();*/
        }
    }
}
