using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapMenuController : MonoBehaviour
{
    public GameObject[] Levels;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        Levels[0].GetComponent<Button>().interactable = true;
        for (i = 1; i < Levels.Length; i++)
        {
            Levels[i].GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
