using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ProgressController : MonoBehaviour
{
    bool Played;
    public int ProgressIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        if (ES3.FileExists("SaveData.es3"))
        {
            ProgressIndex = ES3.Load<int>("Progress");
            if ((ES3.Load<int>("Progress") < SceneManager.GetActiveScene().buildIndex))
            {
                Debug.Log("Cambia el index");
                ProgressIndex = SceneManager.GetActiveScene().buildIndex;
                ES3.Save<int>("Progress", ProgressIndex);
            }
        }
        else
        {
            Debug.Log("No data");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
