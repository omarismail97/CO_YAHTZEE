using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameList : MonoBehaviour
{
    [SerializeField] private InputField gameListField = null;
    [SerializeField] private Button continueButton = null;


    private const string playerPrefsNameKey = "PlayerName";

    public void SetPlayerName(string playerName)
    {
        Debug.Log("UserEntered: " + gameListField.text);

        continueButton.interactable = !string.IsNullOrEmpty(gameListField.text);
    }

    private void SetInputField()
    {
        if(!PlayerPrefs.HasKey(playerPrefsNameKey))
        {
            return;
        }
        string defaultName = PlayerPrefs.GetString(playerPrefsNameKey);
        gameListField.text = defaultName;
        SetPlayerName(defaultName);

        throw new KeyNotFoundException();
    }

    public void SavePlayerName()
    {
        string playerName = gameListField.text;
        PhotonNetwork.NickName = playerName;

        PlayerPrefs.SetString(playerPrefsNameKey, playerName);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetInputField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
