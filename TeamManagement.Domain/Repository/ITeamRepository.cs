using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagement.Domain.Entities;

namespace TeamManagement.Domain.Repository
{
    public interface ITeamRepository
    {
       Task <List<TeamMember>> GetAllTeamMembers(int teamId);
        Task AddMember(int teamId, int memId);
        Task RemoveMember(int teamId, int memId);

    }
}
