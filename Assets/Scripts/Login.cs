using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Login : MonoBehaviourPunCallbacks
{
    public InputField gmObjInputField;
    public static string playerName;
    private const int MaxPlayersPerRoom = 6;


    /// <summary>
    /// Method: to take player Name, validate the uniquness of it 
    ///         and open Game page
    ///         
    /// </summary>
    public void playGame()
    {
       // InputField inputFieldName = this.GetComponentInChildren<InputField>();
        if (gmObjInputField != null)
        {
            playerName = gmObjInputField.text;
            Debug.Log("Player Name " + gmObjInputField.text);
        }

        //PhotonNetwork.CreateRoom("Room-1", new RoomOptions { MaxPlayers = MaxPlayersPerRoom });
        PhotonNetwork.CreateRoom("Room-1");

        // SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }


    public void JoinGame()
    {
        string gameRoomName = "Room-1"; //same field, change later
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
        GameObject.Find("Button").GetComponentInChildren<Text>().text = "Start Game";


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