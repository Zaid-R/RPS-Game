using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSGame
{
    public class RPSGame
    {
        private static int score;
        private static int AIRoundScore;
        private static Player player;

        public static void play()
        {
            Random random = new Random();
            Console.WriteLine("Welcome to RPS game\nA quick guide:\n1. Press r for Rock\n2. Press p for Paper\n3. Press s for Scissor\n4. You have to win 3 rounds before your opponent to win the game");
            player = player ?? new Player();
            // A game
            while (score < 3 && player.Score < 3)
            {
                string[] moves = { "r", "p", "s" };
                string[] movesNames = { "Rock", "Paper", "Scissor" };

                //for test purpose
                if (AIRoundScore == player.RoundScore && player.RoundScore == 0)
                {
                    // A round
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine("choose your move [r / p / s]:");
                        string playerMove;
                        while (string.IsNullOrEmpty(playerMove = Console.ReadLine()) || !moves.Contains(playerMove = playerMove?.Trim().ToLower()))
                        {
                            Console.WriteLine("choose your move [r / p / s]:");
                        }
                        string AIMove = moves[random.Next(0, moves.Length)];
                        Console.WriteLine($"AI move : {movesNames[Array.IndexOf(moves, AIMove)]} | Your move : {movesNames[Array.IndexOf(moves, playerMove)]}");
                        compareMoves(playerMove, AIMove);
                        revealScore(false);
                    }
                    revealWinner(false);
                }else
                {
                    AIRoundScore = 0;
                    player.RoundScore = 0;
                    break;
                }

                if (player.RoundScore < AIRoundScore)
                {
                    score++;
                }
                else if (AIRoundScore < player.RoundScore)
                {
                    player.Score++;
                }
                else
                {
                    score++;
                    player.Score++;
                }
                AIRoundScore = 0;
                player.RoundScore = 0;
            }
            // Decide the winner
            revealWinner(true);
        }

        public static void compareMoves(string playerMove, string AIMove)
        {
            switch ((playerMove, AIMove))
            {
                case ("s", "s"):
                case ("p", "p"):
                case ("r", "r"):
                    AIRoundScore++;
                    player.RoundScore++;
                    break;
                case ("s", "r"):
                case ("r", "p"):
                case ("p", "s"):
                    AIRoundScore++;
                    break;
                case ("r", "s"):
                case ("p", "r"):
                case ("s", "p"):
                    player.RoundScore++;
                    break;
            }
        }

        internal static void revealScore(bool isFinalScore)
        {
            Console.WriteLine($"{player.Name}: {(isFinalScore ? player.Score : player.RoundScore)} | AI : {(isFinalScore ? score : AIRoundScore)}");
        }

        internal static void revealWinner(bool isFinalScore)
        {
            int AIScore = isFinalScore ? score : AIRoundScore;
            int playerScore = isFinalScore ? player.Score : player.RoundScore;
            int result = 0;
            if (AIScore < playerScore)
            {
                result = 1;
            }
            else if (AIScore == playerScore)
            {
                result = 2;
            }
            string winner = result == 0 ? "AI" : player.Name;
            string text = isFinalScore ? "!" : " of this round!";
            Console.WriteLine("=========================");
            if (isFinalScore)
            {
                Console.WriteLine("Final score:");
                revealScore(isFinalScore);
            }

            if (result == 2)
            {
                Console.WriteLine("Draw");
            }
            else
            {
                Console.WriteLine($"{winner} is the winner{text}");
            }
            Console.WriteLine("=========================");
        }

        // Method to reset the state for testing
        public static void ResetGameState()
        {
            score = 0;
            AIRoundScore = 0;
            player = null;
        }
    }
}
