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
    public GameObject creaturePanel;
    public GameObject lossScreen;
    
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

    private void UpdateStat(ref int stat, Slider bar, int amount)
    {
        stat -= amount;
        bar.value -= amount;
    }
    
    public void SubtractCare(int tick)
    {
        UpdateStat(ref _currentHungry, hungerBar, 2);

        if (tick % 4 == 0)
        {
            UpdateStat(ref _currentCleanliness, cleanlinessBar, 16);
        }

        if (tick % 8 == 0)
        {
            UpdateStat(ref _currentBoredom, boredomBar,42);
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

    private void IsDead()
    {
        Debug.Log(_currentHungry + " " + _currentCleanliness + " " + _currentBoredom + "");
        if (_currentHungry < 0 && _currentCleanliness < 0 || _currentBoredom < 0)
        {
            creaturePanel.SetActive(false);
            lossScreen.SetActive(true);

        }
    }
    public void PlayCrunchSfx()
    {
        crunchSfx.Play();
    }
}
