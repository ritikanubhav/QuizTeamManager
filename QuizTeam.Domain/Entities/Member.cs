﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTeam.Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TeamId {  get; set; }
        public Team? Team { get; set; }
    }
}
