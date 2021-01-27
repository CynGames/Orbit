using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    public Transform selectedItem, selectedSlot, originalSlot;

    public bool canDragItem = false;

    public bool isOutOfInventory = false;

    public bool alwaysOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && selectedItem != null)
        {
            canDragItem = true;
            originalSlot = selectedItem.parent;
            selectedItem.GetComponent<Collider>().enabled = false;
            SetItemsCollider(false);
        }

        if (Input.GetMouseButton(0) && selectedItem != null && canDragItem)
        {
            selectedItem.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
        else if (Input.GetMouseButtonUp(0) && selectedItem != null)
        {
            canDragItem = false;
            SetItemsCollider(true);
            if (selectedSlot == null)
            {
                if (selectedItem.GetComponent<Item>() == null)
                {
                    //Debug.Log("No tiene mas componente");
                    selectedItem = null;
                    isOutOfInventory = true;
                }
                else
                {
                    selectedItem.parent = originalSlot;
                }
            }
            else
            {
                if (isOutOfInventory == true)
                {
                    selectedSlot.GetChild(0).parent = null;
                    selectedItem.parent = null;
                }
                else
                {
                    if(selectedSlot.GetChild(0) != null)
                    {
                        selectedSlot.GetChild(0).parent = originalSlot;
                        selectedItem.parent = selectedSlot;
                    }
                    else
                    {
                        selectedItem.parent = selectedSlot;
                    }
                }
            }
            if (isOutOfInventory == true)
            {
                //Debug.Log("No tiene mas componente");
                selectedItem = null;
                if (alwaysOpen == true)
                {
                    isOutOfInventory = false;
                    gameObject.SetActive(false);
                }
            }
            else
            {
                originalSlot.GetChild(0).localPosition = Vector3.zero;
                selectedItem.localPosition = Vector3.zero;
                selectedItem.GetComponent<Collider>().enabled = true;
            }
        }
    }

    void SetItemsCollider(bool b)
    {
        foreach(GameObject item in GameObject.FindGameObjectsWithTag("Square"))
        {
            item.GetComponent<Collider>().enabled = b;
        }

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Circle"))
        {
            item.GetComponent<Collider>().enabled = b;
        }

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Diamond"))
        {
            item.GetComponent<Collider>().enabled = b;
        }

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Pentagon"))
        {
            item.GetComponent<Collider>().enabled = b;
        }

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Triangle"))
        {
            item.GetComponent<Collider>().enabled = b;
        }

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Meteorite"))
        {
            item.GetComponent<Collider>().enabled = b;
        }
    }

}
