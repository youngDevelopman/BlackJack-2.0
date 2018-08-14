using BLL.IRepositories;
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
        IGenericRepository<Card> cardRepository;
        IGenericRepository<Player> playerRepository;

        static Random random;

        static GameSetService()
        {
            random = new Random();
        }
        
        public GameSetService(IGenericRepository<Player> PlayersGenericRepository,
            IGenericRepository<Card> CardsGenericRepository)
        {
            this.playerRepository = PlayersGenericRepository;
            this.cardRepository = CardsGenericRepository;
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

        public async Task<List<ViewModelPlayer>> GiveCardsOnStart()
        {
            IEnumerable<Player> players = await playerRepository.Get();

            //foreach (var p in players)
            //{
            //    int cardId = 0;
            //    bool isOver = false;
            //    do
            //    {
            //        cardId = random.Next(1, 53);
            //        Card card = await cardRepository.FindById(cardId);
            //        if (!card.IsTaken)
            //        {
            //            card.IsTaken = true;
            //            //await cardRepository.Update(card);
            //            p.Cards.Add(card);
            //            //await playerRepository.Update(p);
            //            await playerRepository.Save();
            //            isOver = true;
            //        }


            //    } while (!isOver);
            //}

            //var cardList =await cardRepository.Get();
            //var playerList = await playerRepository.Get();

            //foreach (var item in playerList)
            //{
            //    Card c = cardList.ToList()[0];
            //    item.Cards.Add(c);
            //    await playerRepository.Update(item);
            //}



            //foreach (var p in players)
            //{
            //    foreach (var item in p.Cards)
            //    {
            //        var t = item;
            //    }
            //}

            var cList = await cardRepository.Get();
            var c = cList.ToList()[0];

            var pList = await playerRepository.Get();
            var p = pList.ToList()[0];

            p.Cards.Add(c);

            await playerRepository.Update(p);

            //foreach(var p in  players)
            //{
            //    Player player = await playerRepository.FindById(p.Id);
            //    Card currentCard;
            //    foreach (var card in p.Cards)
            //    {
            //        currentCard = card;
            //        player.Cards.Add(currentCard);
            //    }
            //    await playerRepository.Update(player);
            //}

            List<Player> playersList = await playerRepository.Get() as List<Player>;
            List<ViewModelPlayer> viewModelPlayersList = Map.MapPlayersList(playersList);
            await playerRepository.Save();

            return viewModelPlayersList;
        }
    }
}
