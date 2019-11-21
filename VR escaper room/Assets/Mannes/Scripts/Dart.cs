using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public float despawnTime;
    [HideInInspector]
    public GameObject gun;

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject != gun)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            gameObject.transform.parent = c.gameObject.transform;
            Destroy(gameObject, despawnTime);
        }
    }

}
