using System;
using System.Collections.Generic;

public sealed class RandomService
{
    public static RandomService gameScene = new RandomService();
    public static RandomService gameLogic = new RandomService();

    Random _random;

    public void Initialize(int seed)
    {
        _random = new Random(seed);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="chance" 范围 0~1></param>
    /// <returns></returns>
    public bool Bool(float chance)
    {
        return Float() < chance;
    }

    public int Int()
    {
        return _random.Next();
    }

    public int Int(int maxValue)
    {
        return _random.Next(maxValue);
    }

    public int Int(int minValue, int maxValue)
    {
        return _random.Next(minValue, maxValue);
    }

    public float Float()
    {
        return (float)_random.NextDouble();
    }

    public float Float(float minValue, float maxValue)
    {
        return minValue + (maxValue - minValue) * Float();
    }

}
