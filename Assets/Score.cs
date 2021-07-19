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
    private Dictionary<string, int> UpperScoreKey = new Dictionary<string, int>()
        {
            { "Ones", 1 },
            { "Twos", 2 },
            {"Threes", 3},
            { "Fours", 4 },
            {"Fives", 5 },
            {"Sixes", 6 }
        };

    void Start()
    {
        diceController = GameObject.Find("DiceController").GetComponent<DiceController>();
        currentDice = diceController.diceObjects;
        print(gameObject.name);
    }
    public void selectScore()
    {
        if ( ! string.IsNullOrEmpty(this.GetComponent<Text>().text))
        {
            isSelected = true;
        }

    }

    public void calculateScore()
    {
        if (!isSelected)
        {
            if (UpperScoreKey.ContainsKey(gameObject.name))
            {
                diceScore = 0;
                foreach (Die die in currentDice)
                {
                    if (die.dieValue == UpperScoreKey[gameObject.name])
                    {
                        diceScore = diceScore + die.dieValue;
                    }
                }
                if (diceScore != 0)
                {
                    this.GetComponent<Text>().text = diceScore.ToString();
                } else
                {
                    this.GetComponent<Text>().text = null;
                }
                
            }
            if (gameObject.name == "Three of a Kind")
            {

            }
        }
    }


    void Update()
    {
        calculateScore();
    }
}
