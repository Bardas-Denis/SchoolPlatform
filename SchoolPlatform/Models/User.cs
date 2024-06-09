using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public enum Roles
    {
        Admin,
        Student,
        Teacher,
        HomeroomTeacher
    }
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

    }
}
