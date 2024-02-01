namespace PONG_CON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game.ScrollbarRemoval();
            Game.SetInitialPositions();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key_info = Console.ReadKey();

                    if (key_info.Key == ConsoleKey.UpArrow)
                        Game.PlayerTwoUp();

                    if (key_info.Key == ConsoleKey.DownArrow)
                        Game.PlayerTwoDown();

                    if (key_info.Key == ConsoleKey.W)
                        Game.PlayerOneUp();

                    if (key_info.Key == ConsoleKey.S)
                        Game.PlayerOneDown();
                }

                Game.MoveBall();
                Console.Clear();
                Game.DrawPlayerOne();
                Game.DrawPlayerTwo();
                Game.DrawBall();

                Thread.Sleep(60);
            }
        }
    }
}
