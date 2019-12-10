using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int keyNum;


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag == "Lock")
        {
            if(collision.transform.GetComponent<DoorLock>() != null)
            {
                if (collision.transform.GetComponent<DoorLock>().lockNum == keyNum && collision.transform.GetComponent<DoorLock>().locked)
                {
                    if (transform.parent.tag == "Hand")
                    {
                        transform.parent.GetComponent<Grabbing>().LetGo();
                    }
                    collision.transform.GetComponent<DoorLock>().door.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezeAll;
                    collision.transform.GetComponent<DoorLock>().locked = false;
                    Destroy(gameObject.GetComponent<Rigidbody>());
                    transform.GetComponent<BoxCollider>().enabled = false;
                    transform.position = collision.transform.position;
                    transform.parent = collision.transform;

                }
            }
            else if (collision.transform.GetComponent<DrawerLock>() != null)
            {
                if (collision.transform.GetComponent<DrawerLock>().lockNum == keyNum && collision.transform.GetComponent<DrawerLock>().locked)
                {
                    if(transform.parent != null)
                    {
                        if (transform.parent.tag == "Hand")
                        {
                            transform.parent.GetComponent<Grabbing>().LetGo();
                        }
                    }
                    collision.transform.GetComponent<DrawerLock>().locked = false;
                    collision.transform.GetComponent<DrawerLock>().CheckLock();
                    Destroy(gameObject.GetComponent<Rigidbody>());
                    transform.GetComponent<BoxCollider>().enabled = false;
                    transform.position = collision.transform.position;
                    transform.parent = collision.transform;

                }
            }

        }
        
    }
}
