using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamManagement.Domain.Entities;
using TeamManagement.Domain.Repository;

namespace TeamManagament.Data
{
    
    public class TeamRepository : ITeamRepository
    {
        TeamManageContext _context;
        public TeamRepository(TeamManageContext context) { _context = context; }
        public void AddMember(int teamId, int memId)
        {
            // Check if the team exists
            var team =  _context.Teams.Include(t => t.Members).FirstOrDefault(t => t.TeamId == teamId);
            if (team == null)
            {
                throw new ArgumentException($"Team with ID {teamId} not found.");
            }

            // Check if the member exists
            var member =  _context.Members.Find(memId);
            if (member == null)
            {
                throw new ArgumentException($"Member with ID {memId} not found.");
            }

            // Check if the member already belongs to the team
            if (team.Members.Any(m => m.MemberId == memId))
            {
                throw new InvalidOperationException($"Member {member.Name} already exists in Team {team.TeamName}.");
            }

            // Add the member to the team
            member.TeamId = teamId; // Associate the member with the team
            team.Members.Add(member);

            // Save changes to the database
             _context.SaveChanges();
        }


        public List<TeamMember> GetAllTeamMembers(int teamId)
        
            {
                // Check if the team exists
                var team = _context.Teams
                    .Include(t => t.Members)
                    .FirstOrDefault(t => t.TeamId == teamId);

            var memers = from mem in _context.Members
                where mem.TeamId == teamId
                         select new TeamMember
                         {
                             MemberId = mem.MemberId,
                             Name = mem.Name,
                             TeamId = mem.TeamId
                         };

            if (team == null)
                {
                    throw new ArgumentException($"Team with ID {teamId} not found.");
                }

                // Return the list of members (or an empty list if none)
              return memers.ToList();
            
        }

        public void  RemoveMember(int teamId, int memId)
        {
            // Check if the team exists
            var team = _context.Teams.Find(teamId);
            if (team == null)
            {
                throw new ArgumentException($"Team with ID {teamId} not found.");
            }

            // Fetch the member to be removed
            var member =  _context.Members
                .FirstOrDefault(m => m.MemberId == memId && m.TeamId == teamId);

            if (member == null)
            {
                throw new ArgumentException($"Member with ID {memId} not found in Team {team.TeamName}.");
            }

            // Remove the member from the team
            _context.Members.Remove(member);

            // Save changes to the database
             _context.SaveChanges();
        }


        public List<Team> GetAll()
        {
            return _context.Teams.ToList();
        }


    }
}
