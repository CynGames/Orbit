using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoxInteractController2 : MonoBehaviour
{
    GameObject Box;
    public GameObject invInteract3;

    /*public GameObject otherInv5;
    public GameObject otherInv6;*/

    Animator Anim;
       
    public int clickBoxCont = 0;

    public GameObject ConnectButton;

    // Start is called before the first frame update
    void Start()
    {
        //Boxes parameters
        invInteract3.SetActive(false);

        //Boxes animations
        Anim = gameObject.GetComponent<Animator>();

        ConnectButton.GetComponent<Button>().interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Box3")
                {
                    Debug.Log("Click en caja");

                    Anim.SetBool("BoxOpen", true);
                    Anim.SetBool("BoxStay", false);

                    invInteract3.SetActive(true);

                    clickBoxCont = 0;
                    ConnectButton.GetComponent<Button>().interactable = true;
                }

                if (hit.collider.tag == "BigBox3")
                {
                    clickBoxCont = clickBoxCont + 1;

                    if (clickBoxCont == 2)
                    {
                        Anim.SetBool("BoxOpen", true);
                        Anim.SetBool("BoxStay", false);

                        invInteract3.SetActive(true);

                        clickBoxCont = 0;
                        ConnectButton.GetComponent<Button>().interactable = true;

                    }
                }
            }
        }

        /*if (otherInv5.activeInHierarchy || otherInv6.activeInHierarchy)
        {
            invInteract3.SetActive(false);
        }*/
    }
}
