using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizTeam.Domain.Entities;
using QuizTeam.Domain.IRepo;

namespace QuizTeam.Data
{
    public class TeamRepo : ITeamRepo
    {
        private readonly QuizTeamDbContext db = new QuizTeamDbContext();
        public async Task<List<Team>> GetAllTeams()
        {
            var teams =  db.Teams
                .Include(t => t.Members);// Ensuring Members are loaded with the team
            return await teams.ToListAsync();
        }

        public async Task<Team> GetTeamById(int id)
        {
            return await db.Teams.FindAsync(id);
        }

        public async Task<Team> UpdateTeam(Team team)
        {
            db.Teams.Update(team);
            return team;
        }

        #region methods in case required
        //public async Task<List<Member>> GetAllMembersFromTeam(int teamId)
        //{
        //    // Fetch the member and team from the database
        //    var team = await db.Teams
        //        .Include(t => t.Members) // Ensuring Members are loaded with the team
        //        .FirstOrDefaultAsync(t => t.TeamId == teamId);
        //    if (team != null)
        //        return team.Members;
        //    else throw new Exception("No Such Team Found");
        //}

        //public async Task AddMemberToTeam(int memberId, int TeamId)
        //{
        //    var member = await db.Members.FindAsync(memberId);
        //    var team = await db.Teams.FindAsync(TeamId);

        //    if (team != null)
        //    {
        //        if (member == null)
        //        {
        //            throw new Exception("Member not found.");
        //        }

        //        // Check if the member is already part of the team
        //        if (team.Members.Any(m => m.Id == memberId))
        //        {
        //            throw new Exception("Member is already part of this team.");
        //        }

        //        team.Members.Add(member);
        //        await db.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        throw new Exception("Team not found.");
        //    }
        //}

        //public async Task RemoveMemberFromTeam(int memberId, int teamId)
        //{
        //    // Fetch the member and team from the database
        //    var team = await db.Teams
        //        .Include(t => t.Members) // Ensure Members are loaded with the team
        //        .FirstOrDefaultAsync(t => t.TeamId == teamId);

        //    if (team != null)
        //    {
        //        var member = team.Members.FirstOrDefault(m => m.Id == memberId);

        //        if (member != null)
        //        {
        //            // Remove the member from the team's collection
        //            team.Members.Remove(member);

        //            // Save changes to the database
        //            await db.SaveChangesAsync();
        //        }
        //        else
        //        {
        //            throw new Exception("Member not found in this team.");
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("Team not found.");
        //    }
        //}
        #endregion

    }
}
