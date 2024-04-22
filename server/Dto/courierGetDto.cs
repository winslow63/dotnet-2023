namespace server.Dto;

public class CourierGetDto
{
    public int Id { get; set; }
    public string FIO { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;
    public int CarId { get; set; }
}

