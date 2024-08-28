using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamManagement.Domain.Repository;

namespace TeamManagement.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        IMemberRepository _memRepo;
        public MembersController(IMemberRepository memRepo) { _memRepo = memRepo; }

        [HttpGet]
        [Consumes("application/json")]

        public IActionResult GetAllAvailableMembers() 
        {
            var mems = _memRepo.GetAll();
            if (mems == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mems);
        }
    }
}
