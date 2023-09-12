using Domain.Core.Interfaces;
using System.Security.Principal;

namespace Domain.Core
{
    public class Entity<TId> : IEquatable<Entity<TId>>, IEntity
        where TId : IEquatable<TId>
    {
        public virtual TId Id { get; protected set; }
        public override bool Equals(object other)
        {
            if (other is Entity<TId> entity)
            {
                return this.Equals(entity);
            }
            return base.Equals(other);
        }

        public virtual bool Equals(Entity<TId> other)
        {
            if (other is null)
            {
                return false;
            }
            return this.Id.Equals(other.Id);
        }
        public static bool operator ==(Entity<TId> x, Entity<TId> y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Entity<TId> x, Entity<TId> y)
        {
            return !(x == y);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + this.Id).GetHashCode();
        }
    }
}