using BLL.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlackJack.Controllers
{
    public class HomeController : Controller
    {
        GameSetService gameSetService;
        GameLogicService gameLogicService;


        public HomeController(GameSetService gameSet, GameLogicService gameLogic)
        {
            gameSetService = gameSet;
            gameLogicService = gameLogic;
        }

        public async Task<ActionResult> Index()
        {
            var cardsList = await gameSetService.SetDeck();
            return View(cardsList);
        }

        
        public async Task<ActionResult> About()
        {
            var players = await gameSetService.SetPlayers();
            var playersViewModel = await gameSetService.GiveCardsOnStart();
            return View(playersViewModel);
        }

        public async Task<ActionResult> Contact()
        {
            var playersViewModel = await gameLogicService.GetAllPlayers();

            return View(playersViewModel);
        }

        //public async Task<ActionResult> DrawCard()
        //{
        //    GameLogicService gameLogicService = new GameLogicService();
        //    await gameLogicService.GiveCards();
        //    return RedirectToAction("Contact");
        //}
    }
}