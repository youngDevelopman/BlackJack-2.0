using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public int CardValue { get; set; }
        public string Suit { get; set; }
        public bool IsTaken { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public Card()
        {
            Players = new HashSet<Player>();
        }
    }
}
