using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamManagement.Domain.Repository;
using TeamManagement.Domain.Entities;
namespace TeamManagement.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        ITeamRepository _teamRepo;

        public TeamsController(ITeamRepository teamRepo) 
        {
            _teamRepo = teamRepo;
        }



        [HttpGet]
        [Consumes("application/json")]

        public IActionResult GetAllMembersOfTeam(int id) 
        {
            var team = _teamRepo.GetAllTeamMembers(id);
            if (team == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(team);
        }



        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType<Team>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<Team>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<Team>(StatusCodes.Status200OK)]

        public IActionResult Add(int teamId, int memId) 
        {
            
            //calling the methd
            _teamRepo.AddMember(teamId, memId);

            return NoContent();
            


        }

        [HttpDelete]
        [Consumes("application/json")]
        public IActionResult Delete(int teamId, int memId)
        {
            _teamRepo.RemoveMember(teamId, memId);
            return Ok();
        }


    }
}
