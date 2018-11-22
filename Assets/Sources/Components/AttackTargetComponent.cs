using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public sealed class AttackTargetComponent : IComponent
{
    public RoleType value;
}


