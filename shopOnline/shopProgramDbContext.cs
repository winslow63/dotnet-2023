using Microsoft.EntityFrameworkCore;

namespace shopOnline;

public class shopProgramDbContext : DbContext
{
    public DbSet<Shop>? shop { get; set; }
    public DbSet<TS>? TS { get; set; }
    public DbSet<client>? client { get; set; }
    public DbSet<courier>? courier { get; set; }
    public DbSet<ProductType>? ProductType { get; set; }


    public shopProgramDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        var ProductType1 = new ProductType { Id = 1, type = "крупногабаритный" };
        var ProductType2 = new ProductType { Id = 2, type = "мелкогабаритный" };

        modelBuilder.Entity<ProductType>().HasData(new List<ProductType> { ProductType1, ProductType2 });

        var TS1 = new TS { Id = 1, car_number = 123, model = "жигули", typeId = 1 };
        var TS2 = new TS { Id = 2, car_number = 124, model = "жига", typeId = 2 };
        var TS3 = new TS { Id = 3, car_number = 125, model = "бмв", typeId = 2 };
        var TS4 = new TS { Id = 4, car_number = 100, model = "порш", typeId = 1 };

        modelBuilder.Entity<TS>().HasData(new List<TS> { TS1, TS2, TS3, TS4 });
        var client1 = new client { Id = 1, FIO = "Пупкин В.В.", address = "Жмыха 1", phone_number = "2323233265" };
        var client2 = new client { Id = 2, FIO = "Пуп В.L.", address = "Жмыха 23", phone_number = "96887655" };
        var client3 = new client { Id = 3, FIO = "П В.Д.", address = "Жмы 44", phone_number = "911" };

        modelBuilder.Entity<client>().HasData(new List<client> { client1, client2, client3 });

        var courier1 = new courier { Id = 1, FIO = "рю", telephone = "2555252", carId = 1 };
        var courier2 = new courier { Id = 2, FIO = "вю", telephone = "2557457", carId = 3 };
        var courier3 = new courier { Id = 3, FIO = "ио", telephone = "2845564", carId = 4 };
        var courier4 = new courier { Id = 4, FIO = "гранж", telephone = "2456456", carId = 1 };
        var courier5 = new courier { Id = 5, FIO = "ди.", telephone = "2234234", carId = 3 };
        var courier6 = new courier { Id = 6, FIO = "ми", telephone = "2623626", carId = 4 };

        modelBuilder.Entity<courier>().HasData(new List<courier> { courier1, courier2, courier3, courier4, courier5, courier6 });

        var Shop1 = new Shop { Id = 1, courierId = 1, clientId = 2, date_time_order = new DateTime(2022, 11, 20, 19, 00, 00), date_time_delivery = new DateTime(2022, 11, 24, 19, 00, 00), date_time_delivery_actual = new DateTime(2022, 11, 24, 19, 35, 00), order_number = 111, status = "доставлен", typeId = 2 };
        var Shop2 = new Shop { Id = 2, courierId = 1, clientId = 1, date_time_order = new DateTime(2022, 11, 19, 16, 00, 00), date_time_delivery = new DateTime(2022, 11, 20, 19, 00, 00), date_time_delivery_actual = new DateTime(2022, 11, 20, 19, 00, 00), order_number = 1235, status = "доставлен", typeId = 1 };
        var Shop3 = new Shop { Id = 3, courierId = 3, clientId = 2, date_time_order = new DateTime(2022, 11, 22, 17, 00, 00), date_time_delivery = new DateTime(2022, 11, 24, 16, 00, 00), date_time_delivery_actual = new DateTime(2022, 11, 24, 18, 35, 00), order_number = 1236, status = "доставлен", typeId = 1 };

        modelBuilder.Entity<Shop>().HasData(new List<Shop> { Shop1, Shop2, Shop3 });

    }
}








