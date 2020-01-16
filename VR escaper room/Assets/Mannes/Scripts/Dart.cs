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
            if (c.gameObject.GetComponent<Target>() != null)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                transform.SetParent(c.transform);
            }
            Destroy(gameObject, despawnTime);
        }
    }

}
