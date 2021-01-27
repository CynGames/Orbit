using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject NoItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        transform.parent.parent.GetComponent<InventoryController>().selectedItem = this.transform;
    }

    private void OnMouseExit()
    {
        if(!transform.parent.parent.GetComponent<InventoryController>().canDragItem)
        transform.parent.parent.GetComponent<InventoryController>().selectedItem = null;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Inventory"))
        {
            Debug.Log("Fuera del inventario");
            Instantiate(NoItem, parent: gameObject.transform.parent);
            this.transform.parent = null;
            gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0);
            this.gameObject.GetComponent<Collider>().enabled = true;
            Destroy(GetComponent<CapsuleCollider>());
            Destroy(GetComponent<Item>());
        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Inventory"))
        {
            Debug.Log("Fuera del inventario");
            Instantiate(NoItem, parent: gameObject.transform.parent);
            this.transform.parent = null;
            if(gameObject.tag != ("Meteorite"))
            {
                gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0);
            }
            //this.gameObject.GetComponent<Collider>().enabled = true;
            Destroy(GetComponent<CapsuleCollider>());
            Destroy(GetComponent<Item>());
        }
    }
}
