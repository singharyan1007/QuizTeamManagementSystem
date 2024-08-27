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
    public class MemberRepository : IMemberRepository
    {
        TeamManageContext _manageContext;
        public MemberRepository(TeamManageContext manageContext)
        {
            _manageContext = manageContext;
        }
        public  List<TeamMember> GetAll()
        {
            return _manageContext.Members.ToList();

        }

        public TeamMember GetMemberByID(int MemId)
        {
            return _manageContext.Members.FirstOrDefault(member => MemId == member.MemberId);
            
        }

       
    }
}
