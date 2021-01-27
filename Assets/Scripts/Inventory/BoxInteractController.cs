using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoxInteractController : MonoBehaviour
{
    GameObject Box;
    public GameObject invInteract;

    /*public GameObject otherInv;
    public GameObject otherInv2;*/

    Animator Anim;
       
    public int clickBoxCont = 0;

    public GameObject ConnectButton;

    // Start is called before the first frame update
    void Start()
    {
        //Boxes parameters
        invInteract.SetActive(false);

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
                if (hit.collider.tag == "Box")
                {
                    Debug.Log("Click en caja");

                    Anim.SetBool("BoxOpen", true);
                    Anim.SetBool("BoxStay", false);

                    invInteract.SetActive(true);

                    clickBoxCont = 0;
                    ConnectButton.GetComponent<Button>().interactable = true;
                }

                if (hit.collider.tag == "BigBox")
                {
                    clickBoxCont = clickBoxCont + 1;

                    if (clickBoxCont == 2)
                    {
                        Anim.SetBool("BoxOpen", true);
                        Anim.SetBool("BoxStay", false);

                        invInteract.SetActive(true);

                        clickBoxCont = 0;
                        ConnectButton.GetComponent<Button>().interactable = true;

                    }
                }
            }
        }

        /*if(otherInv.activeInHierarchy || otherInv2.activeInHierarchy)
        {
            invInteract.SetActive(false);
        }*/
    }
}
