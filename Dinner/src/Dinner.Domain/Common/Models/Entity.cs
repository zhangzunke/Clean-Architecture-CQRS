using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Common.Models
{
    public abstract class Entity<TKey> : IEquatable<Entity<TKey>> where TKey : notnull
    {
        public TKey Id { get; protected set; }
        protected Entity(TKey id) => Id = id;

        public override bool Equals(object? obj)
        {
            return obj is Entity<TKey> entity && Id.Equals(entity.Id);
        }

        public bool Equals(Entity<TKey>? other)
        {
            return Equals((object?)other);
        }

        public static bool operator ==(Entity<TKey> left, Entity<TKey> right) => Equals(left, right);
        public static bool operator !=(Entity<TKey> left, Entity<TKey> right) => !Equals(left, right);

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

#pragma warning disable CS8618
        protected Entity()
        {

        }
#pragma warning restore CS8618
    }
}
