using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    public GameObject GameController;
    public GameObject Trash;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Trash.GetComponent<TrashDestructor>().trashScore + GameController.GetComponent<Test03092019>().score + GameController.GetComponent<Test03092019>().timerScore;
    }
}