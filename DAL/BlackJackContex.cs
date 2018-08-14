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
        public BlackJackContext(): base("BlackJackContex")
        { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Player> Players { get; set; }
    }

    public class BlackJackDbInitializer : DropCreateDatabaseAlways<BlackJackContext>
    {
        protected override void Seed(BlackJackContext context)
        {
        }
    }
}
