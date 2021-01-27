using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointsSaver : MonoBehaviour
{
    int ThisLevelScore;

    // Start is called before the first frame update
    void Start()
    {
        ThisLevelScore = ES3.Load<int>("ScoreLevel");
    }

    // Update is called once per frame
    void Update()
    {
        ES3.Save<int>("Level1Result", ThisLevelScore);
    }
}
