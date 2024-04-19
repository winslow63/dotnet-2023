namespace server.Dto;

public class shopPostDto
{
    public int courierId { get; set; }
    public int clientId { get; set; }
    public DateTime date_time_order { get; set; } = DateTime.MinValue;
    public DateTime date_time_delivery { get; set; } = DateTime.MinValue;
    public DateTime date_time_delivery_actual { get; set; } = DateTime.MinValue;
    public int order_number { get; set; }
    public string status { get; set; } = string.Empty;
    public int typeId { get; set; }
}

