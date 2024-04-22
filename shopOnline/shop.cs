namespace shopOnline;

public class Shop
{
    public int Id { get; set; }
    public int CourierId { get; set; }
    public int ClientId { get; set; }
    public DateTime DateTimeOrder { get; set; }
    public DateTime DateTimeDelivery { get; set; }
    public DateTime DateTimeDeliveryActual { get; set; }
    public int OrderNumber { get; set; }
    public string Status { get; set; } = string.Empty;
    public int TypeId { get; set; }
    public Shop() { }
    public Shop(int id, int courier, int client, DateTime dateTimeOrder, DateTime dateTimeDelivery, DateTime dateTimeDeliveryActual, int orderNumber, string status, int type)
    {
        Id = id;
        this.CourierId = courier;
        this.ClientId = client;
        this.DateTimeOrder = dateTimeOrder;
        this.DateTimeDelivery = dateTimeDelivery;
        this.DateTimeDeliveryActual = dateTimeDeliveryActual;
        this.OrderNumber = orderNumber;
        this.Status = status;
        this.TypeId = type;

    }
    public override bool Equals(object? obj)
    {
        if (obj is not Shop param)
            return false;

        return Id == param.Id &&
               CourierId == param.CourierId &&
               ClientId == param.ClientId &&
               DateTimeOrder == param.DateTimeOrder &&
               DateTimeDelivery == param.DateTimeDelivery &&
               DateTimeDeliveryActual == param.DateTimeDeliveryActual &&
               OrderNumber == param.OrderNumber &&
               Status == param.Status &&
               TypeId == param.TypeId;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
