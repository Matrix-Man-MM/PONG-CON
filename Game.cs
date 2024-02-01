using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PONG_CON
{
    public class Game
    {
        static int player_one_pad_size = 4;
        static int player_two_pad_size = 4;

        static int ball_pos_X = 0;
        static int ball_pos_Y = 0;

        static bool ball_dir_up = true;
        static bool ball_dir_right = false;

        static int player_one_pos = 0;
        static int player_two_pos = 0;

        static int player_one_score = 0;
        static int player_two_score = 0;

        static Random rand = new Random();

        public static void ScrollbarRemoval()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        public static void DrawPlayerOne()
        {
            for (int i = player_one_pos; i < player_one_pos + player_one_pad_size; i++)
                PrintAtPos(0, i, '|');
        }

        public static void DrawPlayerTwo()
        {
            for (int i = player_two_pos; i < player_two_pos + player_two_pad_size; i++)
                PrintAtPos(Console.WindowWidth - 1, i, '|');
        }

        public static void PrintAtPos(int x, int y, char c)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        public static void SetInitialPositions()
        {
            player_one_pos = (Console.WindowHeight / 2) - (player_one_pad_size / 2);
            player_two_pos = (Console.WindowHeight / 2) - (player_two_pad_size / 2);
            SetBallMiddle();
        }

        public static void SetBallMiddle()
        {
            ball_pos_X = Console.WindowWidth / 2;
            ball_pos_Y = Console.WindowHeight / 2;
        }

        public static void DrawBall()
        {
            PrintAtPos(ball_pos_X, ball_pos_Y, 'O');
        }

        public static void PlayerOneDown()
        {
            if (player_one_pos < Console.WindowHeight - player_one_pad_size)
                player_one_pos++;
        }

        public static void PlayerOneUp()
        {
            if (player_one_pos > 0)
                player_one_pos--;
        }

        public static void PlayerTwoDown()
        {
            if (player_two_pos < Console.WindowHeight - player_two_pad_size)
                player_two_pos++;
        }

        public static void PlayerTwoUp()
        {
            if (player_two_pos > 0)
                player_two_pos--;
        }

        public static void MoveBall()
        {
            if (ball_pos_Y == 0)
                ball_dir_up = false;

            if (ball_pos_Y == Console.WindowHeight - 1)
                ball_dir_up = true;

            if (ball_pos_X == Console.WindowWidth - 1)
            {
                SetBallMiddle();

                ball_dir_right = false;
                ball_dir_up = true;

                player_one_score++;

                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.Write("Player One Wins!");
                Console.ReadKey();
            }

            if (ball_pos_X == 0)
            {
                SetBallMiddle();

                ball_dir_right = true;
                ball_dir_up = true;

                player_two_score++;

                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.Write("Player Two Wins!");
                Console.ReadKey();
            }

            if (ball_pos_X < 3)
                if (ball_pos_Y >= player_one_pos && ball_pos_Y < player_one_pos + player_one_pad_size)
                    ball_dir_right = true;

            if (ball_pos_X >= Console.WindowWidth - 3 - 1)
                if (ball_pos_Y >= player_two_pos && ball_pos_Y < player_two_pos + player_two_pad_size)
                    ball_dir_right = false;

            if (ball_dir_up)
                ball_pos_Y--;
            else
                ball_pos_Y++;

            if (ball_dir_right)
                ball_pos_X++;
            else
                ball_pos_X--;
        }
    }
}
