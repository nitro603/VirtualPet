using System;
using UnityEngine;
using UnityEngine.Rendering;

public class PetCreature : MonoBehaviour
{
    private Animator _animator;
    
    private int _currentHungry;
    private int _currentCleanliness;
    private int _currentBoredom;
    

    void Start()
    {
        _currentHungry = 100;
        _currentCleanliness = 100;
        _currentBoredom = 100;

        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (_currentHungry < 30)
        {
            _animator.SetBool("isHungry",true);
        }
        if (_currentCleanliness < 40)
        {
            _animator.SetBool("isUnclean",true);
        }
        if (_currentBoredom < 50)
        {
            _animator.SetBool("isBored",true);
        }
        //chopped if statements 
        if (_currentHungry > 30)
        {
            _animator.SetBool("isHungry",false);
        }
        if (_currentCleanliness > 40)
        {
            _animator.SetBool("isUnclean",false);
        }
        if (_currentBoredom > 50)
        {
            _animator.SetBool("isBored",false);
        }
    }

    public void SubtractCare(int tick)
    {
        Debug.Log(tick);
        _currentHungry -= 2;
        switch (tick)
        {
            case 2: case 4:
                _currentCleanliness -= 5;
                break;
            case 5:
                _currentBoredom -= 25;
                break;
        }
    }

    public int GetHunger()
    {
        return _currentHungry;
    }
    public int GetCleanliness()
    {
        return _currentCleanliness;
    }
    public int GetBoredom()
    {
        return _currentBoredom;
    }

    public void RecoverHungerStatus()
    {
        _currentHungry += 2;
    }
    public void RecoverCleanlinessStatus()
    {
        _currentCleanliness += 2;
    }
    public void RecoverBoredomStatus()
    {
        _currentBoredom += 2;
    }
    
}
