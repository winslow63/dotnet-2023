using shopOnline;

namespace server.Repository;

public interface IShopOnlintRepository
{
    List<Client> Client { get; }
    List<Courier> Courier { get; }
    List<ProductType> ProductType { get; }
    List<Shop> Shop { get; }
    List<TS> TS { get; }
}
