namespace shopOnline;

public class TS
{
    public int Id { get; set; }
    public int car_number { get; set; }
    public string model { get; set; } = string.Empty;
    public int typeId { get; set; }
    public TS() { }
    public TS(int id, int car_number, string model, int type)
    {
        Id = id;
        this.car_number = car_number;
        this.model = model;
        this.typeId = type;
    }
    public override bool Equals(object? obj)
    {
        if (obj is not TS param)
            return false;

        return Id == param.Id &&
               car_number == param.car_number &&
               model == param.model &&
               typeId == param.typeId;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

}
