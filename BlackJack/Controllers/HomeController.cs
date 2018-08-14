using BLL.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlackJack.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            GameSetService gameSetService = new GameSetService();
            var cardsList = await gameSetService.SetDeck();
            return View(cardsList);
        }

        [HttpGet]
        public async Task<ActionResult> About()
        {
            GameSetService gameSetService = new GameSetService();
            var players = await gameSetService.SetPlayers();
            GameLogicService gameLogicService = new GameLogicService();
            await gameLogicService.GiveCardsOnStart();
            players = await gameSetService.SetPlayers();

            //return Json(players, JsonRequestBehavior.AllowGet);
            return View(players);
        }

        public async Task<ActionResult> Contact()
        {
            GameSetService gameSetService = new GameSetService();
            var playersViewModel = await gameSetService.GetAllPlayers();

            return View(playersViewModel);
        }

        public async Task<ActionResult> DrawCard()
        {
            GameLogicService gameLogicService = new GameLogicService();
            await gameLogicService.GiveCards();
            return RedirectToAction("Contact");
        }
    }
}