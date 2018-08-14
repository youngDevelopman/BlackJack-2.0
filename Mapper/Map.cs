using DAL.Entities;
using System.Collections.Generic;
using VML;
using System.Linq;

namespace Mapper
{
    public static class Map
    {
        public static ViewModelCard MapCards(Card card)
        {
            ViewModelCard viewModelCard = new ViewModelCard()
            {
                Id = card.Id,
                CardValue = card.CardValue,
                Suit = card.Suit
            };

            return viewModelCard;

        }

        public static List<ViewModelCard> MapCardsList(List<Card> cardsList)
        {
            List<ViewModelCard> viewModelCardsList = new List<ViewModelCard>();

            foreach(var c in cardsList)
            {
                ViewModelCard viewModelCard = MapCards(c);
                viewModelCardsList.Add(viewModelCard);
            } 

            return viewModelCardsList;
        }

        public static ViewModelPlayer MapPlayer(Player player)
        {
            ViewModelPlayer viewModelPlayer = new ViewModelPlayer()
            {
                Id = player.Id,
                Cards = MapCardsList(player.Cards.ToList()),
                Name = player.Name,
                PlayerType = player.PlayerType
            };

            return viewModelPlayer;
        }

        public static List<ViewModelPlayer> MapPlayersList(List<Player> playersList)
        {
            List<ViewModelPlayer> viewModelPlayersList = new List<ViewModelPlayer>();

            foreach(var p in playersList)
            {
                ViewModelPlayer viewModelPlayer = MapPlayer(p);
                viewModelPlayersList.Add(viewModelPlayer);
            }

            return viewModelPlayersList;
        }
    }
}
