using shopOnline;

namespace server.Repository;

public class ShopOnlintRepository : IShopOnlintRepository
{
    private readonly List<ProductType> _productType;
    private readonly List<TS> _ts;
    private readonly List<Client> _client;
    private readonly List<Courier> _courier;
    private readonly List<Shop> _shop;

    public ShopOnlintRepository()
    {
        _productType = new List<ProductType>
        {
            new ProductType { Id=1, Type="крупногабаритный"},
            new ProductType { Id=2, Type="мелкогабаритный"}
        };
        _ts = new List<TS>
        {
            new TS { Id = 1, CarNumber = 123, Model = "жигули", TypeId=1},
            new TS { Id = 2, CarNumber = 124, Model = "жига", TypeId=2 },
            new TS { Id = 3, CarNumber = 125, Model = "бмв", TypeId=2},
            new TS { Id = 4, CarNumber = 100, Model = "порш", TypeId=1 }
        };
        _client = new List<Client>
        {
            new Client{ Id=1, FIO="Пупкин В.В.", Address="Жмыха 1", PhoneNumber="2323233265"},
            new Client{ Id=2, FIO="Пуп В.L.", Address="Жмыха 23", PhoneNumber="96887655"},
            new Client{ Id=3, FIO="П В.Д.", Address="Жмы 44", PhoneNumber="911"}

        };

        _courier = new List<Courier>
        {
            new Courier{ Id=1, FIO="рю", Telephone="2555252", CarId=1},
            new Courier{ Id=1, FIO="зю", Telephone="25532422", CarId=2},
            new Courier{ Id=2, FIO="вю", Telephone="2557457",CarId=3},
            new Courier{ Id=3, FIO="ио", Telephone="2845564", CarId=4},
            new Courier{ Id=4, FIO="гранж", Telephone="2456456",CarId=1},
            new Courier{ Id=5, FIO="ди.", Telephone="2234234",CarId=3},
            new Courier{ Id=6, FIO="ми", Telephone="2623626", CarId=4}
        };
        _shop = new List<Shop>
         {
             new Shop{ Id=1,CourierId=1, ClientId=2,DateTimeOrder= new DateTime(2022, 11, 20, 19, 00, 00),DateTimeDelivery= new DateTime(2022, 11, 24, 19, 00, 00),DateTimeDeliveryActual= new DateTime(2022, 11, 24, 19, 35, 00), OrderNumber=111,Status="доставлен", TypeId=2 },
             new Shop{ Id=2,CourierId=2, ClientId=1,DateTimeOrder= new DateTime(2022, 11, 19, 16, 00, 00),DateTimeDelivery= new DateTime(2022, 11, 20, 19, 00, 00),DateTimeDeliveryActual= new DateTime(2022, 11, 20, 19, 00, 00), OrderNumber=1235,Status="доставлен", TypeId=1  },
             new Shop{ Id=3,CourierId=3, ClientId=2,DateTimeOrder= new DateTime(2022, 11, 22, 17, 00, 00),DateTimeDelivery= new DateTime(2022, 11, 24, 16, 00, 00),DateTimeDeliveryActual= new DateTime(2022, 11, 24, 18, 35, 00), OrderNumber=1236,Status="доставлен", TypeId=1  },

         };


    }
    public List<ProductType> ProductType => _productType;
    public List<TS> TS => _ts;
    public List<Client> Client => _client;
    public List<Courier> Courier => _courier;
    public List<Shop> Shop => _shop;
}

