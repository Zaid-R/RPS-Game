using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSGame
{
    public class Player
    {
        public string Name { get; }
        public int RoundScore { get; set; }
        public int Score { get; set; }

        public Player()
        {
            Console.WriteLine("Enter your name:");
            string inputName;
            while (string.IsNullOrEmpty(inputName = Console.ReadLine()))
            {
                Console.WriteLine("Enter your name:");
            }
            Name = inputName.Trim();
        }

        // Internal constructor for testing
        public Player(string name)
        {
            Name = name;
        }
    }
}
