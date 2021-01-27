using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SecTutorial : MonoBehaviour
{
    public GameObject MethodWelcome;
    public GameObject readyPopUp;
    public GameObject CanvasTutorial;
    //bool meteoritoMuerto = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Meteorite")
        {
            Destroy(collision.gameObject);
            readyPopUp.SetActive(true);
            //meteoritoMuerto = true;
        }
    }

    public void StartTutorial02()
    {
        MethodWelcome.SetActive(false);
        CanvasTutorial.SetActive(true);
    }

}
