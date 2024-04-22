namespace server.Dto;
public class Test6Dto
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public string FIO { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;
    public int CarId { get; set; }
    public DateTime DateTimeDelivery { get; set; } = DateTime.MinValue;
    public DateTime DateTimeDeliveryActual { get; set; } = DateTime.MinValue;
}

