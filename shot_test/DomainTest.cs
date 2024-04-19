using shopOnline;
using static System.Formats.Asn1.AsnWriter;

namespace shop_test;

public class DomainTest : IClassFixture<Store_data>
{

    private readonly Store_data _Store_data;

    public DomainTest(Store_data store_data)
    {
        _Store_data = store_data;
    }


    /*[Fact]
    public void Test()
    {
        var client = new List<client>
        {
            new client{ Id=1, FIO="Пупкин В.В.", address="Жмыха 1", phone_number="2323233265"},
            new client{ Id=2, FIO="Пуп В.L.", address="Жмыха 23", phone_number="96887655"},
            new client{ Id=3, FIO="П В.Д.", address="Жмы 44", phone_number="911"}
        };
       var P_type = new List<ProductType>
        {
            new ProductType { Id=1, Name="крупногабаритный"},
            new ProductType { Id=2, Name="мелкогабаритный"}
        };
        var shop = new List<Shop>
        {
            new Shop { Id=0, order_number=111, order_date="01.01.2012", client= client[0],type=P_type[0] },
            new Shop { Id=1, order_number=112, order_date="02.01.2012", client= client[1],type=P_type[1] },
            new Shop { Id=2, order_number=113, order_date="02.01.2012", client= client[2],type=P_type[1] },
            new Shop { Id=3, order_number=114, order_date="03.01.2012", client= client[0],type=P_type[0] },
            new Shop { Id=4, order_number=115, order_date="03.01.2012", client= client[1],type=P_type[0] },
            new Shop { Id=5, order_number=116, order_date="03.01.2012", client= client[2],type=P_type[1] },
            new Shop { Id=6, order_number=117, order_date="04.01.2012", client= client[0],type=P_type[0] }
        };

        var quare=
            from shops in shop
            where shops.order_number==111
            select shops;
    }*/

    [Fact]
    public void test1()
    {
        var quare =
            from shops in _Store_data.Shop
            where shops.order_number == 111
            select shops;
        //Assert.Equal(1, quare);
        Console.WriteLine(quare);
    }
    [Fact]

    public void test2()
    {
        var quare =
            from shops in _Store_data.Shop
            where shops.status == "доставлен"
            orderby shops.date_time_order
            //orderby shops.date_time_order
            select shops;
        //Assert.Equal(1, quare);
        Console.WriteLine(quare);
    }

    [Fact]

    public void test3()
    {
        var first_date = new DateTime(2022, 11, 20, 00, 00, 00);
        var second_date = new DateTime(2022, 11, 21, 00, 00, 00);
        var quare =
            from shops in _Store_data.Shop
            join couriers in _Store_data.courier on shops.courier equals  couriers
            where (shops.date_time_delivery >= first_date) &&
            (shops.date_time_delivery <= second_date)

            ///orderby shops.date_time_order
            select new { shops.Id, shops.client, couriers.FIO, couriers.telephone, couriers.car, shops.date_time_delivery };
        Console.WriteLine(quare);
    }

    [Fact]

    public void test4()
    {
        var quare = (
            from shops in _Store_data.Shop
            join ProductTypes in _Store_data.ProductType on shops.type equals ProductTypes
            where (shops.status == "доставлен")
            group shops by shops.type into g
            select new { Category = g.Key.type, Count = g.Count() }) ;


    }

    [Fact]
    public void test5()
    {
        var quare = (
            from shops in _Store_data.Shop
            join couriers in _Store_data.courier on shops.courier equals couriers
            //where (shops.status == "доставлен")
            group shops by shops.courier into g
            orderby g.Count() descending
            select new { Category = g.Key.FIO,tel= g.Key.telephone, Count = g.Count() });

        var r = quare.Max(c => c.Count);
        var rr =
            from quares in quare
            where (quares.Count == r)
            select quares;


    }
    [Fact]
    public void test6()
    {
        var first_date = new TimeSpan(00, 15, 00);
        var quare =
            from shops in _Store_data.Shop
            join couriers in _Store_data.courier on shops.courier equals couriers
            where ((shops.date_time_delivery_actual - shops.date_time_delivery) >= first_date)
            orderby (shops.date_time_delivery_actual - shops.date_time_delivery) descending
            select new { shops.Id, shops.client, couriers.FIO, couriers.telephone, couriers.car, shops.date_time_delivery};

        Console.WriteLine(quare);



    }
    
}