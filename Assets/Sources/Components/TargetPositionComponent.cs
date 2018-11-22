using Entitas;
using Entitas.CodeGeneration.Attributes;
    
[Event(EventTarget.Self)]
public class TargetPositionComponent : IComponent
{
    public FloatVector3 value;
}

