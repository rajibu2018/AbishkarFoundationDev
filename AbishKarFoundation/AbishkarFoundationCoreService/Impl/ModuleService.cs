using AbhiskarFoudation.Bo;
using AbishkarFoundation.CoreService.Interfaces;
using AbishkarFoundation.Repository.Interfaces;
using System;
using System.Collections.Generic;


namespace AbishkarFoundation.CoreService.Impl
{
    public class ModuleService : IModuleService
    {
        private ITestSetRepository TestSetRepository { get; set; }
        public ModuleService(ITestSetRepository testSetRepository)
        {
            TestSetRepository = testSetRepository;
        }
        public List<TestSetBo> GetTestSetBos(string userId)
        {
            if(string.IsNullOrEmpty(userId))
            {
                throw new ApplicationException("Not a valid user");
            }
            var user = 0;
            if(!int.TryParse(userId, out user))
            {
                throw new ApplicationException("Not a valid user");
            }
            return TestSetRepository.GetTestSetByUser(user);
        }
    }
}
