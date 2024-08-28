using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizTeam.Data;
using QuizTeam.Domain.Entities;

namespace QuizTeam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly TeamRepo repo=new TeamRepo();

        [HttpGet]
        [Consumes("application/json")]
        //...api/teams
        public async Task<IActionResult> GetAllTeamsAsync()
        {
            return Ok(await repo.GetAllTeams());
        }

        [HttpGet]
        [Route("{id}")]
        [Consumes("application/json")]
        //...api/teams/1
        public async Task<IActionResult> GetTeamByIdAsync(int id)
        {
            var team = await repo.GetTeamById(id);
            if(team == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(team);
            }
        }

        [HttpPatch]
        [Consumes("application/json")]
        //.../api/teams/1
        public async Task<IActionResult> UpdateTeam([FromQuery] int id, [FromBody] Team team)
        {
            //find team
            var teamToUpdate = await repo.GetTeamById(id);
            if (teamToUpdate== null)
            {
                return NotFound();
            }
            //validate
            if (!ModelState.IsValid||team.TeamId!=id)
            {
                return BadRequest(ModelState);
            }

            await repo.UpdateTeam(team);
            return Ok(team);

        }

    }
}
