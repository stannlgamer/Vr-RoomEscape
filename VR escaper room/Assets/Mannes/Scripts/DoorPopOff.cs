using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPopOff : MonoBehaviour
{
    public Vector3 whatsPoppin;

    public void PopDoor()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().AddForce(whatsPoppin);
    }
}
