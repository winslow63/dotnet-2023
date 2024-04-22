using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace shopOnline;

public class ShopProgramContextFactory : IDesignTimeDbContextFactory<ShopProgramDbContext>
{
    public ShopProgramDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ShopProgramDbContext>();
        optionsBuilder.UseMySQL("Server=127.0.0.1; Uid=root; password=1234; Database=shopProgram");
        return new ShopProgramDbContext(optionsBuilder.Options);

    }


}

