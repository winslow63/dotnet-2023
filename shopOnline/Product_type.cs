namespace shopOnline;
public class ProductType
{
    public int Id { get; set; }
    public string type { get; set; } = string.Empty;
    public ProductType() { }

    public ProductType(int id, string type)
    {
        Id = id;
        this.type = type;
    }
    public override bool Equals(object? obj)
    {
        if (obj is not ProductType param)
            return false;

        return Id == param.Id &&
               type == param.type;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

}

