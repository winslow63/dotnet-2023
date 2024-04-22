using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Dto;
using shopOnline;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{

    private readonly ILogger<AnalyticsController> _logger;
    private readonly IDbContextFactory<ShopProgramDbContext> _shopRepository;
    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<AnalyticsController> logger, IDbContextFactory<ShopProgramDbContext> ShopRepository, IMapper mapper)
    {
        _logger = logger;
        _shopRepository = ShopRepository;
        _mapper = mapper;

    }

    [HttpGet("Test1")]
    public async Task<List<ShopGetDto>> GetTest1(int number)
    {
  
        await using var context = await _shopRepository.CreateDbContextAsync();
        _logger.LogInformation("Get passengers without baggage");

        return await (from shops in context.Shop
                      where shops.OrderNumber == number
                      select _mapper.Map<ShopGetDto>(shops)).ToListAsync();

    }

    [HttpGet("Test2")]
    public async Task<IEnumerable<ShopGetDto>> GetTest2()
    {
        await using var context = await _shopRepository.CreateDbContextAsync();
        return await
        (from shops in context.Shop
         where shops.Status == "доставлен"
         orderby shops.DateTimeOrder
         //orderby shops.date_time_order
         select _mapper.Map<ShopGetDto>(shops)).ToListAsync();
        //_logger.LogInformation("Get flights with specified source and destination");

        ///return quare;

    }

    [HttpGet("Test3")]
    public async Task<IEnumerable<Test3Dto>> GetTest3(DateTime deliveryDate)
    {
        await using var context = await _shopRepository.CreateDbContextAsync();

        return await (
            from shop in context.Shop
            join courier in context.Courier on shop.CourierId equals courier.Id
            where shop.DateTimeDelivery.Date == deliveryDate.Date
            select new Test3Dto
            {
                Id = shop.Id,
                CourierId = shop.CourierId,
                FIO = courier.FIO,
                Telephone = courier.Telephone,
                DateTimeOrder = shop.DateTimeOrder,
                DateTimeDelivery = shop.DateTimeDelivery,
                DateTimeDeliveryActual = shop.DateTimeDeliveryActual,
                OrderNumber = shop.OrderNumber,
                Status = shop.Status,
                TypeId = shop.TypeId,
            }).ToListAsync();
    }

    [HttpGet("Test4")]
    public async Task<IEnumerable<Test4Dto>> GetTest4()
    {
        await using var context = await _shopRepository.CreateDbContextAsync();
        //_logger.LogInformation("Get flights with max count of passengers");
        return await (
                     from shop in context.Shop
                     join productType in context.ProductType on shop.TypeId equals productType.Id
                     where shop.Status == "доставлен"
                     group shop by productType.Type into g
                     select new Test4Dto { Category = g.Key, Count = g.Count() }
                     ).ToListAsync();
        ///return query.ToList();
    }


    [HttpGet("Test5")]
    public async Task<IEnumerable<Test5Dto>> GetTest5()
    {
        await using var context = await _shopRepository.CreateDbContextAsync();

        // Получаем данные из базы данных
        var query = await (
            from shops in context.Shop
            join couriers in context.Courier on shops.CourierId equals couriers.Id
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
            .Select(x => new Test5Dto { Category = x.Courier.FIO, Tel = x.Courier.Telephone, Count = x.OrderCount })
            .ToList();

        return couriersWithMaxOrders;
    }


    [HttpGet("Test6")]
    public async Task<IEnumerable<Test6Dto>> GetTest6()
    {
        await using var context = await _shopRepository.CreateDbContextAsync();

        var fifteenMinutes = TimeSpan.FromMinutes(15);

        var query = await (
                from shops in context.Shop
                join couriers in context.Courier on shops.CourierId equals couriers.Id
                select new
                {
                    Id = shops.Id,
                    clientId = shops.ClientId,
                    FIO = couriers.FIO,
                    telephone = couriers.Telephone,
                    carId = couriers.CarId,
                    dateTimeDelivery = shops.DateTimeDelivery,
                    dateTimeDeliveryActual = shops.DateTimeDeliveryActual
                })
                .ToListAsync();
        var couriersWithMaxOrders = query.Where(x => x.dateTimeDeliveryActual > x.dateTimeDelivery + fifteenMinutes)
                .Select(x => new Test6Dto
                {
                    Id = x.Id,
                    ClientId = x.clientId,
                    FIO = x.FIO,
                    Telephone = x.telephone,
                    CarId = x.carId,
                    DateTimeDelivery = x.dateTimeDelivery,
                    DateTimeDeliveryActual = x.dateTimeDeliveryActual
                }).ToList();
        return couriersWithMaxOrders;
    }
}
