using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagement.Domain.Entities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        // Navigation Property for Members
        public ICollection<TeamMember> Members { get; set; }
    }
}
