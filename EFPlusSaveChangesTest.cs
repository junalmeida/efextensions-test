using EFPlusTest.Data;
using EFPlusTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFPlusTest
{
    [TestClass]
    public class EFPlusSaveChangesTest
    {
        private Guid _testRound;
        private MainEntity _data;

        [TestInitialize]
        public void Given()
        {
            _testRound = Guid.NewGuid();
            _data = new MainEntity(_testRound);

            // Please read SecondaryEntity Equals & GetHashCode. 
            var secondaries = Enumerable.Range(0, 100).Select((i) => new SecondaryEntity($"Prop A {i}", $"Prop B {i}", $"Prop C {i}"));
            var duplicatedSecondaries = Enumerable.Range(0, 100).Select((i) => new SecondaryEntity($"Prop A {i}", $"Prop B {i}", $"Prop C {i}"));

            ((List<SecondaryEntity>)_data.Secondaries).AddRange(secondaries);
            ((List<SecondaryEntity>)_data.Secondaries).AddRange(duplicatedSecondaries);
        }



        [TestMethod]
        public async Task ShouldSaveWhenUsingNativeSaveChanges()
        {

            using (var _db = new TestEfContext())
            {
                _db.MainEntitites.Add(_data);
                await _db.SaveChangesAsync();
            }


            using (var _db = new TestEfContext())
            {
                var created = await _db.MainEntitites
                    .Where(x => x.TestRound == _testRound)
                    .Include(x => x.Secondaries)
                    .SingleOrDefaultAsync();
                Assert.IsNotNull(created);
                Assert.AreEqual(_data.Secondaries.Count, created.Secondaries.Count);
            }
        }

        [TestMethod]
        public async Task ShouldSaveWhenUsingBulkSaveChanges()
        {
            using (var _db = new TestEfContext())
            {
                _db.MainEntitites.Add(_data);
                await _db.BulkSaveChangesAsync();
            }

            using (var _db = new TestEfContext())
            {
                var created = await _db.MainEntitites
                    .Where(x => x.TestRound == _testRound)
                    .Include(x => x.Secondaries)
                    .SingleOrDefaultAsync();
                Assert.IsNotNull(created);
                Assert.AreEqual(_data.Secondaries.Count, created.Secondaries.Count);
            }
        }
    }
}
