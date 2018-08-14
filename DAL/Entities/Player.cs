using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlayerType { get; set; }

        public virtual ICollection<Card> Cards { get; set; }

        public Player()
        {
            Cards = new HashSet<Card>();
        }
    }
}
