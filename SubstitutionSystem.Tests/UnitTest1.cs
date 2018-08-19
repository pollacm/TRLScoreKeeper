using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TRL.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private List<Player> _players;
        private string[] _runningBackNames;
        private string[] _qbNames;
        private string[] _wrNames;
        private string[] _teNames;
        private string[] _kNames;
        private string[] _dbNames;
        private string[] _dlNames;
        private string[] _lbNames;


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

            _wrNames = new string[]
            {
                "Antonio Brown",
                "DeAndre Hopkins",
                "Odell Beckham Jr.",
                "Julio Jones",
                "Keenan Allen",
                "Michael Thomas",
                "A.J. Green",
                "Davante Adams",
                "Mike Evans",
                "T.Y. Hilton",
                "Adam Thielen",
                "Stefon Diggs",
            };

            _teNames = new string[]
            {
                "Rob Gronkowski",
                "Travis Kelce",
                "Zach Ertz",
                "Greg Olsen",
                "Delanie Walker",
                "Evan Engram",
                "Jimmy Graham",
                "Kyle Rudolph",
                "Jordan Reed",
                "Jack Doyle",
                "David Njoku",
                "Trey Burton"
            };

            _kNames = new string[]
            {
                "Stephen Gostkowski",
                "Greg Zuerlein",
                "Justin Tucker",
                "Chris Boswell",
                "Dan Bailey",
                "Matt Bryant",
                "Mason Crosby",
                "Wil Lutz",
                "Daniel Carlson",
                "Jake Elliott",
                "Adam Vinatieri",
                "Robbie Gould",
            };

            _dlNames = new string[]
            {
                "J.J. Watt",
                "Khalil Mack*",
                "Joey Bosa",
                "Chandler Jones",
                "Trey Flowers",
                "Myles Garrett",
                "Kawann Short",
                "Aaron Donald",
                "Jurrell Casey",
                "Damon Harrison",
                "Gerald McCoy",
                "Grady Jarrett",
            };

            _dbNames = new string[]
            {
                "Marshon Lattimore",
                "Tre'Davious White",
                "Josh Norman",
                "A.J. Bouye",
                "Marcus Peters",
                "Jalen Ramsey",
                "Budda Baker",
                "Reshad Jones",
                "Landon Collins",
                "Karl Joseph",
                "Keanu Neal",
                "Jordan Poyer",
            };

            _lbNames = new string[]
            {
                "Luke Kuechly",
                "Zach Brown",
                "Sean Lee",
                "Blake Martinez",
                "Bobby Wagner",
                "Telvin Smith",
                "Kwon Alexander",
                "C.J. Mosley",
                "Lavonte David",
                "Denzel Perryman",
                "Deion Jones",
                "Von Miller",
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
            //QB
            //WR
            //RB
            //WR
            //RB
            //Kicker
            //DL
            //DB
            //LB
            //D
            //LB
            //QB
            //WR
            //RB
            //RB

            var players = new Player[]
            {
                MakePlayer(150, PositionEnum.QB, true, 1, "PlayerQB1", "PlayerQB1Last"),
                MakePlayer(150, PositionEnum.WR, true, 2, "PlayerWR1", "PlayerWR1Last"),
                MakePlayer(150, PositionEnum.RB, true, 3, "PlayerRB1", "PlayerRB1Last"),
                MakePlayer(150, PositionEnum.RB, true, 4, "PlayerRB2", "PlayerRB2Last"),
                MakePlayer(150, PositionEnum.WR, true, 5, "PlayerWR2", "PlayerWR2Last"),
                MakePlayer(150, PositionEnum.K, true, 6, "PlayerK1", "PlayerK1Last"),

                MakePlayer(130, PositionEnum.DL, true, 7, "PlayerDL1", "PlayerDL1Last"),
                MakePlayer(130, PositionEnum.DB, true, 8, "PlayerDB1", "PlayerDB1Last"),
                MakePlayer(130, PositionEnum.LB, true, 9, "PlayerLB1", "PlayerLB1Last"),
                MakePlayer(130, PositionEnum.LB, true, 10, "PlayerLB2", "PlayerLB2Last"),

                MakePlayer(100, PositionEnum.LB, false, 11, "PlayerLBBench1", "PlayerLBBench1Last"),
                MakePlayer(100, PositionEnum.QB, false, 12, "PlayerQBBench1", "PlayerQBBench1Last"),
                MakePlayer(100, PositionEnum.WR, false, 13, "PlayerWRBench1", "PlayerWRBench1Last"),
                MakePlayer(100, PositionEnum.RB, false, 14, "PlayerRBBench1", "PlayerRBBench1Last"),
                MakePlayer(100, PositionEnum.RB, false, 15, "PlayerRBBench2", "PlayerRBBench2Last")
            };

            var swapHelper = new PlayerSwapper();
            var updatedPlayers = swapHelper.GetUpdatedPlayers(players);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.Position == PositionEnum.QB && p.Starting && p.OriginalIndex == 1 && p.FirstName == "PlayerQB1" && p.LastName == "PlayerQB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.Position == PositionEnum.WR && p.Starting && p.OriginalIndex == 2 && p.FirstName == "PlayerWR1" && p.LastName == "PlayerWR1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 3 && p.FirstName == "PlayerRB1" && p.LastName == "PlayerRB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 4 && p.FirstName == "PlayerRB2" && p.LastName == "PlayerRB2Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.Position == PositionEnum.WR && p.Starting && p.OriginalIndex == 5 && p.FirstName == "PlayerWR2" && p.LastName == "PlayerWR2Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.Position == PositionEnum.K && p.Starting && p.OriginalIndex == 6 && p.FirstName == "PlayerK1" && p.LastName == "PlayerK1Last") == 1);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.Position == PositionEnum.DL && p.Starting && p.OriginalIndex == 7 && p.FirstName == "PlayerDL1" && p.LastName == "PlayerDL1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.Position == PositionEnum.DB && p.Starting && p.OriginalIndex == 8 && p.FirstName == "PlayerDB1" && p.LastName == "PlayerDB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.Position == PositionEnum.LB && p.Starting && p.OriginalIndex == 9 && p.FirstName == "PlayerLB1" && p.LastName == "PlayerLB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.Position == PositionEnum.LB && p.Starting && p.OriginalIndex == 10 && p.FirstName == "PlayerLB2" && p.LastName == "PlayerLB2Last") == 1);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 100 && p.Position == PositionEnum.LB && !p.Starting && p.OriginalIndex == 11 && p.FirstName == "PlayerLBBench1" && p.LastName == "PlayerLBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 100 && p.Position == PositionEnum.QB && !p.Starting && p.OriginalIndex == 12 && p.FirstName == "PlayerQBBench1" && p.LastName == "PlayerQBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 100 && p.Position == PositionEnum.WR && !p.Starting && p.OriginalIndex == 13 && p.FirstName == "PlayerWRBench1" && p.LastName == "PlayerWRBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 100 && p.Position == PositionEnum.RB && !p.Starting && p.OriginalIndex == 14 && p.FirstName == "PlayerRBBench1" && p.LastName == "PlayerRBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 100 && p.Position == PositionEnum.RB && !p.Starting && p.OriginalIndex == 15 && p.FirstName == "PlayerRBBench2" && p.LastName == "PlayerRBBench2Last") == 1);
        }

        [TestMethod]
        public void TestSingleSwap()
        {
            //QB
            //WR
            //RB
            //WR
            //RB
            //Kicker
            //DL
            //DB
            //LB
            //D
            //LB
            //QB
            //WR
            //RB
            //RB

            var players = new Player[]
            {
                MakePlayer(150, PositionEnum.QB, true, 1, "PlayerQB1", "PlayerQB1Last"),
                MakePlayer(150, PositionEnum.WR, true, 2, "PlayerWR1", "PlayerWR1Last"),
                MakePlayer(150, PositionEnum.RB, true, 3, "PlayerRB1", "PlayerRB1Last"),
                MakePlayer(150, PositionEnum.RB, true, 4, "PlayerRB2", "PlayerRB2Last"),
                MakePlayer(150, PositionEnum.WR, true, 5, "PlayerWR2", "PlayerWR2Last"),
                MakePlayer(150, PositionEnum.K, true, 6, "PlayerK1", "PlayerK1Last"),

                MakePlayer(130, PositionEnum.DL, true, 7, "PlayerDL1", "PlayerDL1Last"),
                MakePlayer(130, PositionEnum.DB, true, 8, "PlayerDB1", "PlayerDB1Last"),
                MakePlayer(130, PositionEnum.LB, true, 9, "PlayerLB1", "PlayerLB1Last"),
                MakePlayer(130, PositionEnum.LB, true, 10, "PlayerLB2", "PlayerLB2Last"),

                MakePlayer(100, PositionEnum.LB, false, 11, "PlayerLBBench1", "PlayerLBBench1Last"),
                MakePlayer(250, PositionEnum.QB, false, 12, "PlayerQBBench1", "PlayerQBBench1Last"),
                MakePlayer(100, PositionEnum.WR, false, 13, "PlayerWRBench1", "PlayerWRBench1Last"),
                MakePlayer(100, PositionEnum.RB, false, 14, "PlayerRBBench1", "PlayerRBBench1Last"),
                MakePlayer(100, PositionEnum.RB, false, 15, "PlayerRBBench2", "PlayerRBBench2Last")
            };

            var swapHelper = new PlayerSwapper();
            var updatedPlayers = swapHelper.GetUpdatedPlayers(players);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 150 && p.Position == PositionEnum.QB && !p.Starting && p.OriginalIndex == 1 && p.FirstName == "PlayerQB1" && p.LastName == "PlayerQB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 0 && p.Position == PositionEnum.WR && p.Starting && p.OriginalIndex == 2 && p.FirstName == "PlayerWR1" && p.LastName == "PlayerWR1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 0 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 3 && p.FirstName == "PlayerRB1" && p.LastName == "PlayerRB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 0 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 4 && p.FirstName == "PlayerRB2" && p.LastName == "PlayerRB2Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 0 && p.Position == PositionEnum.WR && p.Starting && p.OriginalIndex == 5 && p.FirstName == "PlayerWR2" && p.LastName == "PlayerWR2Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 0 && p.Position == PositionEnum.K && p.Starting && p.OriginalIndex == 6 && p.FirstName == "PlayerK1" && p.LastName == "PlayerK1Last") == 1);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.PointsUpdated == 0  && p.Position == PositionEnum.DL && p.Starting && p.OriginalIndex == 7 && p.FirstName == "PlayerDL1" && p.LastName == "PlayerDL1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.PointsUpdated == 0  && p.Position == PositionEnum.DB && p.Starting && p.OriginalIndex == 8 && p.FirstName == "PlayerDB1" && p.LastName == "PlayerDB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.PointsUpdated == 0  && p.Position == PositionEnum.LB && p.Starting && p.OriginalIndex == 9 && p.FirstName == "PlayerLB1" && p.LastName == "PlayerLB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.PointsUpdated == 0  && p.Position == PositionEnum.LB && p.Starting && p.OriginalIndex == 10 && p.FirstName == "PlayerLB2" && p.LastName == "PlayerLB2Last") == 1);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 100 && p.PointsUpdated == 0 && p.Position == PositionEnum.LB && !p.Starting && p.OriginalIndex == 11 && p.FirstName == "PlayerLBBench1" && p.LastName == "PlayerLBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 250 && p.PointsUpdated == 250 && p.Position == PositionEnum.QB && p.Starting && p.OriginalIndex == 12 && p.FirstName == "PlayerQBBench1" && p.LastName == "PlayerQBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 100 && p.PointsUpdated == 0 && p.Position == PositionEnum.WR && !p.Starting && p.OriginalIndex == 13 && p.FirstName == "PlayerWRBench1" && p.LastName == "PlayerWRBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 100 && p.PointsUpdated == 0 && p.Position == PositionEnum.RB && !p.Starting && p.OriginalIndex == 14 && p.FirstName == "PlayerRBBench1" && p.LastName == "PlayerRBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 100 && p.PointsUpdated == 0 && p.Position == PositionEnum.RB && !p.Starting && p.OriginalIndex == 15 && p.FirstName == "PlayerRBBench2" && p.LastName == "PlayerRBBench2Last") == 1);
        }

        [TestMethod]
        public void TestAllSwap()
        {
            //QB
            //WR
            //RB
            //WR
            //RB
            //Kicker
            //DL
            //DB
            //LB
            //D
            //LB
            //QB
            //WR
            //RB
            //RB

            var players = new Player[]
            {
                MakePlayer(150, PositionEnum.QB, true, 1, "PlayerQB1", "PlayerQB1Last"),
                MakePlayer(150, PositionEnum.WR, true, 2, "PlayerWR1", "PlayerWR1Last"),
                MakePlayer(125, PositionEnum.RB, true, 3, "PlayerRB1", "PlayerRB1Last"),
                MakePlayer(150, PositionEnum.RB, true, 4, "PlayerRB2", "PlayerRB2Last"),
                MakePlayer(150, PositionEnum.WR, true, 5, "PlayerWR2", "PlayerWR2Last"),
                MakePlayer(150, PositionEnum.K, true, 6, "PlayerK1", "PlayerK1Last"),

                MakePlayer(130, PositionEnum.DL, true, 7, "PlayerDL1", "PlayerDL1Last"),
                MakePlayer(130, PositionEnum.DB, true, 8, "PlayerDB1", "PlayerDB1Last"),
                MakePlayer(140, PositionEnum.LB, true, 9, "PlayerLB1", "PlayerLB1Last"),
                MakePlayer(130, PositionEnum.LB, true, 10, "PlayerLB2", "PlayerLB2Last"),

                MakePlayer(250, PositionEnum.LB, false, 11, "PlayerLBBench1", "PlayerLBBench1Last"),
                MakePlayer(250, PositionEnum.QB, false, 12, "PlayerQBBench1", "PlayerQBBench1Last"),
                MakePlayer(250, PositionEnum.WR, false, 13, "PlayerWRBench1", "PlayerWRBench1Last"),
                MakePlayer(250, PositionEnum.RB, false, 14, "PlayerRBBench1", "PlayerRBBench1Last"),
                MakePlayer(250, PositionEnum.RB, false, 15, "PlayerRBBench2", "PlayerRBBench2Last")
            };

            var swapHelper = new PlayerSwapper();
            var updatedPlayers = swapHelper.GetUpdatedPlayers(players);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 150 && p.Position == PositionEnum.QB && !p.Starting && p.OriginalIndex == 1 && p.FirstName == "PlayerQB1" && p.LastName == "PlayerQB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 150 && p.Position == PositionEnum.WR && !p.Starting && p.OriginalIndex == 2 && p.FirstName == "PlayerWR1" && p.LastName == "PlayerWR1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 125 && p.PointsUpdated == 125 && p.Position == PositionEnum.RB && !p.Starting && p.OriginalIndex == 3 && p.FirstName == "PlayerRB1" && p.LastName == "PlayerRB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 150 && p.Position == PositionEnum.RB && !p.Starting && p.OriginalIndex == 4 && p.FirstName == "PlayerRB2" && p.LastName == "PlayerRB2Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 0 && p.Position == PositionEnum.WR && p.Starting && p.OriginalIndex == 5 && p.FirstName == "PlayerWR2" && p.LastName == "PlayerWR2Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 0 && p.Position == PositionEnum.K && p.Starting && p.OriginalIndex == 6 && p.FirstName == "PlayerK1" && p.LastName == "PlayerK1Last") == 1);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.PointsUpdated == 0 && p.Position == PositionEnum.DL && p.Starting && p.OriginalIndex == 7 && p.FirstName == "PlayerDL1" && p.LastName == "PlayerDL1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.PointsUpdated == 0 && p.Position == PositionEnum.DB && p.Starting && p.OriginalIndex == 8 && p.FirstName == "PlayerDB1" && p.LastName == "PlayerDB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 140 && p.PointsUpdated == 0 && p.Position == PositionEnum.LB && p.Starting && p.OriginalIndex == 9 && p.FirstName == "PlayerLB1" && p.LastName == "PlayerLB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.PointsUpdated == 130 && p.Position == PositionEnum.LB && !p.Starting && p.OriginalIndex == 10 && p.FirstName == "PlayerLB2" && p.LastName == "PlayerLB2Last") == 1);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 250 && p.PointsUpdated == 250 && p.Position == PositionEnum.LB && p.Starting && p.OriginalIndex == 11 && p.FirstName == "PlayerLBBench1" && p.LastName == "PlayerLBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 250 && p.PointsUpdated == 250 && p.Position == PositionEnum.QB && p.Starting && p.OriginalIndex == 12 && p.FirstName == "PlayerQBBench1" && p.LastName == "PlayerQBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 250 && p.PointsUpdated == 250 && p.Position == PositionEnum.WR && p.Starting && p.OriginalIndex == 13 && p.FirstName == "PlayerWRBench1" && p.LastName == "PlayerWRBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 250 && p.PointsUpdated == 250 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 14 && p.FirstName == "PlayerRBBench1" && p.LastName == "PlayerRBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 250 && p.PointsUpdated == 250 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 15 && p.FirstName == "PlayerRBBench2" && p.LastName == "PlayerRBBench2Last") == 1);
        }

        [TestMethod]
        public void TestCrossPositionSwapSingle()
        {
            //QB
            //WR
            //RB
            //WR
            //RB
            //Kicker
            //DL
            //DB
            //LB
            //D
            //LB
            //QB
            //WR
            //RB
            //RB

            var players = new Player[]
            {
                MakePlayer(150, PositionEnum.QB, true, 1, "PlayerQB1", "PlayerQB1Last"),
                MakePlayer(150, PositionEnum.WR, true, 2, "PlayerWR1", "PlayerWR1Last"),
                MakePlayer(150, PositionEnum.RB, true, 3, "PlayerRB1", "PlayerRB1Last"),
                MakePlayer(150, PositionEnum.RB, true, 4, "PlayerRB2", "PlayerRB2Last"),
                MakePlayer(30, PositionEnum.WR, true, 5, "PlayerWR2", "PlayerWR2Last"),
                MakePlayer(150, PositionEnum.K, true, 6, "PlayerK1", "PlayerK1Last"),

                MakePlayer(130, PositionEnum.DL, true, 7, "PlayerDL1", "PlayerDL1Last"),
                MakePlayer(130, PositionEnum.DB, true, 8, "PlayerDB1", "PlayerDB1Last"),
                MakePlayer(130, PositionEnum.LB, true, 9, "PlayerLB1", "PlayerLB1Last"),
                MakePlayer(130, PositionEnum.LB, true, 10, "PlayerLB2", "PlayerLB2Last"),

                MakePlayer(100, PositionEnum.LB, false, 11, "PlayerLBBench1", "PlayerLBBench1Last"),
                MakePlayer(100, PositionEnum.QB, false, 12, "PlayerQBBench1", "PlayerQBBench1Last"),
                MakePlayer(30, PositionEnum.WR, false, 13, "PlayerWRBench1", "PlayerWRBench1Last"),
                MakePlayer(150, PositionEnum.RB, false, 14, "PlayerRBBench1", "PlayerRBBench1Last"),
                MakePlayer(100, PositionEnum.RB, false, 15, "PlayerRBBench2", "PlayerRBBench2Last")
            };

            var swapHelper = new PlayerSwapper();
            var updatedPlayers = swapHelper.GetUpdatedPlayers(players);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.Position == PositionEnum.QB && p.Starting && p.OriginalIndex == 1 && p.FirstName == "PlayerQB1" && p.LastName == "PlayerQB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.Position == PositionEnum.WR && p.Starting && p.OriginalIndex == 2 && p.FirstName == "PlayerWR1" && p.LastName == "PlayerWR1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 3 && p.FirstName == "PlayerRB1" && p.LastName == "PlayerRB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 4 && p.FirstName == "PlayerRB2" && p.LastName == "PlayerRB2Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 30 && p.Position == PositionEnum.WR && !p.Starting && p.OriginalIndex == 5 && p.FirstName == "PlayerWR2" && p.LastName == "PlayerWR2Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.Position == PositionEnum.K && p.Starting && p.OriginalIndex == 6 && p.FirstName == "PlayerK1" && p.LastName == "PlayerK1Last") == 1);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.Position == PositionEnum.DL && p.Starting && p.OriginalIndex == 7 && p.FirstName == "PlayerDL1" && p.LastName == "PlayerDL1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.Position == PositionEnum.DB && p.Starting && p.OriginalIndex == 8 && p.FirstName == "PlayerDB1" && p.LastName == "PlayerDB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.Position == PositionEnum.LB && p.Starting && p.OriginalIndex == 9 && p.FirstName == "PlayerLB1" && p.LastName == "PlayerLB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.Position == PositionEnum.LB && p.Starting && p.OriginalIndex == 10 && p.FirstName == "PlayerLB2" && p.LastName == "PlayerLB2Last") == 1);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 100 && p.Position == PositionEnum.LB && !p.Starting && p.OriginalIndex == 11 && p.FirstName == "PlayerLBBench1" && p.LastName == "PlayerLBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 100 && p.Position == PositionEnum.QB && !p.Starting && p.OriginalIndex == 12 && p.FirstName == "PlayerQBBench1" && p.LastName == "PlayerQBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 30 && p.Position == PositionEnum.WR && !p.Starting && p.OriginalIndex == 13 && p.FirstName == "PlayerWRBench1" && p.LastName == "PlayerWRBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 90 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 14 && p.FirstName == "PlayerRBBench1" && p.LastName == "PlayerRBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 100 && p.Position == PositionEnum.RB && !p.Starting && p.OriginalIndex == 15 && p.FirstName == "PlayerRBBench2" && p.LastName == "PlayerRBBench2Last") == 1);
        }

        [TestMethod]
        public void TestCrossPositionSwapAll()
        {
            //QB
            //WR
            //RB
            //WR
            //RB
            //Kicker
            //DL
            //DB
            //LB
            //D
            //LB
            //QB
            //WR
            //RB
            //RB

            var players = new Player[]
            {
                MakePlayer(150, PositionEnum.QB, true, 1, "PlayerQB1", "PlayerQB1Last"),
                MakePlayer(20, PositionEnum.WR, true, 2, "PlayerWR1", "PlayerWR1Last"),
                MakePlayer(300, PositionEnum.RB, true, 3, "PlayerRB1", "PlayerRB1Last"),
                MakePlayer(280, PositionEnum.RB, true, 4, "PlayerRB2", "PlayerRB2Last"),
                MakePlayer(40, PositionEnum.WR, true, 5, "PlayerWR2", "PlayerWR2Last"),
                MakePlayer(150, PositionEnum.K, true, 6, "PlayerK1", "PlayerK1Last"),

                MakePlayer(130, PositionEnum.DL, true, 7, "PlayerDL1", "PlayerDL1Last"),
                MakePlayer(15, PositionEnum.DB, true, 8, "PlayerDB1", "PlayerDB1Last"),
                MakePlayer(240, PositionEnum.LB, true, 9, "PlayerLB1", "PlayerLB1Last"),
                MakePlayer(210, PositionEnum.LB, true, 10, "PlayerLB2", "PlayerLB2Last"),

                MakePlayer(250, PositionEnum.LB, false, 11, "PlayerLBBench1", "PlayerLBBench1Last"),
                MakePlayer(160, PositionEnum.QB, false, 12, "PlayerQBBench1", "PlayerQBBench1Last"),
                MakePlayer(22, PositionEnum.WR, false, 13, "PlayerWRBench1", "PlayerWRBench1Last"),
                MakePlayer(310, PositionEnum.RB, false, 14, "PlayerRBBench1", "PlayerRBBench1Last"),
                MakePlayer(250, PositionEnum.RB, false, 15, "PlayerRBBench2", "PlayerRBBench2Last")
            };

            var swapHelper = new PlayerSwapper();
            var updatedPlayers = swapHelper.GetUpdatedPlayers(players);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 0 && p.Position == PositionEnum.QB && p.Starting && p.OriginalIndex == 1 && p.FirstName == "PlayerQB1" && p.LastName == "PlayerQB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 20 && p.PointsUpdated == 165 && p.Position == PositionEnum.WR && !p.Starting && p.OriginalIndex == 2 && p.FirstName == "PlayerWR1" && p.LastName == "PlayerWR1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 300 && p.PointsUpdated == 0 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 3 && p.FirstName == "PlayerRB1" && p.LastName == "PlayerRB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 280 && p.PointsUpdated == 0 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 4 && p.FirstName == "PlayerRB2" && p.LastName == "PlayerRB2Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 40 && p.PointsUpdated == 145 && p.Position == PositionEnum.WR && !p.Starting && p.OriginalIndex == 5 && p.FirstName == "PlayerWR2" && p.LastName == "PlayerWR2Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 0 && p.Position == PositionEnum.K && p.Starting && p.OriginalIndex == 6 && p.FirstName == "PlayerK1" && p.LastName == "PlayerK1Last") == 1);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.PointsUpdated == 0 && p.Position == PositionEnum.DL && p.Starting && p.OriginalIndex == 7 && p.FirstName == "PlayerDL1" && p.LastName == "PlayerDL1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 15 && p.PointsUpdated == 132.5m && p.Position == PositionEnum.DB && !p.Starting && p.OriginalIndex == 8 && p.FirstName == "PlayerDB1" && p.LastName == "PlayerDB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 240 && p.PointsUpdated == 0 && p.Position == PositionEnum.LB && p.Starting && p.OriginalIndex == 9 && p.FirstName == "PlayerLB1" && p.LastName == "PlayerLB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 210 && p.PointsUpdated == 0 && p.Position == PositionEnum.LB && p.Starting && p.OriginalIndex == 10 && p.FirstName == "PlayerLB2" && p.LastName == "PlayerLB2Last") == 1);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 250 && p.PointsUpdated == 132.5m && p.Position == PositionEnum.LB && p.Starting && p.OriginalIndex == 11 && p.FirstName == "PlayerLBBench1" && p.LastName == "PlayerLBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 160 && p.PointsUpdated == 0 && p.Position == PositionEnum.QB && !p.Starting && p.OriginalIndex == 12 && p.FirstName == "PlayerQBBench1" && p.LastName == "PlayerQBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 22 && p.PointsUpdated == 0 && p.Position == PositionEnum.WR && !p.Starting && p.OriginalIndex == 13 && p.FirstName == "PlayerWRBench1" && p.LastName == "PlayerWRBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 310 && p.PointsUpdated == 165 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 14 && p.FirstName == "PlayerRBBench1" && p.LastName == "PlayerRBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 250 && p.PointsUpdated == 145 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 15 && p.FirstName == "PlayerRBBench2" && p.LastName == "PlayerRBBench2Last") == 1);
        }

        [TestMethod]
        public void TestCrossPositionAndNormalSwapCombined()
        {
            //QB
            //WR
            //RB
            //WR
            //RB
            //Kicker
            //DL
            //DB
            //LB
            //D
            //LB
            //QB
            //WR
            //RB
            //RB

            var players = new Player[]
            {
                MakePlayer(150, PositionEnum.QB, true, 1, "PlayerQB1", "PlayerQB1Last"), //normal
                MakePlayer(20, PositionEnum.WR, true, 2, "PlayerWR1", "PlayerWR1Last"), //cross
                MakePlayer(120, PositionEnum.RB, true, 3, "PlayerRB1", "PlayerRB1Last"), //normal
                MakePlayer(150, PositionEnum.WR, true, 5, "PlayerWR2", "PlayerWR2Last"),
                MakePlayer(150, PositionEnum.K, true, 6, "PlayerK1", "PlayerK1Last"),

                MakePlayer(130, PositionEnum.DL, true, 7, "PlayerDL1", "PlayerDL1Last"),
                MakePlayer(20, PositionEnum.DB, true, 8, "PlayerDB1", "PlayerDB1Last"), //cross
                MakePlayer(130, PositionEnum.LB, true, 9, "PlayerLB1", "PlayerLB1Last"),
                MakePlayer(130, PositionEnum.LB, true, 10, "PlayerLB2", "PlayerLB2Last"),

                MakePlayer(240, PositionEnum.LB, false, 11, "PlayerLBBench1", "PlayerLBBench1Last"),
                MakePlayer(310, PositionEnum.QB, false, 12, "PlayerQBBench1", "PlayerQBBench1Last"),
                MakePlayer(22, PositionEnum.WR, false, 13, "PlayerWRBench1", "PlayerWRBench1Last"),
                MakePlayer(210, PositionEnum.RB, false, 14, "PlayerRBBench1", "PlayerRBBench1Last"),
                MakePlayer(150, PositionEnum.RB, false, 15, "PlayerRBBench2", "PlayerRBBench2Last")
            };

            var swapHelper = new PlayerSwapper();
            var updatedPlayers = swapHelper.GetUpdatedPlayers(players);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 150 && p.Position == PositionEnum.QB && !p.Starting && p.OriginalIndex == 1 && p.FirstName == "PlayerQB1" && p.LastName == "PlayerQB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 20 && p.PointsUpdated == 20 && p.Position == PositionEnum.WR && !p.Starting && p.OriginalIndex == 2 && p.FirstName == "PlayerWR1" && p.LastName == "PlayerWR1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 120 && p.PointsUpdated == 120 && p.Position == PositionEnum.RB && !p.Starting && p.OriginalIndex == 3 && p.FirstName == "PlayerRB1" && p.LastName == "PlayerRB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 0 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 4 && p.FirstName == "PlayerRB2" && p.LastName == "PlayerRB2Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 0 && p.Position == PositionEnum.WR && p.Starting && p.OriginalIndex == 5 && p.FirstName == "PlayerWR2" && p.LastName == "PlayerWR2Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 0 && p.Position == PositionEnum.K && p.Starting && p.OriginalIndex == 6 && p.FirstName == "PlayerK1" && p.LastName == "PlayerK1Last") == 1);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.PointsUpdated == 0 && p.Position == PositionEnum.DL && p.Starting && p.OriginalIndex == 7 && p.FirstName == "PlayerDL1" && p.LastName == "PlayerDL1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.PointsUpdated == 130 && p.Position == PositionEnum.DB && !p.Starting && p.OriginalIndex == 8 && p.FirstName == "PlayerDB1" && p.LastName == "PlayerDB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.PointsUpdated == 0 && p.Position == PositionEnum.LB && p.Starting && p.OriginalIndex == 9 && p.FirstName == "PlayerLB1" && p.LastName == "PlayerLB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.PointsUpdated == 0 && p.Position == PositionEnum.LB && p.Starting && p.OriginalIndex == 10 && p.FirstName == "PlayerLB2" && p.LastName == "PlayerLB2Last") == 1);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 240 && p.PointsUpdated == 130 && p.Position == PositionEnum.LB && p.Starting && p.OriginalIndex == 11 && p.FirstName == "PlayerLBBench1" && p.LastName == "PlayerLBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 310 && p.PointsUpdated == 310 && p.Position == PositionEnum.QB && p.Starting && p.OriginalIndex == 12 && p.FirstName == "PlayerQBBench1" && p.LastName == "PlayerQBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 22 && p.PointsUpdated == 0 && p.Position == PositionEnum.WR && !p.Starting && p.OriginalIndex == 13 && p.FirstName == "PlayerWRBench1" && p.LastName == "PlayerWRBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 210 && p.PointsUpdated == 210 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 14 && p.FirstName == "PlayerRBBench1" && p.LastName == "PlayerRBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 85 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 15 && p.FirstName == "PlayerRBBench2" && p.LastName == "PlayerRBBench2Last") == 1);
        }

        [TestMethod]
        public void TestCrossOverride()
        {
            //QB
            //WR
            //RB
            //WR
            //RB
            //Kicker
            //DL
            //DB
            //LB
            //D
            //LB
            //QB
            //WR
            //RB
            //RB

            var players = new Player[]
            {
                MakePlayer(150, PositionEnum.QB, true, 1, "PlayerQB1", "PlayerQB1Last"),
                MakePlayer(20, PositionEnum.WR, true, 2, "PlayerWR1", "PlayerWR1Last"), //cross override
                MakePlayer(150, PositionEnum.RB, true, 3, "PlayerRB1", "PlayerRB1Last"),
                MakePlayer(150, PositionEnum.RB, true, 4, "PlayerRB2", "PlayerRB2Last"),
                MakePlayer(150, PositionEnum.WR, true, 5, "PlayerWR2", "PlayerWR2Last"),
                MakePlayer(150, PositionEnum.K, true, 6, "PlayerK1", "PlayerK1Last"),

                MakePlayer(130, PositionEnum.DL, true, 7, "PlayerDL1", "PlayerDL1Last"),
                MakePlayer(130, PositionEnum.DB, true, 8, "PlayerDB1", "PlayerDB1Last"),
                MakePlayer(130, PositionEnum.LB, true, 9, "PlayerLB1", "PlayerLB1Last"),
                MakePlayer(130, PositionEnum.LB, true, 10, "PlayerLB2", "PlayerLB2Last"),

                MakePlayer(100, PositionEnum.LB, false, 11, "PlayerLBBench1", "PlayerLBBench1Last"),
                MakePlayer(250, PositionEnum.QB, false, 12, "PlayerQBBench1", "PlayerQBBench1Last"),
                MakePlayer(45, PositionEnum.WR, false, 13, "PlayerWRBench1", "PlayerWRBench1Last"), //could swap
                MakePlayer(150, PositionEnum.RB, false, 14, "PlayerRBBench1", "PlayerRBBench1Last"), //cross override
                MakePlayer(100, PositionEnum.RB, false, 15, "PlayerRBBench2", "PlayerRBBench2Last")
            };

            var swapHelper = new PlayerSwapper();
            var updatedPlayers = swapHelper.GetUpdatedPlayers(players);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 150 && p.Position == PositionEnum.QB && !p.Starting && p.OriginalIndex == 1 && p.FirstName == "PlayerQB1" && p.LastName == "PlayerQB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 20 && p.PointsUpdated == 20 && p.Position == PositionEnum.WR && !p.Starting && p.OriginalIndex == 2 && p.FirstName == "PlayerWR1" && p.LastName == "PlayerWR1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 0 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 3 && p.FirstName == "PlayerRB1" && p.LastName == "PlayerRB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 0 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 4 && p.FirstName == "PlayerRB2" && p.LastName == "PlayerRB2Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 0 && p.Position == PositionEnum.WR && p.Starting && p.OriginalIndex == 5 && p.FirstName == "PlayerWR2" && p.LastName == "PlayerWR2Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 0 && p.Position == PositionEnum.K && p.Starting && p.OriginalIndex == 6 && p.FirstName == "PlayerK1" && p.LastName == "PlayerK1Last") == 1);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.PointsUpdated == 0 && p.Position == PositionEnum.DL && p.Starting && p.OriginalIndex == 7 && p.FirstName == "PlayerDL1" && p.LastName == "PlayerDL1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.PointsUpdated == 0 && p.Position == PositionEnum.DB && p.Starting && p.OriginalIndex == 8 && p.FirstName == "PlayerDB1" && p.LastName == "PlayerDB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.PointsUpdated == 0 && p.Position == PositionEnum.LB && p.Starting && p.OriginalIndex == 9 && p.FirstName == "PlayerLB1" && p.LastName == "PlayerLB1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 130 && p.PointsUpdated == 0 && p.Position == PositionEnum.LB && p.Starting && p.OriginalIndex == 10 && p.FirstName == "PlayerLB2" && p.LastName == "PlayerLB2Last") == 1);

            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 100 && p.PointsUpdated == 0 && p.Position == PositionEnum.LB && !p.Starting && p.OriginalIndex == 11 && p.FirstName == "PlayerLBBench1" && p.LastName == "PlayerLBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 250 && p.PointsUpdated == 250 && p.Position == PositionEnum.QB && p.Starting && p.OriginalIndex == 12 && p.FirstName == "PlayerQBBench1" && p.LastName == "PlayerQBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 45 && p.PointsUpdated == 0 && p.Position == PositionEnum.WR && !p.Starting && p.OriginalIndex == 13 && p.FirstName == "PlayerWRBench1" && p.LastName == "PlayerWRBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 150 && p.PointsUpdated == 85 && p.Position == PositionEnum.RB && p.Starting && p.OriginalIndex == 14 && p.FirstName == "PlayerRBBench1" && p.LastName == "PlayerRBBench1Last") == 1);
            Assert.IsTrue(updatedPlayers.Count(p => p.Points == 100 && p.PointsUpdated == 0 && p.Position == PositionEnum.RB && !p.Starting && p.OriginalIndex == 15 && p.FirstName == "PlayerRBBench2" && p.LastName == "PlayerRBBench2Last") == 1);
        }

        private Player MakePlayer(decimal points, PositionEnum position, bool starting, int originalIndex, string firstname = "", string lastname = "")
        {
            string player;
            switch (position)
            {
                case PositionEnum.QB:
                {
                    player = GetQuarterBack();
                    break;
                }
                case PositionEnum.RB:
                {
                    player = GetRunningBack();
                    break;
                }
                case PositionEnum.WR:
                {
                    player = GetWideReceiver();
                    break;
                }
                case PositionEnum.TE:
                {
                    player = GetTightEnd();
                    break;
                }
                case PositionEnum.K:
                {
                    player = GetKicker();
                    break;
                }
                case PositionEnum.DL:
                {
                    player = GetDefensiveLineman();
                    break;
                }
                case PositionEnum.DB:
                {
                    player = GetDefensiveBack();
                    break;
                }
                default:
                {
                    player = GetLinebacker();
                    break;
                }
            }

            return new Player
            {
                //Get Correct player and position
                FirstName = firstname == "" ? player.Split(' ')[0] : firstname,
                LastName = lastname == "" ? player.Split(' ')[1] : lastname,
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

        private string GetWideReceiver()
        {
            var random = new Random();
            int randomNumber = random.Next(_wrNames.Length);
            _wrNames.RemoveAt(randomNumber);

            return _wrNames[randomNumber];
        }

        private string GetTightEnd()
        {
            var random = new Random();
            int randomNumber = random.Next(_teNames.Length);
            _teNames.RemoveAt(randomNumber);

            return _teNames[randomNumber];
        }

        private string GetKicker()
        {
            var random = new Random();
            int randomNumber = random.Next(_kNames.Length);
            _kNames.RemoveAt(randomNumber);

            return _kNames[randomNumber];
        }

        private string GetDefensiveLineman()
        {
            var random = new Random();
            int randomNumber = random.Next(_dlNames.Length);
            _dlNames.RemoveAt(randomNumber);

            return _dlNames[randomNumber];
        }

        private string GetDefensiveBack()
        {
            var random = new Random();
            int randomNumber = random.Next(_dbNames.Length);
            _dbNames.RemoveAt(randomNumber);

            return _dbNames[randomNumber];
        }

        private string GetLinebacker()
        {
            var random = new Random();
            int randomNumber = random.Next(_lbNames.Length);
            _lbNames.RemoveAt(randomNumber);

            return _lbNames[randomNumber];
        }
    }
}
