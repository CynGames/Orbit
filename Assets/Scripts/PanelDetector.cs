using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDetector : MonoBehaviour
{
    public int figuresCount;
    public bool onPanel;
    public GameObject connectButton;
    public bool isConnectUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        onPanel = true;
    }

    // Update is called once per frame
    void Update()
    {
        isConnectUsed = connectButton.GetComponent<EnableConnect>().isEnabled;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pepe")
        {
            GameObject.Find("Circle").tag = ("Circle");
            GameObject.Find("Pentagon").tag = ("Pentagon");
            GameObject.Find("Triangle").tag = ("Triangle");
            GameObject.Find("Diamond").tag = ("Diamond");
            GameObject.Find("Square").tag = ("Square");
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        
    }
}                                                       