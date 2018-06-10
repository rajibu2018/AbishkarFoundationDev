using System;
using System.Collections.Generic;
using System.Text;

namespace AbishkarFoundation.Model
{
    public class School
    {
        public virtual int SchoolId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string Description{get;set;}
    }
}
