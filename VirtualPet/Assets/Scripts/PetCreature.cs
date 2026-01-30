using UnityEngine;

public class PetCreature : MonoBehaviour
{
    public int currentHungry;
    public int currentCleanliness;
    public int currentBoredom;
    private int MaxValue = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHungry = 100;
        currentCleanliness = 100;
        currentBoredom = 100;
    }

    // Update is called once per frame
    //currently working on bar, should decrease every second, when full it waits 3 seconds before continuing
    //every button press makes it go up by 10
    //maybe we could give the bears different speeds and use a switch case for that. Like hunger is every second, 3 off the bar
    //cleanliness comes all in every 5 seconds at 15
    //boredom goes to half every 10 seonds
    void Update()
    {
        Debug.Log(currentHungry / MaxValue);
    }
}
