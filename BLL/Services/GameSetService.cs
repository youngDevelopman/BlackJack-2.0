using BLL.Repositories;
using DAL.Entities;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VML;

namespace BLL.Services
{
    public class GameSetService
    {
        Repository<Card> cardRepository;
        Repository<Player> playerRepository;

        static Random random;
        public GameSetService()
        {
            cardRepository = new Repository<Card>(new DAL.BlackJackContext());
            playerRepository = new Repository<Player>(new DAL.BlackJackContext());
            random = new Random();
        }

        public async Task<List<ViewModelCard>> SetDeck()
        {
            int countOfCards = 54;
            for (int i = 0; i < countOfCards; i++)
            {
                Card card = new Card() { CardValue = random.Next(1, 11) };
                await cardRepository.Create(card);
            }

            IEnumerable<Card> cardsList = await cardRepository.Get();
            var viewModelCardList =  Map.MapCardsList(cardsList.ToList());
            return viewModelCardList;
        }

        public async Task<List<ViewModelPlayer>> SetPlayers()
        {
            List<string> botNames = new List<string>() { "John","Bill","Trevor"};

            for (int i = 0; i < 3; i++)
            {
                await playerRepository.Create(new Player() { Name = botNames[i], PlayerType = "Bot" });
            }

            Player player = new Player() { Name = "Me" };
            await playerRepository.Create(player);

            Player dealer = new Player() { Name = "Dealer" };
            await playerRepository.Create(dealer);

            var playersList = await playerRepository.Get();
            var viewModelPlayersList = Map.MapPlayersList(playersList.ToList());

            return viewModelPlayersList;
        }

        public async Task<IEnumerable<ViewModelPlayer>> GetAllPlayers()
        {
            var players = await playerRepository.Get();
            var playersViewModel = Map.MapPlayersList(players.ToList());
            return playersViewModel;
        }
    }
}
