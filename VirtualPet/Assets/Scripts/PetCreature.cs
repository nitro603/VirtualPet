using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PetCreature : MonoBehaviour
{
    private Animator _animator;
    public Animator overlayAnimator;
    public Slider hungerBar;
    public Slider cleanlinessBar;
    public Slider boredomBar;
    
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
        if (hungerBar.value != _currentHungry)
        {
            hungerBar.value = _currentHungry;
        }
        if (cleanlinessBar.value != _currentCleanliness)
        {
            cleanlinessBar.value = _currentCleanliness;
        }
        if (boredomBar.value != _currentBoredom)
        {
            boredomBar.value = _currentBoredom;
        }
        
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
        hungerBar.value -= 2;
        switch (tick)
        {
            case 2: case 4:
                _currentCleanliness -= 5;
                cleanlinessBar.value -= 5;
                break;
            case 5:
                _currentBoredom -= 25;
                boredomBar.value -= 25;
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
        hungerBar.value += 2;
        _animator.SetTrigger("Feed");
    }
    public void RecoverCleanlinessStatus()
    {
        _currentCleanliness += 2;
        cleanlinessBar.value += 2;
        overlayAnimator.SetTrigger("Shower");
    }
    public void RecoverBoredomStatus()
    {
        _currentBoredom += 2;
        boredomBar.value += 2;
        overlayAnimator.SetTrigger("Brick");
    }
    
}
