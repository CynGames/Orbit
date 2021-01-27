using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OneVSOneResults : MonoBehaviour
{
    public Button PlayAgain, PlayOtherLevel;
    public Text Player1, Player2;
    public int scoreFinalPlayer1, scoreFinalPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        ES3.Load<int>("PlayerCount");
        scoreFinalPlayer1 = ES3.Load<int>("Player1Points");
        scoreFinalPlayer2 = ES3.Load<int>("Player2Points");
    }

    // Update is called once per frame
    void Update()
    {
        Player1.text = scoreFinalPlayer1.ToString();
        Player2.text = scoreFinalPlayer2.ToString();

        if (ES3.Load<int>("PlayerCount") == 0)
        {
            PlayAgain.interactable = true;
            PlayOtherLevel.interactable = false;
        }

        if (ES3.Load<int>("PlayerCount") == 1)
        {
            PlayAgain.interactable = false;
            PlayOtherLevel.interactable = true;
        }
    }
}
