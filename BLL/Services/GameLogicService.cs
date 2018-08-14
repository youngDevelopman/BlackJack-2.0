using BLL.IRepositories;
using BLL.Repositories;
using DAL.Entities;
using Mapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VML;

namespace BLL.Services
{
    public class GameLogicService
    {
        static Random random;
        IGenericRepository<Player> playerRepository;
        IGenericRepository<Card> cardRepository;

        public GameLogicService(IGenericRepository<Player> PlayersGenericRepository,
            IGenericRepository<Card> CardsGenericRepository)
        {
            this.playerRepository = PlayersGenericRepository;
            this.cardRepository = CardsGenericRepository;
        }

        static GameLogicService()
        {
            random = new Random();
        } 

        //public async Task GiveCards()
        //{
        //    foreach(var p in await playerRepository.Get())
        //    {
        //        Card card = cardRepository.Pop();
        //        p.Cards.Add(card);
        //    }
        //}

        public async Task<IEnumerable<ViewModelPlayer>> GetAllPlayers()
        {
            var playersList = await playerRepository.GetAllWithNoTracking();
            IEnumerable<ViewModelPlayer> playersViewModel = Map.MapPlayersList(playersList);
            return playersViewModel;
        }
    }
}
