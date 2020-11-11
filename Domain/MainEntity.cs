using System;
using System.Collections.Generic;

namespace EFPlusTest.Domain
{
    public class MainEntity
    {
        protected MainEntity()
        {

        }
        public MainEntity(Guid testRound)
        {
            TestRound = testRound;
        }

        public Guid Id { get; protected set; }
        public Guid TestRound { get; protected set; }
        public IList<SecondaryEntity> Secondaries { get; protected set; } = new List<SecondaryEntity>();
    }
}
