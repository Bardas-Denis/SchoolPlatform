using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public int HomeroomTeacherId { get; set; }
        public string Specialization { get; set; }
        public int GradeLevel { get; set;}

        public virtual HomeroomTeacher HomeroomTeacher { get; set; }
        public virtual ICollection<Student> Students { get; set; } 
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
    }
}
