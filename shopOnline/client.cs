namespace shopOnline;

public class Client
{
    public int Id { get; set; }
    public string FIO { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public Client() { }
    public Client(int id, string fIO, string address, string phoneNumber)
    {
        Id = id;
        this.FIO = fIO;
        this.Address = address;
        this.PhoneNumber = phoneNumber;
    }
    public override bool Equals(object? obj)
    {
        if (obj is not Client param)
            return false;
        return Id == param.Id &&
               FIO == param.FIO &&
               Address == param.Address &&
               PhoneNumber == param.PhoneNumber;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
