using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizTeam.Domain.Entities;
using QuizTeam.Domain.IRepos;

namespace QuizTeam.Data
{
    public class MemberRepo : IMemberRepo
    {
        private readonly QuizTeamDbContext db=new QuizTeamDbContext();
        public async Task<List<Member>> GetAllMembers()
        {
            var members = db.Members.Include(m => m.Team).Where(m=>m.TeamId==null);
            return await members.ToListAsync();
        }

        public async Task<Member> GetMemberById(int id)
        {
           return await db.Members.FindAsync(id);
        }
    }
}
