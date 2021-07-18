using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class YTLobby : MonoBehaviourPunCallbacks
{
   

    public InputField createGameInputField;
    public InputField joinGameInputField;
    public InputField userNameField;
    public GameObject lobbyPanel;

    public static string playerName;

    public void AddPlayer()
    {
        playerName = userNameField.text;
        Debug.Log(playerName);
        CreateGame("New Game");
    }

    public void CreateGame(string gameName)
    {
        string gameRoomName = (createGameInputField != null && createGameInputField.text.Length > 0) ? createGameInputField.text : gameName;

        PhotonNetwork.CreateRoom(gameRoomName);
        Debug.Log("Game room " + gameRoomName);
       
    }

    public void JoinGame()
    {
        string gameRoomName = joinGameInputField.text; //same field, change later
        PhotonNetwork.JoinRoom(gameRoomName);
        Debug.Log("Game room " + gameRoomName);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
        base.OnJoinedRoom();
    }


    // Start is called before the first frame update
    void Start()
    {
       // lobbyPanel.SetActive(false);


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
