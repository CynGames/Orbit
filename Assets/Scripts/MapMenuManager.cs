using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMenuManager : MonoBehaviour
{
    public GameObject[] Levels;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    //TURN ON
    public void ActLevel1()
    {
        Levels[0].SetActive(true);
    }

    public void ActLevel2()
    {
        Levels[1].SetActive(true);
    }

    public void ActLevel3()
    {
        Levels[2].SetActive(true);
    }

    public void ActLevel4()
    {
        Levels[3].SetActive(true);
    }

    public void ActLevel5()
    {
        Levels[4].SetActive(true);
    }


    //TURN OFF
    public void BackLevel1()
    {
        Levels[0].SetActive(false);
    }

    public void BackLevel2()
    {
        Levels[1].SetActive(false);
    }

    public void BackLevel3()
    {
        Levels[2].SetActive(false);
    }

    public void BackLevel4()
    {
        Levels[3].SetActive(false);
    }

    public void BackLevel5()
    {
        Levels[4].SetActive(false);
    }
}  