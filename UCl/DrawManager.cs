using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCl
{
    public class DrawManager
    {
        internal Groups DrawForGroupStage(Bags bags)
        {
            Bags backup = new Bags();
            var group = new Groups();

            foreach (var item in group.listOfGroups) 
            { 
                AddTeamToGroup(bags.Tier1, item);

                if (!CheckAnyTeamCanFit(bags.Tier2, item))
                {
                    DrawForGroupStage(backup);
                }
                AddTeamToGroup(bags.Tier2, item);

                if (!CheckAnyTeamCanFit(bags.Tier3, item))
                {
                    DrawForGroupStage(backup);
                }
                AddTeamToGroup(bags.Tier3, item);

                if (!CheckAnyTeamCanFit(bags.Tier4, item))
                {
                    DrawForGroupStage(backup);
                }
                AddTeamToGroup(bags.Tier4, item);
            }

            return group;
        }
        private bool CheckAnyTeamCanFit(List<Team> teams, Group group)
        {
            foreach (var team in teams)
            {
                if (group.Teams.All(x => x.Country != team.Country))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddTeamToGroup(List<Team> bags, Group group)
        {
            if (group.Teams.Count <= 0)
            {
                var selectedTeam = GetRandomTeamFromBag(bags);
                group.Teams.Add(selectedTeam);
                bags.Remove(selectedTeam);
            }
            else if (group.Teams.Count >= 1)
            {
                while (true)
                {
                    var selectedTeam = GetRandomTeamFromBag(bags);
                    if (group.Teams.Any(x => x.Country != selectedTeam.Country))
                    {
                        group.Teams.Add(selectedTeam);
                        bags.Remove(selectedTeam);
                        break;
                    }
                }
                
            }
        }

        public Team GetRandomTeamFromBag(List<Team> teams)
        {
            var random = new Random();
            var teamId = random.Next(0, teams.Count);
            
            return teams[teamId];
        }
    }
}
