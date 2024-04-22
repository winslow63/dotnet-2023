namespace server.Dto;

public class Test3Dto
{

    public int Id { get; set; }
    public int CourierId { get; set; }
    public string FIO { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;
    public int CarId { get; set; }
    public DateTime DateTimeOrder { get; set; } = DateTime.MinValue;
    public DateTime DateTimeDelivery { get; set; } = DateTime.MinValue;
    public DateTime DateTimeDeliveryActual { get; set; } = DateTime.MinValue;
    public int OrderNumber { get; set; }
    public string Status { get; set; } = string.Empty;
    public int TypeId { get; set; }

}

