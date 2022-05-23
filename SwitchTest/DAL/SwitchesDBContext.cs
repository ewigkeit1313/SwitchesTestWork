using Microsoft.EntityFrameworkCore;
using SwitchTest.Models;


namespace SwitchTest.DAL
{
    public class SwitchesDBContext : DbContext
    {
        public SwitchesDBContext(DbContextOptions<SwitchesDBContext> options)
            : base(options) { }

        public virtual DbSet<Switch> Switches { get; set; }
    }
}
