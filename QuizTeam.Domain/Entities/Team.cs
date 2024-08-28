﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTeam.Domain.Entities
{
    public class Team
    {
        public int TeamId {  get; set; }
        public string Name { get; set; }
        public List<Member> Members { get; set; }= new List<Member>();
    }
}
