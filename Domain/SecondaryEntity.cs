using System;

namespace EFPlusTest.Domain
{
    public class SecondaryEntity
    {
        protected SecondaryEntity()
        {

        }

        public SecondaryEntity(string propertyA, string propertyB, string propertyC)
        {
            PropertyA = propertyA;
            PropertyB = propertyB;
            PropertyC = propertyC;
        }

        public Guid Id { get; protected set; }
        public string PropertyA { get; protected set; }
        public string PropertyB { get; protected set; }
        public string PropertyC { get; protected set; }

        public override bool Equals(object obj)
        {
            var other = obj as SecondaryEntity;
            return other != null &&
                other.PropertyA == PropertyA &&
                other.PropertyB == PropertyB;
        }

        public override int GetHashCode()
        {
            return $"{PropertyA}_{PropertyB}".GetHashCode();
        }

    }
}