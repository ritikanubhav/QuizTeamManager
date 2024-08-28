using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizTeam.Domain.Entities;

namespace QuizTeam.Domain.IRepo
{
    public interface ITeamRepo
    {
        public Task<List<Team>> GetAllTeams();
        public Task<Team> GetTeamById(int id);

        public Task<Team> UpdateTeam(Team team);

        //public Task<List<Member>> GetAllMembersFromTeam(int TeamId);
        //public Task AddMemberToTeam(int memberId,int TeamId);
        //public Task RemoveMemberFromTeam(int memberId, int TeamId);

    }
}
