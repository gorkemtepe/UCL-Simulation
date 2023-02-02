using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCl
{
    internal class FixtureManager
    {
        public List<Match> PlayedMatches { get; set; } = new List<Match>();
        public List<Team> listOfLast16 { get; set; } = new List<Team>();
        public void CreateFixture(Groups groups)
        {
            foreach (var group in groups.listOfGroups)
            {
                PlayedMatches.AddRange(PlayGroupMatches(group));
            }
        }

        public List<Match> PlayGroupMatches(Group group)
        {
            Random random = new Random();
            var matches = new List<Match>();

            var list = new List<Team>();
            group.Teams.ForEach(x => list.Add(x));
            foreach (var team in group.Teams.ToList())
            {
                list.Remove(team);
                for (int i = 0; i < list.Count * 2; i++)
                {
                    var match = new Match();
                    if (i < list.Count)
                    {
                        if (i % 2 == 0)
                        {
                            match = new Match { HomeTeam = team, AwayTeam = list[i % list.Count], AwayTeamScore = random.Next(0, 9), HomeTeamScore = random.Next(0, 9) };
                        }
                        else
                        {
                            match = new Match { HomeTeam = list[i % list.Count], AwayTeam = team, AwayTeamScore = random.Next(0, 9), HomeTeamScore = random.Next(0, 9) };
                        }
                    }
                    else
                    {
                        if (i % 2 == 1)
                        {
                            match = new Match { HomeTeam = team, AwayTeam = list[i % list.Count], AwayTeamScore = random.Next(0, 9), HomeTeamScore = random.Next(0, 9) };
                        }
                        else
                        {
                            match = new Match { HomeTeam = list[i % list.Count], AwayTeam = team, AwayTeamScore = random.Next(0, 9), HomeTeamScore = random.Next(0, 9) };
                        }
                    }
                    match.AwayTeam.GoalScored += match.AwayTeamScore;
                    match.HomeTeam.GoalScored += match.HomeTeamScore;
                    match.AwayTeam.ConcededGoalScored += match.HomeTeamScore;
                    match.HomeTeam.ConcededGoalScored += match.AwayTeamScore;

                    if (match.AwayTeam.GoalScored > match.HomeTeam.GoalScored)
                    {
                        match.AwayTeam.Won += 1;
                        match.HomeTeam.Lose += 1;
                    }
                    else if (match.AwayTeam.GoalScored < match.HomeTeam.GoalScored)
                    {
                        match.HomeTeam.Won += 1;
                        match.AwayTeam.Lose += 1;
                    }
                    else
                    {
                        match.HomeTeam.Draw += 1;
                        match.AwayTeam.Draw += 1;
                    }
                    matches.Add(match);
                }
            }

            return matches;
        }

        public List<Team> GetLast16(Groups groups)
        {
            foreach (var group in groups.listOfGroups)
            {
                List<Team> sortedList = group.Teams.OrderByDescending(x => x.Point).ThenBy(s => s.Average).ThenBy(k=>k.GoalScored).ToList();
                sortedList.RemoveRange(2, 2);
                listOfLast16.AddRange(sortedList);
            }
            return listOfLast16;
        }

        public string PrepareGroups(Groups groups)
        {
            string result = "";
            int a = 1;
            foreach (var group in groups.listOfGroups) 
            {
                result += "GROUP" + a.ToString()+"\n";
                List<Team> teams = group.Teams.OrderByDescending(x=>x.Point).ThenBy(s=>s.Average).ToList();
                foreach (var team in teams)
                {
                    result+=team.Name+" || "+team.Point+"\n";
                }
                a++;
                result += "---------------\n";
            }
            return result;
        }

        public string PrepareLast16(List<Team> teams)
        {
            string result = "";
            result += "----------Last 16-----------\n";
            foreach (var team in teams)
            {
                result += team.Name + "\n";
            }
            return result;
        }

        public string PrepareMatchResults(List<Match> playedMatches)
        {
            string result = "";
            int a = 1;
            result += "-------Match Results--------";
            foreach (var match in playedMatches)
            {
                result += "Match" + a.ToString() + " = ";
                result += match.HomeTeam.Name + " = " + match.HomeTeamScore.ToString() + " / " + match.AwayTeam.Name + " = " + match.AwayTeamScore.ToString() + "\n";
                a++;
            }
            return result;
        }
    }
}
