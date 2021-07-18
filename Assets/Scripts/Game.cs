using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using SWNetwork;

public class Game : MonoBehaviour
{
    //Login Page variables
    public Text txtWelcome;
    public Text txtUserName;

    NetworkID networkID;

    // Start is called before the first frame update
    void Start()
    {
       
        if(networkID.IsMine)
        {
            //
            Debug.Log("Player Name " + YTLobby.playerName);
            txtWelcome.text = "Welcome " + YTLobby.playerName + " to Yahtzee++";
            txtUserName.text = YTLobby.playerName;
           //
        }
       
    }

    public void OnClose()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
