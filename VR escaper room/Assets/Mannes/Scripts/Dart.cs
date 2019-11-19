using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public float despawnTime;
    
    public void Hit()
    {
        Destroy(gameObject, despawnTime);
    }
}
