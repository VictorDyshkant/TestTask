namespace Abstraction.Entities;

public abstract class Entity<TPrimaryKey>
{
    public TPrimaryKey Id { get; set; }
}
