using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public sealed class GameMonsterComponent : IComponent{

    [EntityIndex]
    public int value;  //记录怪物索引
}
