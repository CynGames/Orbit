using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerTutorial : MonoBehaviour
{
    public int scoreInSeconds;
    public float timerScore = 130f;
    public Text TimeScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreInSeconds = (int)(timerScore);
        TimeScoreText.text = scoreInSeconds.ToString();
        timerScore -= Time.deltaTime;

        if (timerScore < 0)
        {
            timerScore = 0;
        }
    }
}

