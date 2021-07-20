using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class Game : MonoBehaviour
{
    //Login Page variables
    public Text txtUserName;
    public Text txtPlayerCount;
    public InputField chatInputField;
    private static TranscriptController transcriptController;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Room. Player Name " + Login.playerName);
        if (txtUserName != null)
        {
            txtUserName.text = Login.playerName;
        }
     //   chatInputField.text = Login.playerName;
        txtPlayerCount.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();

        transcriptController = GameObject.Find("TranscriptController").GetComponent<TranscriptController>();
        transcriptController.SendMessageToTranscript("New Game by : " + Login.playerName, TranscriptMessage.SubsystemType.game);

        //test - find other users
        Debug.Log("Total players: " + PhotonNetwork.CurrentRoom.PlayerCount.ToString());
    }

    public void OnClose()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
