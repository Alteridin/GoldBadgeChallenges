using System;
using System.Collections.Generic;
using KomodoClaims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsTests
{
    [TestClass]
    public class ClaimsTests
    {
        [TestMethod]
        public void AddContentToQueue_ShouldGetCorrectBool()
        {
            Claims content = new Claims();
            ClaimsRepository repo = new ClaimsRepository();
            bool addResult = repo.AddContentToQueue(content);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectQueue()
        {
            Claims testContent = new Claims();
            ClaimsRepository repo = new ClaimsRepository();
            repo.AddContentToQueue(testContent);
            Queue<Claims> testList = repo.GetClaims();
            bool queueHasContent = testList.Contains(testContent);
            Assert.IsTrue(queueHasContent);
        }
        private ClaimsRepository _repo;
        private Claims _queue;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepository();
            _queue = new Claims(1, ClaimTypes.Car, "rear vehicle collision while at stop sign.", 3000.00m, DateTime.Parse("05/04/1988"), DateTime.Parse("06/03/1988"), true);
            _repo.AddContentToQueue(_queue);
        }
    }
}
