using System;
using System.Collections.Generic;
using TRLScoreKeeper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SubstitutionSystem.Tests
{
    [TestClass]
    public class SubstitutionTests
    {
        private List<Player> _players;
        private string[] _runningBackNames;
        private string[] _qbNames;
        private string[] _wideReceiverNames;
        private string[] _tightEndNames;
        private string[] _kickerNames;
        private string[] _defensiveLinemanNames;
        private string[] _linebackerNames;
        private string[] _defensiveBackNames;

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

            _wideReceiverNames = new string[]
            {
                "Antonio Brown",
                "DeAndre Hopkins",
                "Odell Beckham",
                "Julio Jones",
                "Michael Thomas",
                "Keenan Allen",
                "A.J. Green",
                "Mike Evans",
                "Davante Adams",
                "Adam Thielen",
                "Tyreek Hill",
                "Larry Fitzgerald"
            };

            _tightEndNames = new string[]
            {
               "Rob Gronkowski",
                "Travis Kelce",
                "Zach Ertz",
                "Greg Olsen",
                "Evan Engram",
                "Delanie Walker",
                "Jimmy Graham",
                "Kyle Rudolph",
                "Jordan Reed",
                "Trey Burton",
                "Jack Doyle",
                "Tyler Eifert"
            };

            _kickerNames = new string[]
            {
                "Greg Zuerlein",
                "Justin Tucker",
                "Stephen Gostkowski",
                "Matt Bryant",
                "Wil Lutz",
                "Jake Elliott",
                "Robbie Gould",
                "Chris Boswell",
                "Matt Prater",
                "Harrison Butker",
                "Adam Vinatieri",
                "Graham Gano"
            };

            _defensiveLinemanNames = new string[]
            {
                "Joey Bosa",
                "J.J. Watt",
                "Jason Pierre-Paul",
                "Danielle Hunter",
                "Calais Campbell",
                "Khalil Mack",
                "Aaron Donald",
                "Carlos Dunlap",
                "Melvin Ingram",
                "Cameron Jordan",
                "Everson Griffen",
                "Olivier Vernon",
                "Muhammad Wilkerson"
            };


            _linebackerNames = new string[]
            {
                "Luke Kuechly",
                "Bobby Wagner",
                "Telvin Smith",
                "C.J. Mosley",
                "Kwon Alexander",
                "Sean Lee",
                "Alec Ogletree",
                "Deion Jones",
                "Christian Kirksey",
                "Lavonte David",
                "Zach Brown",
                "Benardrick McKinney"
            };

            _defensiveBackNames = new string[]
            {
                "Landon Collins",
                "Keanu Neal",
                "Reshad Jones",
                "Harrison Smith",
                "Johnathan Cyprien",
                "Tony Jefferson",
                "Barry Church",
                "Karl Joseph",
                "Hasean Clinton-Dix",
                "Morgan Burnett",
                "Tyrann Mathieu",
                "Jordan Poyer",
                "Jamal Adams"
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
            var team = new Player[16];
            team[0] = MakePlayer(150, PositionEnum.QB, true, 0);
            team[1] = MakePlayer(150, PositionEnum.RB, true, 1);
            team[2] = MakePlayer(150, PositionEnum.WR, true, 2);
            team[3] = MakePlayer(150, PositionEnum.TE, true, 3);
            team[4] = MakePlayer(150, PositionEnum.RB, true, 4);
            team[5] = MakePlayer(150, PositionEnum.WR, true, 5);
            team[6] = MakePlayer(150, PositionEnum.K, true, 6);
            team[7] = MakePlayer(150, PositionEnum.DL, true, 7);
            team[8] = MakePlayer(150, PositionEnum.LB, true, 8);
            team[9] = MakePlayer(150, PositionEnum.DB, true, 9);
            team[10] = MakePlayer(150, PositionEnum.LB, true, 10);

            team[11] = MakePlayer(120, PositionEnum.WR, false, 11);
            team[12] = MakePlayer(120, PositionEnum.RB, false, 12);
            team[13] = MakePlayer(120, PositionEnum.LB, false, 13);
            team[14] = MakePlayer(120, PositionEnum.LB, false, 14);
            team[15] = MakePlayer(130, PositionEnum.LB, false, 15);

            var updatedPlayers = new SwapHelper().GetUpdatedPlayers(team);
            var test = 1;
        }

        [TestMethod]
        public void TestSimpleSub()
        {
            var team = new Player[3];
            team[0] = MakePlayer(150, PositionEnum.RB, true, 0);
            team[1] = MakePlayer(150, PositionEnum.WR, true, 1);            

            team[2] = MakePlayer(240, PositionEnum.WR, false, 2);

            var updatedPlayers = new SwapHelper().GetUpdatedPlayers(team);

            Assert.AreEqual(0, updatedPlayers[0].PointsUpdated);
            Assert.AreEqual(150, updatedPlayers[0].Points);
            Assert.AreEqual(true, updatedPlayers[0].Starting);
            Assert.AreEqual(PositionEnum.RB, updatedPlayers[0].Position);
            Assert.AreEqual(0, updatedPlayers[0].OriginalIndex);
            Assert.AreEqual(false, updatedPlayers[0].AlreadySubbed);

            Assert.AreEqual(240, updatedPlayers[1].PointsUpdated);
            Assert.AreEqual(240, updatedPlayers[1].Points);
            Assert.AreEqual(true, updatedPlayers[1].Starting);
            Assert.AreEqual(PositionEnum.WR, updatedPlayers[1].Position);
            Assert.AreEqual(2, updatedPlayers[1].OriginalIndex);
            Assert.AreEqual(true, updatedPlayers[1].AlreadySubbed);

            Assert.AreEqual(150, updatedPlayers[2].PointsUpdated);
            Assert.AreEqual(150, updatedPlayers[2].Points);
            Assert.AreEqual(false, updatedPlayers[2].Starting);
            Assert.AreEqual(PositionEnum.WR, updatedPlayers[2].Position);
            Assert.AreEqual(1, updatedPlayers[2].OriginalIndex);
            Assert.AreEqual(true, updatedPlayers[2].AlreadySubbed);
        }

        [TestMethod]
        public void TestSubSingleQbFirst()
        {
            var team = new Player[16];
            team[0] = MakePlayer(150, PositionEnum.QB, true, 0);
            team[1] = MakePlayer(150, PositionEnum.RB, true, 1);
            team[2] = MakePlayer(150, PositionEnum.WR, true, 2);
            team[3] = MakePlayer(150, PositionEnum.TE, true, 3);
            team[4] = MakePlayer(150, PositionEnum.RB, true, 4);
            team[5] = MakePlayer(150, PositionEnum.WR, true, 5);
            team[6] = MakePlayer(150, PositionEnum.K, true, 6);
            team[7] = MakePlayer(150, PositionEnum.DL, true, 7);
            team[8] = MakePlayer(150, PositionEnum.LB, true, 8);
            team[9] = MakePlayer(150, PositionEnum.DB, true, 9);
            team[10] = MakePlayer(150, PositionEnum.LB, true, 10);

            team[11] = MakePlayer(240, PositionEnum.QB, false, 11);
            team[12] = MakePlayer(80, PositionEnum.RB, false, 12);
            team[13] = MakePlayer(120, PositionEnum.LB, false, 13);
            team[14] = MakePlayer(20, PositionEnum.LB, false, 14);
            team[15] = MakePlayer(130, PositionEnum.LB, false, 15);            

            var updatedPlayers = new SwapHelper().GetUpdatedPlayers(team);

            Assert.AreEqual(240, updatedPlayers[0].PointsUpdated);
            Assert.AreEqual(240, updatedPlayers[0].Points);
            Assert.AreEqual(true, updatedPlayers[0].Starting);
            Assert.AreEqual(PositionEnum.QB, updatedPlayers[0].Position);
            Assert.AreEqual(11, updatedPlayers[0].OriginalIndex);
            Assert.AreEqual(true, updatedPlayers[0].AlreadySubbed);

            Assert.AreEqual(0, updatedPlayers[1].PointsUpdated);
            Assert.AreEqual(150, updatedPlayers[1].Points);
            Assert.AreEqual(true, updatedPlayers[1].Starting);
            Assert.AreEqual(PositionEnum.RB, updatedPlayers[1].Position);
            Assert.AreEqual(1, updatedPlayers[1].OriginalIndex);
            Assert.AreEqual(false, updatedPlayers[1].AlreadySubbed);

            Assert.AreEqual(0, updatedPlayers[2].PointsUpdated);
            Assert.AreEqual(150, updatedPlayers[2].Points);
            Assert.AreEqual(true, updatedPlayers[2].Starting);
            Assert.AreEqual(PositionEnum.WR, updatedPlayers[2].Position);
            Assert.AreEqual(2, updatedPlayers[2].OriginalIndex);
            Assert.AreEqual(false, updatedPlayers[2].AlreadySubbed);

            Assert.AreEqual(0, updatedPlayers[3].PointsUpdated);
            Assert.AreEqual(150, updatedPlayers[3].Points);
            Assert.AreEqual(true, updatedPlayers[3].Starting);
            Assert.AreEqual(PositionEnum.TE, updatedPlayers[3].Position);
            Assert.AreEqual(3, updatedPlayers[3].OriginalIndex);
            Assert.AreEqual(false, updatedPlayers[3].AlreadySubbed);

            Assert.AreEqual(0, updatedPlayers[4].PointsUpdated);
            Assert.AreEqual(150, updatedPlayers[4].Points);
            Assert.AreEqual(true, updatedPlayers[4].Starting);
            Assert.AreEqual(PositionEnum.RB, updatedPlayers[4].Position);
            Assert.AreEqual(4, updatedPlayers[4].OriginalIndex);
            Assert.AreEqual(false, updatedPlayers[4].AlreadySubbed);

            Assert.AreEqual(0, updatedPlayers[5].PointsUpdated);
            Assert.AreEqual(150, updatedPlayers[5].Points);
            Assert.AreEqual(true, updatedPlayers[5].Starting);
            Assert.AreEqual(PositionEnum.WR, updatedPlayers[5].Position);
            Assert.AreEqual(5, updatedPlayers[5].OriginalIndex);
            Assert.AreEqual(false, updatedPlayers[5].AlreadySubbed);

            Assert.AreEqual(0, updatedPlayers[6].PointsUpdated);
            Assert.AreEqual(150, updatedPlayers[6].Points);
            Assert.AreEqual(true, updatedPlayers[6].Starting);
            Assert.AreEqual(PositionEnum.K, updatedPlayers[6].Position);
            Assert.AreEqual(6, updatedPlayers[6].OriginalIndex);
            Assert.AreEqual(false, updatedPlayers[6].AlreadySubbed);

            Assert.AreEqual(0, updatedPlayers[7].PointsUpdated);
            Assert.AreEqual(150, updatedPlayers[7].Points);
            Assert.AreEqual(true, updatedPlayers[7].Starting);
            Assert.AreEqual(PositionEnum.DL, updatedPlayers[7].Position);
            Assert.AreEqual(7, updatedPlayers[7].OriginalIndex);
            Assert.AreEqual(false, updatedPlayers[7].AlreadySubbed);

            Assert.AreEqual(0, updatedPlayers[8].PointsUpdated);
            Assert.AreEqual(150, updatedPlayers[8].Points);
            Assert.AreEqual(true, updatedPlayers[8].Starting);
            Assert.AreEqual(PositionEnum.LB, updatedPlayers[8].Position);
            Assert.AreEqual(8, updatedPlayers[8].OriginalIndex);
            Assert.AreEqual(false, updatedPlayers[8].AlreadySubbed);

            Assert.AreEqual(0, updatedPlayers[9].PointsUpdated);
            Assert.AreEqual(150, updatedPlayers[9].Points);
            Assert.AreEqual(true, updatedPlayers[9].Starting);
            Assert.AreEqual(PositionEnum.DB, updatedPlayers[9].Position);
            Assert.AreEqual(9, updatedPlayers[9].OriginalIndex);
            Assert.AreEqual(false, updatedPlayers[9].AlreadySubbed);

            Assert.AreEqual(0, updatedPlayers[10].PointsUpdated);
            Assert.AreEqual(150, updatedPlayers[10].Points);
            Assert.AreEqual(true, updatedPlayers[10].Starting);
            Assert.AreEqual(PositionEnum.LB, updatedPlayers[10].Position);
            Assert.AreEqual(10, updatedPlayers[10].OriginalIndex);
            Assert.AreEqual(false, updatedPlayers[10].AlreadySubbed);

            Assert.AreEqual(150, updatedPlayers[11].PointsUpdated);
            Assert.AreEqual(150, updatedPlayers[11].Points);
            Assert.AreEqual(false, updatedPlayers[11].Starting);
            Assert.AreEqual(PositionEnum.QB, updatedPlayers[11].Position);
            Assert.AreEqual(0, updatedPlayers[11].OriginalIndex);
            Assert.AreEqual(true, updatedPlayers[11].AlreadySubbed);

            Assert.AreEqual(0, updatedPlayers[12].PointsUpdated);
            Assert.AreEqual(80, updatedPlayers[12].Points);
            Assert.AreEqual(false, updatedPlayers[12].Starting);
            Assert.AreEqual(PositionEnum.RB, updatedPlayers[12].Position);
            Assert.AreEqual(12, updatedPlayers[12].OriginalIndex);
            Assert.AreEqual(false, updatedPlayers[12].AlreadySubbed);

            Assert.AreEqual(0, updatedPlayers[13].PointsUpdated);
            Assert.AreEqual(120, updatedPlayers[13].Points);
            Assert.AreEqual(false, updatedPlayers[13].Starting);
            Assert.AreEqual(PositionEnum.LB, updatedPlayers[13].Position);
            Assert.AreEqual(13, updatedPlayers[13].OriginalIndex);

            Assert.AreEqual(0, updatedPlayers[14].PointsUpdated);
            Assert.AreEqual(20, updatedPlayers[14].Points);
            Assert.AreEqual(false, updatedPlayers[14].Starting);
            Assert.AreEqual(PositionEnum.LB, updatedPlayers[14].Position);
            Assert.AreEqual(14, updatedPlayers[14].OriginalIndex);

            Assert.AreEqual(0, updatedPlayers[15].PointsUpdated);
            Assert.AreEqual(130, updatedPlayers[15].Points);
            Assert.AreEqual(false, updatedPlayers[15].Starting);
            Assert.AreEqual(PositionEnum.LB, updatedPlayers[15].Position);
            Assert.AreEqual(15, updatedPlayers[15].OriginalIndex);
        }

        private Player MakePlayer(decimal points, PositionEnum position, bool starting, int originalIndex, string firstname = "", string lastname = "")
        {
            string playerName = string.Empty;

            switch (position)
            {
                case PositionEnum.QB:
                {
                    playerName = firstname == "" ? GetRandomQuarterbackNameAndUpdateList() : "";
                    break;
                }
                case PositionEnum.RB:
                {
                    playerName = firstname == "" ? GetRandomRunningBackNameAndUpdateList() : "";
                    break;
                }
                case PositionEnum.WR:
                {
                    playerName = firstname == "" ? GetRandomWideReceiverNameAndUpdateList() : "";
                    break;
                }
                case PositionEnum.TE:
                {
                    playerName = firstname == "" ? GetRandomTightEndNameAndUpdateList() : "";
                    break;
                }
                case PositionEnum.K:
                {                    
                    playerName = firstname == "" ? GetRandomKickerAndUpdateList() : "";
                    break;
                }
                case PositionEnum.DL:
                {
                    playerName = firstname == "" ? GetRandomDefensiveLinemanNameAndUpdateList() : "";
                    break;
                }
                case PositionEnum.LB:
                {
                    playerName = firstname == "" ? GetRandomLinebackerNameAndUpdateList() : "";
                    break;
                }
                default:
                {
                    playerName = firstname == "" ? GetRandomDefensiveBackNameAndUpdateList() : "";
                    break;
                }
            }

            return new Player
            {
                //Get Correct player and position
                FirstName = GetPlayerFirstName(firstname, playerName),
                LastName = GetPlayerLastName(lastname, playerName),
                Points = points,
                Position = position,
                Starting = starting,
                OriginalIndex = originalIndex
            };
        }

        private string GetRandomRunningBackNameAndUpdateList()
        {
            var random = new Random();
            int randomNumber = random.Next(_runningBackNames.Length);
            var runningBackName = _runningBackNames[randomNumber];

            _runningBackNames = _runningBackNames.RemoveAt(randomNumber);

            return runningBackName;
        }

        private string GetRandomWideReceiverNameAndUpdateList()
        {
            var random = new Random();
            int randomNumber = random.Next(_wideReceiverNames.Length);
            var wideReceiverName = _wideReceiverNames[randomNumber];
            _wideReceiverNames = _wideReceiverNames.RemoveAt(randomNumber);

            return wideReceiverName;
        }

        private string GetRandomQuarterbackNameAndUpdateList()
        {
            var random = new Random();
            int randomNumber = random.Next(_qbNames.Length);
            var quarterbackName = _qbNames[randomNumber];
            _qbNames = _qbNames.RemoveAt(randomNumber);

            return quarterbackName;
        }

        private string GetRandomTightEndNameAndUpdateList()
        {
            var random = new Random();
            int randomNumber = random.Next(_tightEndNames.Length);
            var tightEndName = _tightEndNames[randomNumber];
            _tightEndNames = _tightEndNames.RemoveAt(randomNumber);

            return tightEndName;
        }

        private string GetRandomKickerAndUpdateList()
        {
            var random = new Random();
            int randomNumber = random.Next(_kickerNames.Length);
            var kickerName = _kickerNames[randomNumber];
            _kickerNames = _kickerNames.RemoveAt(randomNumber);

            return kickerName;
        }

        private string GetRandomDefensiveLinemanNameAndUpdateList()
        {
            var random = new Random();
            int randomNumber = random.Next(_defensiveLinemanNames.Length);
            var defensiveLinemanName = _defensiveLinemanNames[randomNumber];
            _defensiveLinemanNames = _defensiveLinemanNames.RemoveAt(randomNumber);

            return defensiveLinemanName;
        }

        private string GetRandomLinebackerNameAndUpdateList()
        {
            var random = new Random();
            int randomNumber = random.Next(_linebackerNames.Length);
            var linebackerName = _linebackerNames[randomNumber];
            _linebackerNames = _linebackerNames.RemoveAt(randomNumber);

            return linebackerName;
        }
        private string GetRandomDefensiveBackNameAndUpdateList()
        {
            var random = new Random();
            int randomNumber = random.Next(_defensiveBackNames.Length);
            var defensiveBackName = _defensiveBackNames[randomNumber];
            _defensiveBackNames = _defensiveBackNames.RemoveAt(randomNumber);

            return defensiveBackName;
        }

        private string GetPlayerFirstName(string firstname, string name)
        {
            return firstname == "" ? name.Split(' ')[0] : firstname;
        }

        private string GetPlayerLastName(string lastname, string name)
        {
            return lastname == "" ? name.Split(' ')[1] : lastname;
        }
    }
}
