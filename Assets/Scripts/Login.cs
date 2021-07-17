using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public GameObject gmObjInputField;
    public static string playerName;


    /// <summary>
    /// Method: to take player Name, validate the uniquness of it 
    ///         and open Game page
    ///         
    /// </summary>
    public void playGame()
    {
        Debug.Log("Player Entry");


        InputField input = this.GetComponentInChildren<InputField>();
        if (input != null)
        {
            playerName = input.text;
            Debug.Log("Player Entry " + input.text);
        }



        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Button").GetComponentInChildren<Text>().text = "Start Game";

    }

    // Update is called once per frame
    void Update()
    {

    }
}