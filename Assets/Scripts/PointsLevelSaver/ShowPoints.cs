using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowPoints : MonoBehaviour
{
    public Text sat1, sat2, sat3, sat4, sat5, satFinal1;

    // Start is called before the first frame update
    void Start()
    {
        ES3.Save<int>("Method1", ES3.Load<int>("Results1") + ES3.Load<int>("Results2") + ES3.Load<int>("Results3") + ES3.Load<int>("Results4") + ES3.Load<int>("Results5"));
    }

    // Update is called once per frame
    void Update()
    {
        sat1.text = ES3.Load<int>("Results1").ToString();
        sat2.text = ES3.Load<int>("Results2").ToString();
        sat3.text = ES3.Load<int>("Results3").ToString();
        sat4.text = ES3.Load<int>("Results4").ToString();
        sat5.text = ES3.Load<int>("Results5").ToString();
        satFinal1.text = ES3.Load<int>("Method1").ToString();
    }
}
