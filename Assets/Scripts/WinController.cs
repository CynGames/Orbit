using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinController : MonoBehaviour
{
    public GameObject YouLose;
    public Button NextLevel;

    // Start is called before the first frame update
    void Start()
    {
        if (ES3.Load<int>("ScoreLevel") < ES3.Load<int>("ScoreToNextScene"))
        {
            YouLose.SetActive(true);
            NextLevel.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
