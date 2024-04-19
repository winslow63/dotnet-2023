using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace shopOnline;

public class shopProgramContextFactory : IDesignTimeDbContextFactory<shopProgramDbContext>
{
    public shopProgramDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<shopProgramDbContext>();
        optionsBuilder.UseMySQL("Server=127.0.0.1; Uid=root; password=1234; Database=shopProgram");
        return new shopProgramDbContext(optionsBuilder.Options);

    }


}

