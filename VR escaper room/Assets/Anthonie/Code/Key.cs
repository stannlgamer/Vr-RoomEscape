using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int keyNum;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Lock")
        {
            if(collision.transform.GetComponent<DoorLock>().lockNum == keyNum && collision.transform.GetComponent<DoorLock>().locked)
            {
                collision.transform.GetComponent<DoorLock>().door.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezeRotationY;
                collision.transform.GetComponent<DoorLock>().locked = false;
                transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                transform.GetComponent<BoxCollider>().enabled = false;
                transform.parent = collision.transform;
                transform.position = collision.transform.localPosition;
                


            }
        }
    }
}
