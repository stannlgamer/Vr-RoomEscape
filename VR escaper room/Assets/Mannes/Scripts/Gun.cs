using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool fire;

    public Transform emitter;
    public GameObject dartObject;
    public float force;

    void Update()
    {
        if (fire)
        {
            GameObject dart = Instantiate(dartObject, emitter.position, dartObject.transform.rotation);
            dart.GetComponent<Rigidbody>().AddForce(emitter.forward * force);
            dart.GetComponent<Dart>().gun = gameObject;
            fire = false;
        }
    }
}
