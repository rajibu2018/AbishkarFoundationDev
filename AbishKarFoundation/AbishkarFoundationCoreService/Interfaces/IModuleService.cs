using AbhiskarFoudation.Bo;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbishkarFoundation.CoreService.Interfaces
{
    public interface IModuleService
    {
        List<TestSetBo> GetTestSetBos(string userId);
    }
}
