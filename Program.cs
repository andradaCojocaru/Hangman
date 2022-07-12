namespace Hangman_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Show();
            GameState gameState = GameState.InProgress;

            while (gameState == GameState.InProgress)
            {
                string input = Console.ReadLine();
                gameState = game.UpdateStateGame(char.Parse(input));

                if (gameState == GameState.Won)
                {
                    Console.WriteLine("Ai castigat !!!");
                } else if (gameState == GameState.Lost) {
                    Console.WriteLine("Ai pierdut !!!");
                    Console.WriteLine("Cuvantul era " + game.MyWord);
                }
            }
        }
    }
}