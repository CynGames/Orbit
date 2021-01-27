using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureInvControl : MonoBehaviour
{
    public int figureMoveCont = 0;
    public bool figuresOutInv = false;

    // Update is called once per frame
    void Update()
    {
        if (figureMoveCont == 2)
        {
            figuresOutInv = true;
        }
        else
        {
            figuresOutInv = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Circle")
        {
            Debug.Log("ColisionaConCircle");
            figureMoveCont = figureMoveCont + 1;
        }
        if (collision.gameObject.tag == "Square")
        {
            Debug.Log("ColisionaConSquare");
            figureMoveCont = figureMoveCont + 1;
        }
    }
}
