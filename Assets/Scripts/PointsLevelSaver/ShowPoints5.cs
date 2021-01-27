using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowPoints5 : MonoBehaviour
{
    public Text sat1, sat2, sat3, sat4, sat5, satFinal1;

    // Start is called before the first frame update
    void Start()
    {
        ES3.Save<int>("Method5", ES3.Load<int>("Results21") + ES3.Load<int>("Results22") + ES3.Load<int>("Results23") + ES3.Load<int>("Results24") + ES3.Load<int>("Results25"));
    }

    // Update is called once per frame
    void Update()
    {
        sat1.text = ES3.Load<int>("Results21").ToString();
        sat2.text = ES3.Load<int>("Results22").ToString();
        sat3.text = ES3.Load<int>("Results23").ToString();
        sat4.text = ES3.Load<int>("Results24").ToString();
        sat5.text = ES3.Load<int>("Results25").ToString();
        satFinal1.text = ES3.Load<int>("Method5").ToString();
    }
}
