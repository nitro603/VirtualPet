using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public PetCreature creature;
    public TimeTickSystem ticker;
    public TMP_Text hungerText;
    public TMP_Text cleanlinessText;
    public TMP_Text boredomText;
    public GameObject winScreen;
    public GameObject creaturePanel;
    
    public int currentTick;
    public int lastTick;

    private int _finalTimer = 0;
//get tick object and get tick 

    private void Start()
    {
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
            if (_finalTimer == 45)
            {
                Destroy(creaturePanel);
                winScreen.SetActive(true);
            }
            creature.SubtractCare(currentTick);
        }
        lastTick = currentTick;

        hungerText.text = creature.GetHunger().ToString();
        cleanlinessText.text = creature.GetCleanliness().ToString();
        boredomText.text = creature.GetBoredom().ToString();
    }
    
    
    
}
