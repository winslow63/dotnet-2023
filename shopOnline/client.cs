namespace shopOnline;

public class client
{
    public int Id { get; set; }
    public string FIO { get; set; } = string.Empty;
    public string address { get; set; } = string.Empty;
    public string phone_number { get; set; } = string.Empty;
    public client() { }
    public client(int id, string fIO, string address, string phone_number)
    {
        Id = id;
        this.FIO = fIO;
        this.address = address;
        this.phone_number = phone_number;
    }
    public override bool Equals(object? obj)
    {
        if (obj is not client param)
            return false;
        return Id == param.Id &&
               FIO == param.FIO &&
               address == param.address &&
               phone_number == param.phone_number;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
