using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadAndMapController : MonoBehaviour
{
    public GameObject LoadMenu;
    public Button ButtonMap;
    public Button ButtonLoad;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LoadMenu.GetComponent<LoadMenu>().ProgressIndex == 0)
        {
            ButtonLoad.interactable = false;
            ButtonMap.interactable = false;
        }
        else
        {
            ButtonLoad.interactable = true;
            ButtonMap.interactable = true;
        }
    }
}
