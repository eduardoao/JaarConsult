using System;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get;  set; }
        public DateTime DataCriacao { get; private set; }
    }
}
