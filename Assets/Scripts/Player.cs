using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 //namespace Yahtzee.Model
//{

    public class Player : MonoBehaviour
    {
        private static string playerName = null;
        private static int leaderBoardPoints = 0;

        public static string GetPlayerName()
        {
            return playerName;
        }

        public static int GetLeaderBoardScore()
        {
            return leaderBoardPoints;
        }

        public static void SetPlayerName(string plName)
        {
            playerName = plName;
        }


        public static void SetLeaderBoardScore(int plPoints)
        {
            leaderBoardPoints = plPoints;
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

//}