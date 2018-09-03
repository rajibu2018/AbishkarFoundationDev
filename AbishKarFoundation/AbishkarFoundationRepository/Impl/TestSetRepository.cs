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
        public TestSet SaveTestSet(TestSet testSet)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                try
                {
                    repository.BeginTransaction();
                    _session.SaveOrUpdate(testSet);
                    repository.CommitTransaction();
                }
                catch (Exception ex)
                {
                    repository.RollbackTransaction();
                    throw ex;
                }
            }
            return testSet;
        }

        public List<TestSetBo> GetTestSetByUser(int userId)
        {
            //throw new NotImplementedException();
            //var query= _session.QueryOver<TestSet>().Where(t=>t.Creator.UserId==userId);
            return _session.CreateSQLQuery("select TestSetId,TestName,AccessType,CreateDate,RepeatedAccess,Duration,ActiveUpto, NumberOfQuestion,Active,0 as NumberOfAttender from TestSet t left join(select count(QuestionId) NumberOfQuestion, TestSet_id from Question group by TestSet_id) q on t.TestSetId = q.TestSet_id where t.Creator_id =:userId").SetParameter("userId", userId)
            .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean<TestSetBo>())
            .List<TestSetBo>().ToList(); ;
        }
    }
}
