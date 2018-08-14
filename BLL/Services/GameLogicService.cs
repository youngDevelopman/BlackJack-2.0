using BLL.Repositories;
using DAL.Entities;
using System;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GameLogicService
    {
        static Random random;
        Repository<Player> playerRepository;
        Repository<Card> cardRepository;

        public GameLogicService()
        {
            playerRepository = new Repository<Player>(new DAL.BlackJackContext());
            cardRepository = new Repository<Card>(new DAL.BlackJackContext());
            random = new Random();
        }

        public async Task GiveCardsOnStart()
        {
            foreach(var p in await playerRepository.Get())
            {
                for (int i = 0; i < 2; i++)
                {
                    Card card = cardRepository.Pop();
                    p.Cards.Add(card);
                }
            }
        }

        public async Task GiveCards()
        {
            foreach(var p in await playerRepository.Get())
            {
                Card card = cardRepository.Pop();
                p.Cards.Add(card);
            }
        }
    }
}
