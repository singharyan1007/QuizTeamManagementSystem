using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagement.Domain.Entities
{
    public class TeamMember
    {
        [Key]
        public int MemberId { get; set; }
        public string Name { get; set; }

        // Foreign Key to Team
        [ForeignKey("Team")]
        public int? TeamId { get; set; }
        public Team Team { get; set; }
    }
}
