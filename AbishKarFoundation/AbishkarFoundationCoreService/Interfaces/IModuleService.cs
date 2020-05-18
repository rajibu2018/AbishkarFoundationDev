using AbhiskarFoudation.Bo;
using AbishkarFoundation.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbishkarFoundation.CoreService.Interfaces
{
    public interface IModuleService
    {
        List<TestSetBo> GetTestSetBos(string userId);
        TestSet SaveTestSet(TestSet test,int creator);
        TestSet GetTestSet(int testSetId);
    }
}
