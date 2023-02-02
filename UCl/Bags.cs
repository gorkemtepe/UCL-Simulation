using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCl
{
    internal class Bags
    {
        public List<Team> Tier1 { get; set; } = new List<Team>();
        public List<Team> Tier2 { get; set; } = new List<Team>();
        public List<Team> Tier3 { get; set; } = new List<Team>();
        public List<Team> Tier4 { get; set; } = new List<Team>();
        public Bags()
        {
            Tier1 = new List<Team>()
            {
                new Team()
                {
                    Name = "Bayern Munich",
                    Country = "Almanya",
                    BagID = 1
                },
                new Team()
                {
                    Name = "Sevilla",
                    Country = "İspanya",
                    BagID = 1
                },
                new Team()
                {
                    Name = "Real Madrid",
                    Country = "İspanya",
                    BagID = 1
                },
                new Team()
                {
                    Name = "Liverpool",
                    Country = "İngiltere",
                    BagID = 1
                },
                new Team()
                {
                    Name = "Juventus",
                    Country = "İtalya",
                    BagID = 1
                },
                new Team()
                {
                    Name = "Paris Saint-Germain",
                    Country = "Fransa",
                    BagID = 1
                },
                new Team()
                {
                    Name = "Zenit",
                    Country = "Rusya",
                    BagID = 1
                },
                new Team()
                {
                    Name = "Porto",
                    Country = "Portekiz",
                    BagID = 1
                }
            };
            Tier2 = new List<Team>()
            {
                new Team()
                {
                    Name = "Barcelona",
                    Country = "İspanya",
                    BagID = 2
                },
                new Team()
                {
                    Name = "Atlético Madrid",
                    Country = "İspanya",
                    BagID = 2
                },
                new Team()
                {
                    Name = "Manchester City",
                    Country = "İngiltere",
                    BagID = 2
                },
                new Team()
                {
                    Name = "Manchester United",
                    Country = "İngiltere",
                    BagID = 2
                },
                new Team()
                {
                    Name = "Borussia Dortmund",
                    Country = "Almanya",
                    BagID = 2
                },
                new Team()
                {
                    Name = "Shakhtar Donetsk",
                    Country = "Ukrayna",
                    BagID = 2
                },
                new Team()
                {
                    Name = "Chelsea",
                    Country = "İngiltere",
                    BagID = 2
                },
                new Team()
                {
                    Name = "Ajax",
                    Country = "Hollanda",
                    BagID = 2
                }
            };
            Tier3 = new List<Team>()
            {
                new Team()
                {
                    Name = "Dynamo Kiev",
                    Country = "Ukrayna",
                    BagID = 3
                },
                new Team()
                {
                    Name = "Red Bull Salzburg",
                    Country = "Almanya",
                    BagID = 3
                },
                new Team()
                {
                    Name = "RB Leipzig",
                    Country = "Almanya",
                    BagID = 3
                },
                new Team()
                {
                    Name = "Internazionale",
                    Country = "İtalya",
                    BagID = 3
                },
                new Team()
                {
                    Name = "Olympiacos",
                    Country = "Yunanistan",
                    BagID = 3
                },
                new Team()
                {
                    Name = "Lazio",
                    Country = "İtalya",
                    BagID = 3
                },
                new Team()
                {
                    Name = "Krasnodar",
                    Country = "Rusya",
                    BagID = 3
                },
                new Team()
                {
                    Name = "Atalanta",
                    Country = "İtalya",
                    BagID = 3
                }
            };
            Tier4 = new List<Team>()
            {
                new Team()
                {
                    Name = "Lokomotiv Moskova",
                    Country = "Rusya",
                    BagID = 4
                },
                new Team()
                {
                    Name = "Marseille",
                    Country = "Fransa",
                    BagID = 4
                },
                new Team()
                {
                    Name = "Club Brugge",
                    Country = "Belçika",
                    BagID = 4
                },
                new Team()
                {
                    Name = "Bor. Mönchengladbach",
                    Country = "Almanya",
                    BagID = 4
                },
                new Team()
                {
                    Name = "Galatasaray",
                    Country = "Türkiye",
                    BagID = 4
                },
                new Team()
                {
                    Name = "Midtjylland",
                    Country = "Danimarka",
                    BagID = 4
                },
                new Team()
                {
                    Name = "Rennes",
                    Country = "Fransa",
                    BagID = 4
                },
                new Team()
                {
                    Name = "Ferencváros",
                    Country = "Macaristan",
                    BagID = 4
                }
            };
        }
    }
    public class Groups
    {
        public List<Group> listOfGroups { get; set; } = new List<Group>();

        public Groups()
        {
            listOfGroups.Add(new Group { Id = 1, Name = "A Grubu", Teams = new List<Team>() });
            listOfGroups.Add(new Group { Id = 2, Name = "B Grubu", Teams = new List<Team>() });
            listOfGroups.Add(new Group { Id = 3, Name = "C Grubu", Teams = new List<Team>() });
            listOfGroups.Add(new Group { Id = 4, Name = "D Grubu", Teams = new List<Team>() });
            listOfGroups.Add(new Group { Id = 5, Name = "E Grubu", Teams = new List<Team>() });
            listOfGroups.Add(new Group { Id = 6, Name = "F Grubu", Teams = new List<Team>() });
            listOfGroups.Add(new Group { Id = 7, Name = "G Grubu", Teams = new List<Team>() });
            listOfGroups.Add(new Group { Id = 8, Name = "H Grubu", Teams = new List<Team>() });
        }
        public int GetCount()
        {
            return this.listOfGroups.Count();
        }
    }

    public class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int BagID { get; set; }
        public int Point { get { return this.Won * 3 + this.Draw ; } }
        public int Won { get; set; }
        public int Lose { get; set; }
        public int Draw { get; set; }
        public int Average { get { return this.GoalScored - this.ConcededGoalScored; } }
        public int GoalScored { get; set; }
        public int ConcededGoalScored { get; set; }
        public Group Group { get; set; }
    }
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
    }

    public class Match
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
    }

    
}
