using System;
using System.Collections.Generic;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SubstitutionSystem.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private List<Player> _players;
        private string[] _runningBackNames;
        private string[] _qbNames;

        [TestInitialize]
        public void Initialize()
        {
            _players = new List<Player>();
            _runningBackNames = new string[]
            {
                "Lev Bell",
                "Todd Gurley",
                "David Johnson",
                "Ezekiel Elliott",
                "Alvin Kamara",
                "Saquon Barkley",
                "Kareem Hunt",
                "Dalvin Cook",
                "Leonard Fournette",
                "Melvin Gordon",
                "LeSean McCoy",
                "Christian McCaffrey",
                "Devonta Freeman",
                "Jerick McKinnon"
            };

            _qbNames = new string[]
            {
                "Aaron Rodgers",
                "Tom Brady",
                "Russell Wilson",
                "Carson Wentz",
                "Cam Newton",
                "Deshaun Watson",
                "Kirk Cousins",
                "Drew Brees",
                "Andrew Luck",
                "Matthew Stafford",
                "Ben Roethlisberger",
                "Jimmy Garoppolo",
            };
        }

        [TestCleanup]
        public void Cleanup()
        {
            //write report to hand validate
        }

        [TestMethod]
        public void TestNoSubs()
        {

        }

        private Player MakePlayer(decimal points, PositionEnum position, bool starting, int originalIndex, string firstname = "", string lastname = "")
        {
            var runningBackName = firstname == "" ? GetRunningBack() : "";

            return new Player
            {
                //Get Correct player and position
                FirstName = firstname == "" ? runningBackName.Split(' ')[0] : firstname,
                LastName = lastname == "" ? runningBackName.Split(' ')[1] : lastname,
                Points = points,
                Position = position,
                Starting = starting,
                OriginalIndex = originalIndex
            };
        }

        private string GetRunningBack()
        {
            var random = new Random();
            int randomNumber = random.Next(_runningBackNames.Length);
            _runningBackNames.RemoveAt(randomNumber);

            return _runningBackNames[randomNumber];
        }

        private string GetQuarterBack()
        {
            var random = new Random();
            int randomNumber = random.Next(_qbNames.Length);
            _qbNames.RemoveAt(randomNumber);

            return _qbNames[randomNumber];
        }
    }
}
