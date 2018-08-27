using AbhiskarFoudation.Bo;
using AbishkarFoundation.Model;
using AbishkarFoundation.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbishkarFoundation.Repository.Impl
{
    public class TestSetRepository : RepositoryBase, ITestSetRepository
    {
        public List<TestSetBo> GetTestSetByUser(int userId)
        {
            //throw new NotImplementedException();
            //var query= _session.QueryOver<TestSet>().Where(t=>t.Creator.UserId==userId);
            return _session.CreateQuery("select TestSetId,AccessType,CreatreDate,RepeatedAccess,Duration,ActiveUpto from TestSet t join(select count(QuestionId) NumberOfQuestion, TestSet_id from Question group by TestSet_id) q on t.TestSetId = q.TestSet_id where t.Creator_id =" + userId).Future<TestSetBo>().ToList();
        }
    }
}
