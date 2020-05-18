using AbhiskarFoudation.Bo;
using AbishkarFoundation.Model;
using System.Collections.Generic;

namespace AbishkarFoundation.Repository.Interfaces
{
    public interface ITestSetRepository
    {
        List<TestSetBo> GetTestSetByUser(int userId);
        TestSet SaveTestSet(TestSet testSet);
        TestSet GetTestSet(int testSetId);
    }
}
