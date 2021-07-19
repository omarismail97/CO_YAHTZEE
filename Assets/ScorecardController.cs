using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorecardController : MonoBehaviour
{
    //this class will contain all of the game logic to calculate the scores based on dice values
    public int scoreValue = 0;
    public static DiceController diceController;
    public static Die[] currentDice = new Die[5];
    private static TranscriptController transcriptController;

    // Start is called before the first frame update
    void Start()
    {
        diceController = GameObject.Find("DiceController").GetComponent<DiceController>();
        currentDice = diceController.diceObjects;
        transcriptController = GameObject.Find("TranscriptController").GetComponent<TranscriptController>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(currentDice.Length);
        //foreach (Die die in currentDice)
        //{
        //    print(die.dieValue);
        //}
    }

    public void pickScore()
    {

    }
}
