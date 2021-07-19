using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public bool isSelected = false;

    public void selectScore()
    {
        isSelected = true;
        this.GetComponent<Text>().text = "5";
    }

    public void calculateScore(){

    }
}
