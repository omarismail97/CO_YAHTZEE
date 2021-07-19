using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TranscriptController : MonoBehaviour
{
    public int maxMessages = 25;
    public GameObject chatPanel, textObject;
    [SerializeField] List<TranscriptMessage> messageList = new List<TranscriptMessage>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendMessageToTranscript("You pressed the space key!");
        }
    }

    public void SendMessageToTranscript(string text)
    {

        if (messageList.Count >= maxMessages) 
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }        
        TranscriptMessage newMessage = new TranscriptMessage();
        newMessage.text = text;
        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<Text>();
        newMessage.textObject.text = newMessage.text;


        messageList.Add(newMessage);
    }

}

[System.Serializable]
public class TranscriptMessage
{
    public string text;
    public Text textObject;
}