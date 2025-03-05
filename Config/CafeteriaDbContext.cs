using Microsoft.EntityFrameworkCore;

namespace Cafeteria.Config
{
    public class CafeteriaDbContext : DbContext
    {
        public CafeteriaDbContext (DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }


    }
}