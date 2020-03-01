﻿namespace Clean.Common
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        protected int Id { get; set; }

        protected string Name { get; set; } = string.Empty;

        private string Description { get; } = string.Empty;

        public override bool Equals(object obj)
        {
            return obj is T valueObject && EqualsCore(valueObject);
        }

        private bool EqualsCore(T other)
        {
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        private int GetHashCodeCore()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ Name.GetHashCode();
                hashCode = (hashCode * 397) ^ Description.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}