﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual Student Student { get; set; }
        public virtual HomeroomTeacher HomeroomTeacher { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
