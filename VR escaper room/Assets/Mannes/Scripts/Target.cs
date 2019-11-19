using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnCollisionEnter(Collision c)
    {
        if(c.transform.tag == "Dart")
        {
            c.gameObject.GetComponent<Dart>().Hit();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            gameObject.tag = "Grab";
        }
    }
}
