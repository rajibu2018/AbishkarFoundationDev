using System;
using System.Collections.Generic;
using System.Text;

namespace AbishkarFoundation.Model
{
   public class TestSet
    {
        public virtual int TestSetId { get; set; }
        public virtual string TestName { get; set; }
        public virtual User Creator { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual TestSetAccessType AccessType { get; set; }
        public virtual bool RepeatedAccess { get; set; }
        public virtual int? Duration { get; set; } 
        public virtual DateTime? ActiveUpto { get; set; }
        public virtual bool Active { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
    }
}
