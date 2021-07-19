using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorecardController : MonoBehaviour
{
    
    public int scoreValue = 0;
    private static TranscriptController transcriptController;


    // Start is called before the first frame update
    void Start()
    {
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
