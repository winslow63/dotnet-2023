namespace server.Dto;

public class TSGetDto
{
    public int Id { get; set; }
    public int CarNumber { get; set; }
    public string Model { get; set; } = string.Empty;
    public int TypeId { get; set; }
}

