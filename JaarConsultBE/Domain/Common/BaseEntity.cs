using System;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
    }
}
