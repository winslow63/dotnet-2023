namespace server.Dto;

public class ClientGetDto
{
    public int Id { get; set; }
    public string FIO { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

}

