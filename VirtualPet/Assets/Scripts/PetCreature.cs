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
    public AudioSource crunchSfx;
    
    private int _currentHungry;
    private int _currentCleanliness;
    private int _currentBoredom;

    private bool _isOver;

    void Start()
    {
        _isOver = false;
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

    private void UpdateStat(ref int stat, Slider bar, int amount)
    {
        if (!_isOver)
        {
            stat -= amount;
            bar.value -= amount;
        }
        
    }
    
    public void SubtractCare(int tick)
    {
        //checking if we're currently 0-15, 15-35, or above
        int paceState = tick < 15 ? 0 : tick > 15 & tick < 35 ? 1 : 2;
        //setting rates for hunger, cleanliness, boredom
        int hungerRate = paceState == 0 ? 1:paceState == 1 ? 2 : 4;
        int cleanlinessRate = paceState == 0 ? 8:paceState == 1? 16: 20;
        int boredomRate = paceState == 0 ? 20:paceState == 1 ? 32: 46;
        
        UpdateStat(ref _currentHungry, hungerBar, hungerRate);
        if (tick % 4 == 0)
        {
            UpdateStat(ref _currentCleanliness, cleanlinessBar, cleanlinessRate);
        }
        
        if (tick % 8 == 0)
        {
            UpdateStat(ref _currentBoredom, boredomBar,boredomRate);
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

    public void SetOver()
    {
        _isOver = true;
    }
    
    public void PlayCrunchSfx()
    {
        crunchSfx.Play();
    }
}
