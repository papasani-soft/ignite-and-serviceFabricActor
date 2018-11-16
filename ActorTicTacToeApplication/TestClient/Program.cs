using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            var player1 = ActorProxy.Create<IPlayer>(ActorId.NewId(),
            "fabric:/ActorTicTacToeApplication");
            var player2 = ActorProxy.Create<IPlayer>(ActorId.NewId(),
            "fabric:/ActorTicTacToeApplication");
            var gameId = ActorId.NewId();
            var game = ActorProxy.Create<IGame>(gameId, "fabric:/ActorTicTacToeApplication");
            var rand = new Random();
            var result1 = player1.JoinGameAsync(gameId, "Player 1");
            var result2 = player2.JoinGameAsync(gameId, "Player 2");
            if (!result1.Result || !result2.Result)
            {
                Console.WriteLine("Failed to join game.");
                return;
            }
            var player1Task = Task.Run(() => { MakeMove(player1, game, gameId); });
            var player2Task = Task.Run(() => { MakeMove(player2, game, gameId); });
            var gameTask = Task.Run(() =>
            {
                string winner = "";
                while (winner == "")
                {
                    var board = game.GetGameBoardAsync().Result;
                    PrintBoard(board);
                    winner = game.GetWinnerAsync().Result;
                    Task.Delay(1000).Wait();
                }
                Console.WriteLine("Winner is: " + winner);
            });
            gameTask.Wait();
            Console.Read();
        }
    }
}
