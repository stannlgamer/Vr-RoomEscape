using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpKutten : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "a")
        {
            Destroy(gameObject);
        }
    }
}
