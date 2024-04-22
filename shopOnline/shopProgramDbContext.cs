using Microsoft.EntityFrameworkCore;

namespace shopOnline;

public class ShopProgramDbContext : DbContext
{
    public DbSet<Shop>? Shop { get; set; }
    public DbSet<TS>? TS { get; set; }
    public DbSet<Client>? Client { get; set; }
    public DbSet<Courier>? Courier { get; set; }
    public DbSet<ProductType>? ProductType { get; set; }


    public ShopProgramDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        var productType1 = new ProductType { Id = 1, Type = "крупногабаритный" };
        var productType2 = new ProductType { Id = 2, Type = "мелкогабаритный" };

        modelBuilder.Entity<ProductType>().HasData(new List<ProductType> { productType1, productType2 });

        var ts1 = new TS { Id = 1, CarNumber = 123, Model = "жигули", TypeId = 1 };
        var ts2 = new TS { Id = 2, CarNumber = 124, Model = "жига", TypeId = 2 };
        var ts3 = new TS { Id = 3, CarNumber = 125, Model = "бмв", TypeId = 2 };
        var ts4 = new TS { Id = 4, CarNumber = 100, Model = "порш", TypeId = 1 };

        modelBuilder.Entity<TS>().HasData(new List<TS> { ts1, ts2, ts3, ts4 });
        var client1 = new Client { Id = 1, FIO = "Пупкин В.В.", Address = "Жмыха 1", PhoneNumber = "2323233265" };
        var client2 = new Client { Id = 2, FIO = "Пуп В.L.", Address = "Жмыха 23", PhoneNumber = "96887655" };
        var client3 = new Client { Id = 3, FIO = "П В.Д.", Address = "Жмы 44", PhoneNumber = "911" };

        modelBuilder.Entity<Client>().HasData(new List<Client> { client1, client2, client3 });

        var courier1 = new Courier { Id = 1, FIO = "рю", Telephone = "2555252", CarId = 1 };
        var courier2 = new Courier { Id = 2, FIO = "вю", Telephone = "2557457", CarId = 3 };
        var courier3 = new Courier { Id = 3, FIO = "ио", Telephone = "2845564", CarId = 4 };
        var courier4 = new Courier { Id = 4, FIO = "гранж", Telephone = "2456456", CarId = 1 };
        var courier5 = new Courier { Id = 5, FIO = "ди.", Telephone = "2234234", CarId = 3 };
        var courier6 = new Courier { Id = 6, FIO = "ми", Telephone = "2623626", CarId = 4 };

        modelBuilder.Entity<Courier>().HasData(new List<Courier> { courier1, courier2, courier3, courier4, courier5, courier6 });

        var shop1 = new Shop { Id = 1, CourierId = 1, ClientId = 2, DateTimeOrder = new DateTime(2022, 11, 20, 19, 00, 00), DateTimeDelivery = new DateTime(2022, 11, 24, 19, 00, 00), DateTimeDeliveryActual = new DateTime(2022, 11, 24, 19, 35, 00), OrderNumber = 111, Status = "доставлен", TypeId = 2 };
        var shop2 = new Shop { Id = 2, CourierId = 1, ClientId = 1, DateTimeOrder = new DateTime(2022, 11, 19, 16, 00, 00), DateTimeDelivery = new DateTime(2022, 11, 20, 19, 00, 00), DateTimeDeliveryActual = new DateTime(2022, 11, 20, 19, 00, 00), OrderNumber = 1235, Status = "доставлен", TypeId = 1 };
        var shop3 = new Shop { Id = 3, CourierId = 3, ClientId = 2, DateTimeOrder = new DateTime(2022, 11, 22, 17, 00, 00), DateTimeDelivery = new DateTime(2022, 11, 24, 16, 00, 00), DateTimeDeliveryActual = new DateTime(2022, 11, 24, 18, 35, 00), OrderNumber = 1236, Status = "доставлен", TypeId = 1 };

        modelBuilder.Entity<Shop>().HasData(new List<Shop> { shop1,shop2,shop3 });

    }
}








