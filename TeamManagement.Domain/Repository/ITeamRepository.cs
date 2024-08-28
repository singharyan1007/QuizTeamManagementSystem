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
        List<TeamMember> GetAllTeamMembers(int teamId);
        List<Team> GetAll();
        void AddMember(int teamId, int memId);
         void RemoveMember(int teamId, int memId);

    }
}
