using AbishkarFoundation.Repository.Interfaces;
using System;
using NUnit.Framework;
using AbishkarFoundation.Repository.Impl;
using AbishkarFoundation.Repository;
using Microsoft.Extensions.Options;

namespace AbishkarFoundation.UnitTest.Repository
{
    public class TestSetRepositoryTests
    {
        public ITestSetRepository TestSetRepository { get; set; }
        //private static AppSettings AppSettings { get; set; }
        public TestSetRepositoryTests( ITestSetRepository testSetRepository)
        {
            //AppSettings = settings.Value;
            //TestSetRepository = testSetRepository;
        }
        [SetUp]
        public void SetUp()
        {
           TestSetRepository = new TestSetRepository();
        }

        [Test]
        public void GetTestSet()
        {
            var result = TestSetRepository.GetTestSetByUser(1);
            Assert.AreEqual(1, 1);
        }


    }
}
