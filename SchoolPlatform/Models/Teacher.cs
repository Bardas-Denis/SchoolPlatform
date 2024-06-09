using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public int PersonId { get; set; }
        public string Degree { get; set; }

        public Person Person { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }

    }
}
