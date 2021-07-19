using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //this class will contain all of the game logic to calculate the scores based on dice values

    public bool isSelected = false;

    public static DiceController diceController;
    public static Die[] currentDice = new Die[5];
    private static TranscriptController transcriptController;
    public int diceScore = 0;

    void Start()
    {
        diceController = GameObject.Find("DiceController").GetComponent<DiceController>();
        currentDice = diceController.diceObjects;
        print(gameObject.name);
    }
    public void selectScore()
    {
        isSelected = true;
        this.GetComponent<Text>().text = "5";
    }

    public void calculateScore()
    {
        if (! isSelected)
        {
            print(gameObject.name == "Ones");
            if (gameObject.name == "Ones")
            {
                diceScore = 0;
                foreach (Die die in currentDice)
                {
                    if (die.dieValue == 1)
                    {
                        diceScore = diceScore + die.dieValue;
                    }
                }
                this.GetComponent<Text>().text = diceScore.ToString();
            }
            if (gameObject.name == "Twos")
            {
                diceScore = 0;
                foreach (Die die in currentDice)
                {
                    if (die.dieValue == 2)
                    {
                        diceScore = diceScore + die.dieValue;
                    }
                }
                this.GetComponent<Text>().text = diceScore.ToString();

            }
        }
    }

    void Update()
    {
        calculateScore();
    }
}
