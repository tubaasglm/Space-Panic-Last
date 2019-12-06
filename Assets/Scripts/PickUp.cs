using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform TheDestination;
    public bool o2 = false;

    void OnMouseDown()
    {
        if (this.name == "O2")
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = TheDestination.position; //moving
            this.transform.parent = GameObject.Find("Destination").transform;
            o2 = true;
        }

    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
       // o2 = false;
    }
}
