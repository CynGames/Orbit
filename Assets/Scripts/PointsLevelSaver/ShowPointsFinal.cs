using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowPointsFinal : MonoBehaviour
{
    public Text sat1, sat2, sat3, sat4, sat5, satFinal1;

    // Start is called before the first frame update
    void Start()
    {
        ES3.Save<int>("MethodFinal", ES3.Load<int>("Method1") + ES3.Load<int>("Method2") + ES3.Load<int>("Method3") + ES3.Load<int>("Method4") + ES3.Load<int>("Method5"));
    }

    // Update is called once per frame
    void Update()
    {
        sat1.text = ES3.Load<int>("Method1").ToString();
        sat2.text = ES3.Load<int>("Method2").ToString();
        sat3.text = ES3.Load<int>("Method3").ToString();
        sat4.text = ES3.Load<int>("Method4").ToString();
        sat5.text = ES3.Load<int>("Method5").ToString();
        satFinal1.text = ES3.Load<int>("MethodFinal").ToString();
    }
}

