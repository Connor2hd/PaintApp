using Microsoft.EntityFrameworkCore;
using PaintAppModels;

namespace PaintAppModels
{
    public class PaintContext : DbContext
    {
        public PaintContext(DbContextOptions<PaintContext> options)
            : base(options)
        {
        }

        public DbSet<Paint>? Paint { get; set; } = null!;

        public DbSet<Manufacturer>? Manufacturer { get; set; }

        public DbSet<PaintGroup>? PaintGroup { get; set; }

        public DbSet<UserPaint>? UserPaint { get; set; }

        public DbSet<User>? User { get; set; }
    }
}
