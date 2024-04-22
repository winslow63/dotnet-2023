namespace server.Dto;

public class ShopPostDto
{
    public int CourierId { get; set; }
    public int ClientId { get; set; }
    public DateTime DateTimeOrder { get; set; } = DateTime.MinValue;
    public DateTime DateTimeDelivery { get; set; } = DateTime.MinValue;
    public DateTime DateTimeDeliveryActual { get; set; } = DateTime.MinValue;
    public int OrderNumber { get; set; }
    public string Status { get; set; } = string.Empty;
    public int TypeId { get; set; }
}

