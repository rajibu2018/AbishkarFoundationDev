using AbishkarFoundation.Model;
using System;
using System.Collections.Generic;

namespace AbishkarFoundation.Web.ViewModel.Module
{
    public class TestSetViewModel
    {
        public List<TestSet> TestSets { get; set; }
        public TestSetViewModel()
        {
            TestSets = new List<TestSet>();
        }
    }

    public class TestSet : TestSetBase
    {

        public int NumberOfAttender { get; set; }
        public int NumberOfQuestions { get; set; }
        public int TestSetId { get; set; }
        public bool TestName { get; set; }
        public DateTime CreateDate { get; set; }
        public TestSetAccessType AccessType { get; set; }
        public bool RepeatedAccess { get; set; }
        public int? Duration { get; set; }
        public DateTime? ActiveUpto { get; set; }
        public bool Active { get; set; }
    }
    public interface TestSetBase
    {
        int TestSetId { get; set; }
        bool TestName { get; set; }
        DateTime CreateDate { get; set; }
        TestSetAccessType AccessType { get; set; }
        bool RepeatedAccess { get; set; }
        int? Duration { get; set; }
        DateTime? ActiveUpto { get; set; }
        bool Active { get; set; }
    }
}
