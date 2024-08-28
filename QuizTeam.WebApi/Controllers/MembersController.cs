using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizTeam.Data;
using QuizTeam.Domain.Entities;

namespace QuizTeam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly MemberRepo memberRepo=new MemberRepo();
        [HttpGet]
        //...api/members
        public async Task<List<Member>> GetMembers()
        {
            return await memberRepo.GetAllMembers();
        }

        [HttpGet]
        [Route("{id}")]
        [Consumes("application/json")]
        //...api/members/1
        public async Task<IActionResult> GetMemberById(int id)
        {
            var member = await memberRepo.GetMemberById(id);
            if (member == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(member);
            }
        }
    }
}
