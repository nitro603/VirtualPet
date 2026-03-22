using System;
using UnityEngine;

public class TimeTickSystem : MonoBehaviour
{
    private const float TickTimerMax = 1f;
    
    private int _tick;
    private float _tickTimer;
    
    private void Awake()
    {
        _tick = 0;
    }
    
    private void Update()
    {
        //this will keep counting till the END OF TIME
        _tickTimer += Time.deltaTime;
        if (_tickTimer >= TickTimerMax)
        {
            _tickTimer -= TickTimerMax;
            _tick++;
        }
    }

    public int TickCheck()
    {
        return _tick;
    }
}
