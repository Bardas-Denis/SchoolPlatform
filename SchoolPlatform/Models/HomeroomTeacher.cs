using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class HomeroomTeacher
    {
        public int HomeroomTeacherId { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Class Class { get; set; }
    }
}
