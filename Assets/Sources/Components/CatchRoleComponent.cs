using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public sealed class CatchRoleComponent : IComponent
{
    public RoleType value;
}

