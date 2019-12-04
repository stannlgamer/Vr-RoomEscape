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

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag == "Lock")
        {
            if(collision.transform.GetComponent<DoorLock>().lockNum == keyNum && collision.transform.GetComponent<DoorLock>().locked)
            {
                collision.transform.GetComponent<DoorLock>().door.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezeAll;
                collision.transform.GetComponent<DoorLock>().locked = false;
                Destroy(gameObject.GetComponent<Rigidbody>());
                transform.GetComponent<CapsuleCollider>().enabled = false;
                transform.position = collision.transform.position;
                transform.parent = collision.transform;
                

                


            }
        }
    }
}
