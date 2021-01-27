using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishMethodController : MonoBehaviour
{
    public GameObject pointsTable;
    public GameObject nextMethod;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointsTable()
    {
        pointsTable.SetActive(false);
        nextMethod.SetActive(true);
    }

    public void TutorialMap2()
    {
        SceneManager.LoadScene("TutorialMap2");
    }

    public void TutorialMap3()
    {
        SceneManager.LoadScene("TutorialMap3");
    }

    public void TutorialMap4()
    {
        SceneManager.LoadScene("TutorialMap4");
    }

    public void TutorialMap5()
    {
        SceneManager.LoadScene("TutorialMap5");
    }

    public void FinishGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
                                                                       