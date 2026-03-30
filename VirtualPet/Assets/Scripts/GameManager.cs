using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public PetCreature creature;
    public TimeTickSystem ticker;
    public TMP_Text hungerText;
    public TMP_Text cleanlinessText;
    public TMP_Text boredomText;
    public Text timerText;
    public GameObject creaturePanel;
    public GameObject winScreen;
    public GameObject lossScreen;
    private bool _isDead;
    
    public int currentTick;
    public int lastTick;

    private int _finalTimer = 0;
    //get tick object and get tick 

    private void Start()
    {
        _isDead = false;
        currentTick = ticker.TickCheck();
        lastTick = currentTick;
        hungerText.text = "100";
        cleanlinessText.text = "100";
        boredomText.text = "100";
    }

    private void Update()
    {
        currentTick = ticker.TickCheck();
        if (currentTick != lastTick)
        {
            _finalTimer += 1;
            timerText.text = currentTick < 10 ? "0" + currentTick : "" + currentTick;
            
            _checkIfOver();
            creature.SubtractCare(currentTick);
        }
        lastTick = currentTick;
        
        if (creature.GetHunger() < 0 && creature.GetCleanliness() < 0 || creature.GetBoredom() < 0)
        { 
            KillCreature();
        }
        hungerText.text = creature.GetHunger().ToString();
        cleanlinessText.text = creature.GetCleanliness().ToString();
        boredomText.text = creature.GetBoredom().ToString();
    }

    public void KillCreature()
    {
        _isDead = true;
        creaturePanel.SetActive(false);
        lossScreen.SetActive(true);
    }

    private void _checkIfOver()
    {
        if (_finalTimer == 45 && !_isDead)
        {
            creature.SetOver();
            creaturePanel.SetActive(false);
            winScreen.SetActive(true);
        }
    }
    
}
