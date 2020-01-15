using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform emitter;
    public GameObject dartObject;
    public float force;

    public void Fire()
    {
        GameObject dart = Instantiate(dartObject, emitter.position, transform.rotation);
        dart.GetComponent<Rigidbody>().AddForce(emitter.forward * force);
        dart.GetComponent<Dart>().gun = gameObject;
    }
}
