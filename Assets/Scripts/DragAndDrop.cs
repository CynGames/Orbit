using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 mOffset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnMouseDown()
    {
        // offset = pos del objeto en el mundo - mouse pos en el mundo
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }
   
    private Vector3 GetMouseAsWorldPoint()
    {
        // Coordenadas del mouse en los ejes (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }
}
