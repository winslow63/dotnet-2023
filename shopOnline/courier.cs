public class Courier
{
    public int Id { get; set; }
    public string FIO { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;
    public int CarId { get; set; }

    public Courier() { }
    public Courier(int id, string fio, string telephone, int car)
    {
        Id = id;
        this.FIO = fio;
        this.Telephone = telephone;
        this.CarId = car;
    }
    public override bool Equals(object? obj)
    {
        if (obj is not Courier param)
            return false;

        return Id == param.Id &&
               FIO == param.FIO &&
               Telephone == param.Telephone &&
               CarId == param.CarId;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

}
