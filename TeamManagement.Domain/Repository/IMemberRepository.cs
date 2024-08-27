using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagement.Domain.Entities;

namespace TeamManagement.Domain.Repository
{
    public interface IMemberRepository
    {
        List<TeamMember> GetAll();
        TeamMember GetMemberByID(int MemId);
    }
}
