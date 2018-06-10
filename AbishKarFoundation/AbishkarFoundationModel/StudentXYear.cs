using System;
using System.Collections.Generic;
using System.Text;

namespace AbishkarFoundation.Model
{
   public class StudentXYear
    {
        public virtual int StudentXYearId { get; set; }
        public virtual User User { get; set; } 
        public virtual School School { get; set; }
        public virtual string Year { get; set; } 
        public virtual Standard Standard { get; set; }
        public virtual List<Subject> Subjects { get; set; }
    }
}
