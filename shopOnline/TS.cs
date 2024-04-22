namespace shopOnline;

public class TS
{
    public int Id { get; set; }
    public int CarNumber { get; set; }
    public string Model { get; set; } = string.Empty;
    public int TypeId { get; set; }
    public TS() { }
    public TS(int id, int carNumber, string model, int type)
    {
        Id = id;
        this.CarNumber = carNumber;
        this.Model = model;
        this.TypeId = type;
    }
    public override bool Equals(object? obj)
    {
        if (obj is not TS param)
            return false;

        return Id == param.Id &&
               CarNumber == param.CarNumber &&
               Model == param.Model &&
               TypeId == param.TypeId;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

}
