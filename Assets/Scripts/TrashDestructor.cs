using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDestructor : MonoBehaviour
{
    public GameObject GameController;
    public int trashScore;

    // Start is called before the first frame update
    void Start()
    {
        trashScore = 0;
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
            trashScore = trashScore + 100;
        }
    }
}
