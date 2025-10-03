using System;
using UnityEngine;

public class RandomManager : Singleton<RandomManager>
{
    [SerializeField] private bool _usePregenSeed = false;
    public int PregenSeed;

    [SerializeField] private int _seedDebug = 0;
    public System.Random Random { get; private set; }

    public override void Awake()
    {
        Setup();
    }

    public void Setup(int seed = 0)
    {
        _seedDebug = Environment.TickCount;
        if (seed == 0)
        {
            Random = new System.Random(_seedDebug);
        }
        else
        {
            Random = new System.Random(seed);
        }
    }

    public bool RollPercentile(float percentChance)
    {
        float clamped = Mathf.Clamp(percentChance, 0f, 1f);
        float roll = Random.Next(0, 100)/100f;

        if(roll <= clamped)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
