using shopOnline;

namespace server.Repository;

public interface IShopOnlintRepository
{
    List<client> client { get; }
    List<courier> courier { get; }
    List<ProductType> ProductType { get; }
    List<Shop> Shop { get; }
    List<TS> TS { get; }
}
