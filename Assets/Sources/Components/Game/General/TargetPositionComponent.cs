using Entitas;
using Entitas.CodeGeneration.Attributes;
    
[Event(EventTarget.Self)]
public class TargetPositionComponent : IComponent
{
    public UnityEngine.Vector3 value;
}

