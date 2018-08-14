using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BlackJackContext :DbContext
    {
        static BlackJackContext()
        {
            Database.SetInitializer<BlackJackContext>(new BlackJackDbInitializer());
        }
        public BlackJackContext(): base("BlackJackContext")
        { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class BlackJackDbInitializer : DropCreateDatabaseAlways<BlackJackContext>
    {
        protected override void Seed(BlackJackContext context)
        {
        }
    }
}
