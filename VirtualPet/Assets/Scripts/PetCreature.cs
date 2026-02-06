using UnityEngine;

public class PetCreature : MonoBehaviour
{
    public int currentHungry;
    public int currentCleanliness;
    public int currentBoredom;
    //private int MaxValue = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHungry = 100;
        currentCleanliness = 100;
        currentBoredom = 100;
    }
    
    void Update()
    {
        //Debug.Log(currentHungry / MaxValue);
    }

    public void SubtractCare(int tick)
    {
        Debug.Log(tick);
        currentHungry -= 2;
        switch (tick)
        {
            case 2: case 4:
                currentCleanliness -= 5;
                break;
         
            case 5:
                currentBoredom -= 25;
                break;
        }
    }

    public int GetHunger()
    {
        return currentHungry;
    }
    public int GetCleanliness()
    {
        return currentCleanliness;
    }
    public int GetBoredom()
    {
        return currentBoredom;
    }
}
