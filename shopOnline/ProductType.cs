namespace shopOnline;
public class ProductType
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public ProductType() { }

    public ProductType(int id, string type)
    {
        Id = id;
        this.Type = type;
    }
    public override bool Equals(object? obj)
    {
        if (obj is not ProductType param)
            return false;

        return Id == param.Id &&
               Type == param.Type;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

}

