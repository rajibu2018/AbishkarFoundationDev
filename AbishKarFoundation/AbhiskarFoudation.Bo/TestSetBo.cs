using AbishkarFoundation.Model;
using System;

namespace AbhiskarFoudation.Bo
{
    public class TestSetBo
    {
        public int TestSetId { get; set; }
        public string TestName { get; set; }
        public DateTime CreateDate { get; set; }
        public string AccessType { get; set; }
        public bool RepeatedAccess { get; set; }
        public int? Duration { get; set; }
        public DateTime? ActiveUpto { get; set; }
        public bool Active { get; set; }
        public int NumberOfAttender { get; set; }
        public int NumberOfQuestion { get; set; }
    }
}
