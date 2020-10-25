using System;

namespace BookInfoApp.Core.Entities
{
    public interface IEntity
    {
    }

    public interface IEntity<TId> : IEntity where TId : IEquatable<TId>
    {
        TId Id { get; set; }
    }
}
