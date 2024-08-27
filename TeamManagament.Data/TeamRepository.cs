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
        public async Task AddMember(int teamId, int memId)
        {
            // Check if the team exists
            var team = await _context.Teams.Include(t => t.Members).FirstOrDefaultAsync(t => t.TeamId == teamId);
            if (team == null)
            {
                throw new ArgumentException($"Team with ID {teamId} not found.");
            }

            // Check if the member exists
            var member = await _context.Members.FindAsync(memId);
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
            await _context.SaveChangesAsync();
        }


        public async Task<List<TeamMember>> GetAllTeamMembers(int teamId)
        
            {
                // Check if the team exists
                var team = await _context.Teams
                    .Include(t => t.Members)
                    .FirstOrDefaultAsync(t => t.TeamId == teamId);

                if (team == null)
                {
                    throw new ArgumentException($"Team with ID {teamId} not found.");
                }

                // Return the list of members (or an empty list if none)
                return team.Members.Any() ? team.Members.ToList() : new List<TeamMember>();
            
        }

        public async Task RemoveMember(int teamId, int memId)
        {
            // Check if the team exists
            var team = await _context.Teams.FindAsync(teamId);
            if (team == null)
            {
                throw new ArgumentException($"Team with ID {teamId} not found.");
            }

            // Fetch the member to be removed
            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.MemberId == memId && m.TeamId == teamId);

            if (member == null)
            {
                throw new ArgumentException($"Member with ID {memId} not found in Team {team.TeamName}.");
            }

            // Remove the member from the team
            _context.Members.Remove(member);

            // Save changes to the database
            await _context.SaveChangesAsync();
        }
    }
}
