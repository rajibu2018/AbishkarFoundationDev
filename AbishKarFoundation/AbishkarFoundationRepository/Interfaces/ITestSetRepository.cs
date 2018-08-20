using AbhiskarFoudation.Bo;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbishkarFoundation.Repository.Interfaces
{
   public interface ITestSetRepository
    {
        List<TestSetBo> GetTestSetByUser(int userId);
    }
}
