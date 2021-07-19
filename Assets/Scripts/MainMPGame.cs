using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class MainMPGame : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject findOpponentPanel = null;
    [SerializeField] private GameObject waitingStatusPanel = null;
    [SerializeField] private Text waitingStatus = null;

    private bool isConnecting = false;
    private const string GameVersion = "1.0";
    private const int MaxPlayersPerRoom = 6;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

    }


    public void FindOpponents()
    {
        isConnecting = true;

        findOpponentPanel.SetActive(false);
        waitingStatusPanel.SetActive(true);

        waitingStatus.text = "Searching...";

        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }


    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");

        if(isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        waitingStatusPanel.SetActive(false);
        findOpponentPanel.SetActive(true);

        Debug.Log($"Disconnected due to: {cause}");

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No clients are waiting for an opponent, creating a new room");

        // PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayersPerRoom });
        PhotonNetwork.CreateRoom("Room-1");

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Successfully joined a  room");

        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

        if(playerCount != MaxPlayersPerRoom)
        {
            waitingStatus.text = "Waiting for opponent...";
            Debug.Log("Waiing for opponent");
        }
        else
        {
            waitingStatus.text = "Opponent found...";
            Debug.Log("Ready to begin");
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
       if(PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayersPerRoom)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;

            Debug.Log("Max Players in room");
            waitingStatus.text = "Max Players in room...";

            PhotonNetwork.LoadLevel("SampleScene");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
