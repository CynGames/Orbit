using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ResultsMenuController : MonoBehaviour
{
    public GameObject GlobalController;

    public Text TextScoreFinal;
    public int scoreFinal;
    public Text TextTimeFinal;
    public int scoreInSecondsResults;
    public Text TextTimeDrag;
    public int TextTimeDragResults;

    // Start is called before the first frame update
    void Start()
    {
        scoreFinal = ES3.Load<int>("ScoreLevel");
        scoreInSecondsResults = (int)(ES3.Load<float>("TimerScore") - (ES3.Load<int>("ScoreInSeconds")));
        TextTimeDragResults = (int)(ES3.Load<int>("TimerDragInSeconds"));
    }

    // Update is called once per frame
    void Update()
    {
        TextTimeFinal.text = scoreInSecondsResults.ToString();
        TextScoreFinal.text = scoreFinal.ToString();
        TextTimeDrag.text = TextTimeDragResults.ToString();
    }
}                                                            