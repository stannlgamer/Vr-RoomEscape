using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public float despawnTime;
    public GameObject dart;
    [HideInInspector]
    public GameObject gun;

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject != gun && c.gameObject.tag != "Dart")
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            transform.LookAt(gun.transform.forward);
            transform.SetParent(c.transform);
        }
    }

}
