using System;
using UnityEngine;

public class TimeTickSystem : MonoBehaviour
{
    private const float TickTimerMax = 2f;
    
    private int tick;
    private float tickTimer;

    private void Awake()
    {
        tick = 0;
    }

    private void Update()
    {
        tickTimer += Time.deltaTime;
        if (tickTimer >= TickTimerMax)
        {
            tickTimer -= TickTimerMax;
            tick++;
        }
        if (tick > 8)
        {
            tick = 0;
        }
    }

    public int TickCheck()
    {
        return tick;
    }
}
