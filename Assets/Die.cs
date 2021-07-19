using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Die : MonoBehaviour
{
    public bool isHold = false;
    public int dieValue = 1;

    public void toggleDice()
    {
        TranscriptController transcriptController = GameObject.Find("TranscriptController").GetComponent<TranscriptController>();
        isHold = !isHold;

        if (isHold)
        {
            transcriptController.SendMessageToTranscript("Selecting die");

        }
        if(!isHold)
        {
            transcriptController.SendMessageToTranscript("Unselecting die");
        }
    }
}
