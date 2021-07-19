using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorecardController : MonoBehaviour
{
    //this class will contain all of the game logic to calculate the scores based on dice values
    public int scoreValue = 0;
    public DiceController diceController;
    public Score[] scoreList = new Score[6];

    // Start is called before the first frame update
    void Start()
    {
        Die[] currentDice = new Die[5];
        currentDice = diceController.diceObjects;
        foreach (Die die in currentDice) {
            print(die.dieValue);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pickScore()
    {

    }
}
