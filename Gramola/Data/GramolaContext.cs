using Gramola.Models;
using Microsoft.EntityFrameworkCore;

namespace Gramola.Data
{
    public class GramolaContext:DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public GramolaContext(DbContextOptions<GramolaContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=Gramola;Trusted_Connection=True;");
            }
        }
    }
}
