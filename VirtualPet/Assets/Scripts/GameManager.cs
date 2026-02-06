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
    
    public int currentTick;
    public int lastTick;
    //get tick object and get tick 

    private void Start()
    {
        currentTick = ticker.TickCheck();
        lastTick = currentTick;
        hungerText.text = "Hunger: 100/100";
        cleanlinessText.text = "Cleanliness: 100/100";
        boredomText.text = "Boredom: 100/100";
    }

    private void Update()
    {
        currentTick = ticker.TickCheck();
        if (currentTick != lastTick)
        {
            creature.SubtractCare(currentTick);
        }
        lastTick = currentTick;

        hungerText.text = "Hunger:" + creature.GetHunger() + "/100";
        cleanlinessText.text = "Cleanliness:" + creature.GetCleanliness() + "/100";
        boredomText.text = "Boredom:" + creature.GetBoredom() + "/100";
    }
}
