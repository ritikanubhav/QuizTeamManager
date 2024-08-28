using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizTeam.Domain.Entities;

namespace QuizTeam.Domain.IRepos
{
    public interface IMemberRepo
    {
        public Task<List<Member>> GetAllMembers();
        public Task<Member> GetMemberById(int id);
    }
}
