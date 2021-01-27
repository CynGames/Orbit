using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointsSaver1 : MonoBehaviour
{
    public int thisLevelScore;
    string levelName;

    // Start is called before the first frame update
    void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
        thisLevelScore = ES3.Load<int>("ScoreLevel");
    }

    // Update is called once per frame
    void Update()
    {
        ES3.Save<int>(levelName, thisLevelScore);
        Debug.Log(ES3.Load<int>(levelName));
    }
}
                                                                 