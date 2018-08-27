using AbishkarFoundation.Model;
using System;

namespace AbhiskarFoudation.Bo
{
    public class TestSetBo
    {
        public  int TestSetId { get; set; }
        public  bool TestName { get; set; }
        public  DateTime CreateDate { get; set; }
        public  TestSetAccessType AccessType { get; set; }
        public  bool RepeatedAccess { get; set; }
        public  int? Duration { get; set; }
        public  DateTime? ActiveUpto { get; set; }
        public  bool Active { get; set; }
        public int NumberOfAttender {  get; set; }
        public int NumberOfQuestions { get; set; }
    }
}
