using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    public class HomeController : Controller
    {
        private static Board board;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void StartNewGame(string name1, string name2)
        {
            Player player1 = new Player
            {
                Name = name1
            };
            Player player2 = new Player
            {
                Name = name2
            };

            board = new Board(player1, player2);
        }

        [HttpPost]
        public void PlayAgain()
        {
            board.ClearBoard();
            board.IsDraw = false;
            board.GameOver = false;
        }

        [HttpPost]
        public void Move(int player, int position)
        {
            board.MakeMove(player, position);
        }

        [HttpGet]
        public JsonResult CheckStatus()
        {
            var result = JsonConvert.SerializeObject(new List<bool>
            {
                board.GameOver,
                board.IsDraw
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}