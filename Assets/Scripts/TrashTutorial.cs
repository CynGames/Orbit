using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTutorial : MonoBehaviour
{
    public bool ripMeteorito = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Meteorite")
        {
            Debug.Log("Meteorito choca basura");
            Destroy(col.gameObject);
            ripMeteorito = true;
        }
    }
}
