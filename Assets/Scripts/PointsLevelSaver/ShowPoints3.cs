using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowPoints3 : MonoBehaviour
{
    public Text sat1, sat2, sat3, sat4, sat5, satFinal1;

    // Start is called before the first frame update
    void Start()
    {
        ES3.Save<int>("Method3", ES3.Load<int>("Results11") + ES3.Load<int>("Results12") + ES3.Load<int>("Results13") + ES3.Load<int>("Results14") + ES3.Load<int>("Results15"));
    }

    // Update is called once per frame
    void Update()
    {
        sat1.text = ES3.Load<int>("Results11").ToString();
        sat2.text = ES3.Load<int>("Results12").ToString();
        sat3.text = ES3.Load<int>("Results13").ToString();
        sat4.text = ES3.Load<int>("Results14").ToString();
        sat5.text = ES3.Load<int>("Results15").ToString();
        satFinal1.text = ES3.Load<int>("Method3").ToString();
    }
}
