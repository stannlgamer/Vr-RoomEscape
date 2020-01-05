using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public float despawnTime;
    [HideInInspector] public GameObject gun;

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject != gun && c.gameObject.tag != "Dart")
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            if (c.gameObject.GetComponent<Target>() != null)
            {
                transform.SetParent(c.transform);
            }
            Destroy(gameObject, despawnTime);
        }
    }

}
