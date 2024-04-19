using shopOnline;

namespace server.Repository;

public class ShopOnlintRepository : IShopOnlintRepository
{
    private readonly List<ProductType> _ProductType;
    private readonly List<TS> _Ts;
    private readonly List<client> _client;
    private readonly List<courier> _courier;
    private readonly List<Shop> _Shop;

    public ShopOnlintRepository()
    {
        _ProductType = new List<ProductType>
        {
            new ProductType { Id=1, type="крупногабаритный"},
            new ProductType { Id=2, type="мелкогабаритный"}
        };
        _Ts = new List<TS>
        {
            new TS { Id = 1, car_number = 123, model = "жигули", typeId=1},
            new TS { Id = 2, car_number = 124, model = "жига", typeId=2 },
            new TS { Id = 3, car_number = 125, model = "бмв", typeId=2},
            new TS { Id = 4, car_number = 100, model = "порш", typeId=1 }
        };
        _client = new List<client>
        {
            new client{ Id=1, FIO="Пупкин В.В.", address="Жмыха 1", phone_number="2323233265"},
            new client{ Id=2, FIO="Пуп В.L.", address="Жмыха 23", phone_number="96887655"},
            new client{ Id=3, FIO="П В.Д.", address="Жмы 44", phone_number="911"}

        };

        _courier = new List<courier>
        {
            new courier{ Id=1, FIO="рю", telephone="2555252", carId=1},
            new courier{ Id=1, FIO="зю", telephone="25532422", carId=2},
            new courier{ Id=2, FIO="вю", telephone="2557457",carId=3},
            new courier{ Id=3, FIO="ио", telephone="2845564", carId=4},
            new courier{ Id=4, FIO="гранж", telephone="2456456",carId=1},
            new courier{ Id=5, FIO="ди.", telephone="2234234",carId=3},
            new courier{ Id=6, FIO="ми", telephone="2623626", carId=4}
        };
        _Shop = new List<Shop>
         {
             new Shop{ Id=1,courierId=1, clientId=2,date_time_order= new DateTime(2022, 11, 20, 19, 00, 00),date_time_delivery= new DateTime(2022, 11, 24, 19, 00, 00),date_time_delivery_actual= new DateTime(2022, 11, 24, 19, 35, 00), order_number=111,status="доставлен", typeId=2 },
             new Shop{ Id=2,courierId=2, clientId=1,date_time_order= new DateTime(2022, 11, 19, 16, 00, 00),date_time_delivery= new DateTime(2022, 11, 20, 19, 00, 00),date_time_delivery_actual= new DateTime(2022, 11, 20, 19, 00, 00), order_number=1235,status="доставлен", typeId=1  },
             new Shop{ Id=3,courierId=3, clientId=2,date_time_order= new DateTime(2022, 11, 22, 17, 00, 00),date_time_delivery= new DateTime(2022, 11, 24, 16, 00, 00),date_time_delivery_actual= new DateTime(2022, 11, 24, 18, 35, 00), order_number=1236,status="доставлен", typeId=1  },

         };


    }
    public List<ProductType> ProductType => _ProductType;
    public List<TS> TS => _Ts;
    public List<client> client => _client;
    public List<courier> courier => _courier;
    public List<Shop> Shop => _Shop;
}

