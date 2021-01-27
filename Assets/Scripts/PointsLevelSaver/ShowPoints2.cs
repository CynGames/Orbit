using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowPoints2 : MonoBehaviour
{
    public Text sat1, sat2, sat3, sat4, sat5, satFinal1;

    // Start is called before the first frame update
    void Start()
    {
        ES3.Save<int>("Method2", ES3.Load<int>("Results6") + ES3.Load<int>("Results7") + ES3.Load<int>("Results8") + ES3.Load<int>("Results9") + ES3.Load<int>("Results10"));
    }

    // Update is called once per frame
    void Update()
    {
        sat1.text = ES3.Load<int>("Results6").ToString();
        sat2.text = ES3.Load<int>("Results7").ToString();
        sat3.text = ES3.Load<int>("Results8").ToString();
        sat4.text = ES3.Load<int>("Results9").ToString();
        sat5.text = ES3.Load<int>("Results10").ToString();
        satFinal1.text = ES3.Load<int>("Method2").ToString();
    }
}
