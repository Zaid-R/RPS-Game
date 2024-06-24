using System;
using Xunit;
using RPSGame;

namespace RPSGameTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestWinnerDetermination()
        {
            // Reset the game state for a clean test environment
            RPSGame.RPSGame.ResetGameState();

            // Initialize a player for testing
            var player = new Player("TestPlayer");

            // Set player field for testing
            typeof(RPSGame.RPSGame).GetField("player", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).SetValue(null, player);

            // Test Player wins
            RPSGame.RPSGame.compareMoves("r", "s");
            Assert.Equal(1, player.RoundScore);
            Assert.Equal(0, (int)typeof(RPSGame.RPSGame).GetField("AIRoundScore", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null));

            // Test AI wins
            RPSGame.RPSGame.compareMoves("s", "r");
            Assert.Equal(1, (int)typeof(RPSGame.RPSGame).GetField("AIRoundScore", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null));

            // Test Draw
            RPSGame.RPSGame.compareMoves("p", "p");
            Assert.Equal(2, player.RoundScore);
            Assert.Equal(2, (int)typeof(RPSGame.RPSGame).GetField("AIRoundScore", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null));
        }

        [Fact]
        public void TestScoreUpdate()
        {
            // Reset the game state for a clean test environment
            RPSGame.RPSGame.ResetGameState();

            // Initialize a player for testing
            var player = new Player("TestPlayer");

            // Set player field for testing
            typeof(RPSGame.RPSGame).GetField("player", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).SetValue(null, player);

            // Set initial round score
            player.RoundScore = 3;
            RPSGame.RPSGame.play();
            Assert.Equal(0, player.RoundScore);

            typeof(RPSGame.RPSGame).GetField("AIRoundScore", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).SetValue(null, 3);
            RPSGame.RPSGame.play();
            Assert.Equal(0, (int)typeof(RPSGame.RPSGame).GetField("AIRoundScore", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null));
        }
    }
}
