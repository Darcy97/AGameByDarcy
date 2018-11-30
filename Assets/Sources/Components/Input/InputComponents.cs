using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input][Unique]
public sealed class InputMouseDownComponent : IComponent {}

[Input][Unique]
public sealed class InputKeyComponent : IComponent
{
    public string value;
}
