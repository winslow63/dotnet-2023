public class courier
{
    public int Id { get; set; }
    public string FIO { get; set; } = string.Empty;
    public string telephone { get; set; } = string.Empty;
    public int carId { get; set; }

    public courier() { }
    public courier(int id, string FIO, string telephone, int car)
    {
        Id = id;
        this.FIO = FIO;
        this.telephone = telephone;
        this.carId = car;
    }
    public override bool Equals(object? obj)
    {
        if (obj is not courier param)
            return false;

        return Id == param.Id &&
               FIO == param.FIO &&
               telephone == param.telephone &&
               carId == param.carId;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

}
