using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowPoints4 : MonoBehaviour
{
    public Text sat1, sat2, sat3, sat4, sat5, satFinal1;

    // Start is called before the first frame update
    void Start()
    {
        ES3.Save<int>("Method4", ES3.Load<int>("Results16") + ES3.Load<int>("Results17") + ES3.Load<int>("Results18") + ES3.Load<int>("Results19") + ES3.Load<int>("Results20"));
    }

    // Update is called once per frame
    void Update()
    {
        sat1.text = ES3.Load<int>("Results16").ToString();
        sat2.text = ES3.Load<int>("Results17").ToString();
        sat3.text = ES3.Load<int>("Results18").ToString();
        sat4.text = ES3.Load<int>("Results19").ToString();
        sat5.text = ES3.Load<int>("Results20").ToString();
        satFinal1.text = ES3.Load<int>("Method4").ToString();
    }
}
