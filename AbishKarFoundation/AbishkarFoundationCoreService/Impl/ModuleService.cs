﻿using AbhiskarFoudation.Bo;
using AbishkarFoundation.CoreService.Interfaces;
using AbishkarFoundation.Model;
using AbishkarFoundation.Repository.Interfaces;
using System;
using System.Collections.Generic;


namespace AbishkarFoundation.CoreService.Impl
{
    public class ModuleService : IModuleService
    {
        private ITestSetRepository TestSetRepository { get; set; }
        private IUserRepository UserRepository { get; set; }
        public ModuleService(ITestSetRepository testSetRepository, IUserRepository userRepository)
        {
            TestSetRepository = testSetRepository;
            UserRepository = userRepository;
        }
        public List<TestSetBo> GetTestSetBos(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ApplicationException("Not a valid user");
            }
            var user = 0;
            if (!int.TryParse(userId, out user))
            {
                throw new ApplicationException("Not a valid user");
            }
            return TestSetRepository.GetTestSetByUser(user);
        }

        public TestSet SaveTestSet(TestSet testSet,int creator)
        {
            if (string.IsNullOrEmpty(testSet.TestName))
            {
                throw new ApplicationException("Test name is required");
            }
            
            if (testSet.TestSetId == 0)
            {
                testSet.Creator = UserRepository.GetUserById(creator);
            }
            else
            {
                testSet.UpdateDate = DateTime.Now;
            }
            return TestSetRepository.SaveTestSet(testSet);
        }

        public TestSet GetTestSet(int testSetId)
        {
            if(testSetId<=0)
            {
                throw new ApplicationException("Not a valid module");
            }

            return TestSetRepository.GetTestSet(testSetId);
        }
    }
}
