using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Chat;
using Photon.Pun;


public class ChatController : MonoBehaviour, IChatClientListener
{
    public int maxMessages = 25;

    public GameObject chatPanel, textObject;
    public InputField chatBox;
    public Color playerMessage, info;
    public InputField username;
    ChatClient chatClient;

    #region IChatClientListener implementation

    public void DebugReturn (ExitGames.Client.Photon.DebugLevel level, string message)
    {
        throw new System.NotImplementedException ();
    }

    public void OnDisconnected ()
    {
        throw new System.NotImplementedException ();
    }

    public void OnConnected ()
    {
        throw new System.NotImplementedException ();
    }

    public void OnChatStateChange (ChatState state)
    {
        throw new System.NotImplementedException ();
    }

    public void OnGetMessages (string channelName, string[] senders, object[] messages)
    {
        throw new System.NotImplementedException ();
    }

    public void OnPrivateMessage (string sender, object message, string channelName)
    {
        throw new System.NotImplementedException ();
    }

    public void OnSubscribed (string[] channels, bool[] results)
    {
        throw new System.NotImplementedException ();
    }

    public void OnUnsubscribed (string[] channels)
    {
        throw new System.NotImplementedException ();
    }

    public void OnStatusUpdate (string user, int status, bool gotMessage, object message)
    {
        throw new System.NotImplementedException ();
    }

    public void OnUserSubscribed (string user, bool gotMessage)
    {
        throw new System.NotImplementedException ();
    }

    public void OnUserSubscribed (string user, string message)
    {
        throw new System.NotImplementedException ();
    }
    public void OnUserUnsubscribed (string user, string message)
    {
        throw new System.NotImplementedException ();
    }

    #endregion
    
    [SerializeField] string userID;

    [SerializeField]
    List<Message> messageList = new List<Message>();
     
    // Start is called before the first frame update
    void Start()
    {
        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(userID));
    }

    public void Awake()
    {
        username.text = Login.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        chatClient.Service();
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                username.text = Login.playerName;
                SendMessageToChat(username.text + ": " + chatBox.text, Message.MessageType.playerMessage);
                chatBox.text = "";
            }
        }
        else 
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {   
                chatBox.ActivateInputField();
            }
        }

        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
             SendMessageToChat("You pressed the space key!", Message.MessageType.info);
             Debug.Log("Space");
            }
        }
    }

    public void SendMessageToChat(string text, Message.MessageType messageType)
    {

        if (messageList.Count >= maxMessages) 
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }        
        Message newMessage = new Message();
        newMessage.text = text;
        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<Text>();
        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);
    }

    Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color = info;

        switch (messageType)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;
        }

        return color;
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
    public MessageType messageType;

    public enum MessageType
    {
        playerMessage,
        info
    }

}