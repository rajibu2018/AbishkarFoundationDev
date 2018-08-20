using AbhiskarFoudation.Bo;
using AbishkarFoundation.Model;
using AbishkarFoundation.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbishkarFoundation.Repository.Impl
{
    public class TestSetRepository : RepositoryBase, ITestSetRepository
    {
        public List<TestSetBo> GetTestSetByUser(int userId)
        {
            throw new NotImplementedException();
            //var query= _session.QueryOver<TestSet>().Where(t=>t.Creator.UserId==userId);
            
        }
    }
}
