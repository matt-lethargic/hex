using System;

namespace Acme.Core.Kernal
{
    public abstract class Entity
    {
        public Guid Id { get; }

        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}
