using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VML
{
    public class ViewModelPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlayerType { get; set; }

        public  ICollection<ViewModelCard> Cards { get; set; }

        public int Count
        {
            get
            {
               return Cards.Sum(c => c.CardValue);
            }

        }

        public ViewModelPlayer()
        {
            Cards = new HashSet<ViewModelCard>();
        }
    }
}
