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
        if (tick > 5 && tickTimer > 0)
        {
            //Function: It resets tick so that it doesn't go past 10 seconds tracked
            tick = 0;
        }
    }

    public int TickCheck()
    {
        return tick;
    }
}
