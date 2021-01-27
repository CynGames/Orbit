using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnableConnect : MonoBehaviour
{
    public float timerDrag;
    public int timerDragInSeconds;

    public GameObject BackgroundPlane;

    public GameObject GameController;
    public GameObject[] Elements;

    public GameObject[] Inventory;

    public bool isEnabled = false;
    public int i = 0;

    public GameObject ReadyButton;
    public GameObject BoxInteract;

    // Start is called before the first frame update
    void Start()
    {
        GameController.GetComponent<Test03092019>().enabled = false;
        Debug.Log(Elements.Length);
        for (i = 0; i < Elements.Length; i++)
        {
            Elements[i].GetComponent<DragAndDrop>().enabled = true;
        }
        i = 0;

        ReadyButton.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        timerDragInSeconds = (int)(timerDrag);

        if (isEnabled == false)
        {
            timerDrag += Time.deltaTime;
        }
    }

    public void CheckConnect()
    {
        //Debug.Log("Anda Connect");
        for(int l = 0; l < Inventory.Length; l++)
        {
            Inventory[l].SetActive(false);
        }
        GameController.GetComponent<Test03092019>().enabled = true;
        for (int i = 0; i < Elements.Length; i++)
        {
            Destroy(Elements[i].GetComponent<DragAndDrop>());
            Elements[i].transform.position = new Vector3(Elements[i].transform.position.x, Elements[i].transform.position.y, -2);
        }
        isEnabled = true;

        ReadyButton.GetComponent<Button>().interactable = true;
        Destroy(BoxInteract.GetComponent<BoxInteractController>());

    }
}
