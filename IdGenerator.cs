namespace Dependency_Injection;

public class IdGenerator
{
    public Guid Id { get; } = Guid.NewGuid();
}