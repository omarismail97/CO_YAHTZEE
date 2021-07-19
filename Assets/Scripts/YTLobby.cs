using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class YTLobby : MonoBehaviourPunCallbacks
{
    public InputField createGameInputField;
    public InputField userNameField;
    public static string playerName;

    //not used now
    public InputField joinGameInputField;
    public GameObject lobbyPanel;
    //end of not used now


    /// <summary>
    /// New Player. Enter Name and create game
    /// </summary>
    public void AddPlayer()
    {
        playerName = userNameField.text;
        Debug.Log("Player Name: " + playerName);
        CreateGame("New Game");
    }

    public void CreateGame(string gameName)
    {
        playerName = userNameField.text;
        string gameRoomName = (createGameInputField != null && createGameInputField.text.Length > 0) ? createGameInputField.text : gameName;
        Debug.Log("Game room: " + gameRoomName);

        PhotonNetwork.CreateRoom(gameRoomName);
       
    }

    public void JoinGame()
    {
        playerName = userNameField.text;
        string gameRoomName = joinGameInputField.text; //same field, change later
        Debug.Log("Join Game room: " + gameRoomName);

        PhotonNetwork.JoinRoom(gameRoomName);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
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
