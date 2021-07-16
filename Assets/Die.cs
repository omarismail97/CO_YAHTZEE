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
        isHold = !isHold;
    }
}
