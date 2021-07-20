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
    private Dictionary<int, int> diceValueCount = new Dictionary<int, int>()
        {
                {1, 0 },
                {2, 0 },
                {3, 0 },
                {4 ,0 },
                {5, 0 },
                {6, 0 }
        };
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
        diceScore = 0;
        if (!isSelected)
        {

            //foreach (KeyValuePair<int, int> kvp in diceValueCount)
            //{
           //    print("There are " + kvp.Value + " die with the value " + kvp.Key);
            //}

            if (UpperScoreKey.ContainsKey(gameObject.name))
            {
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
                if (diceValueCount.ContainsValue(3))
                {

                    foreach (Die die in currentDice)
                    {
                        diceScore = diceScore + die.dieValue;
                    }
                    this.GetComponent<Text>().text = diceScore.ToString();
                }
                else
                {
                    this.GetComponent<Text>().text = null;
                }
            }
            if (gameObject.name == "Four of a Kind")
            {
                if (diceValueCount.ContainsValue(4))
                {
                    foreach (Die die in currentDice)
                    {
                        diceScore = diceScore + die.dieValue;
                    }
                    
                    this.GetComponent<Text>().text = diceScore.ToString();
                }
                else
                {
                    this.GetComponent<Text>().text = null;
                }
            }
            if (gameObject.name == "Full House")
            {
                if (diceValueCount.ContainsValue(3) && diceValueCount.ContainsValue(2))
                {
                    diceScore = 25;
                    this.GetComponent<Text>().text = diceScore.ToString();
                }
                else
                {
                    this.GetComponent<Text>().text = null;
                }
            }

            if (gameObject.name == "Small Straight")
            {
                if ((diceValueCount[1] >= 1 && diceValueCount[2] >= 1 && diceValueCount[3] >= 1 && diceValueCount[4] >= 1) |
                    (diceValueCount[2] >= 1 && diceValueCount[3] >= 1 && diceValueCount[4] >= 1 && diceValueCount[5] >= 1) |
                    (diceValueCount[3] >= 1 && diceValueCount[4] >= 1 && diceValueCount[5] >= 1 && diceValueCount[6] >= 1))
                {
                    diceScore = 30;
                    this.GetComponent<Text>().text = diceScore.ToString();
                }
                else
                {
                    this.GetComponent<Text>().text = null;
                }
            }
            if (gameObject.name == "Large Straight")
            {
                if ((diceValueCount[1] >= 1 && diceValueCount[2] >= 1 && diceValueCount[3] >= 1 && diceValueCount[4] >= 1 && diceValueCount[5] >= 1) |
                    (diceValueCount[2] >= 1 && diceValueCount[3] >= 1 && diceValueCount[4] >= 1 && diceValueCount[5] >= 1 && diceValueCount[6] >= 1))
                {
                    diceScore = 40;
                    this.GetComponent<Text>().text = diceScore.ToString();
                }
                else
                {
                    this.GetComponent<Text>().text = null;
                }
            }
            if (gameObject.name == "Yahtzee")
            {
                if (diceValueCount.ContainsValue(5))
                {
                    diceScore = 50;
                    this.GetComponent<Text>().text = diceScore.ToString();
                }
                else
                {
                    this.GetComponent<Text>().text = null;
                }
            }
        }
    }

    public void resetDiceValueCount()
    {
        List<int> keys = new List<int>(diceValueCount.Keys);
        foreach (int key in keys)
        {
            diceValueCount[key] = 0;
        }
        //loop to populate diceCountValue dictionary
        foreach (Die die in currentDice)
        {
            diceValueCount[die.dieValue] = diceValueCount[die.dieValue] + 1;
        }
    }


    void Update()
    {
        resetDiceValueCount();
        calculateScore();
    }
}
