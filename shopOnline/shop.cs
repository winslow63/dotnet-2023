namespace shopOnline;

public class Shop
{
    public int Id { get; set; }
    public int courierId { get; set; }
    public int clientId { get; set; }
    public DateTime date_time_order { get; set; }
    public DateTime date_time_delivery { get; set; }
    public DateTime date_time_delivery_actual { get; set; }
    public int order_number { get; set; }
    public string status { get; set; } = string.Empty;
    public int typeId { get; set; }
    public Shop() { }
    public Shop(int id, int couriers, int clients, DateTime date_time_orders, DateTime date_time_deliverys, DateTime date_time_delivery_actuals, int order_numbers, string statuss, int types)
    {
        Id = id;
        this.courierId = couriers;
        this.clientId = clients;
        this.date_time_order = date_time_orders;
        this.date_time_delivery = date_time_deliverys;
        this.date_time_delivery_actual = date_time_delivery_actuals;
        this.order_number = order_numbers;
        this.status = statuss;
        this.typeId = types;

    }
    public override bool Equals(object? obj)
    {
        if (obj is not Shop param)
            return false;

        return Id == param.Id &&
               courierId == param.courierId &&
               clientId == param.clientId &&
               date_time_order == param.date_time_order &&
               date_time_delivery == param.date_time_delivery &&
               date_time_delivery_actual == param.date_time_delivery_actual &&
               order_number == param.order_number &&
               status == param.status &&
               typeId == param.typeId;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
