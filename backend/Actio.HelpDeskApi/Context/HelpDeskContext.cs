using Actio.HelpDeskApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace Actio.HelpDeskApi.Context
{
    public class HelpDeskContext : DbContext
    {
        public HelpDeskContext(DbContextOptions<HelpDeskContext> options)
            : base(options)
        { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Bet> Bet { get; set; }
    }
}
