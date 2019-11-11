using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockKey : MonoBehaviour
{
    private Lock lockObj;
    public int value;

    private void Start()
    {
        lockObj = GetComponentInParent<Lock>();
    }

    private void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "Player")
        {
            print(value);
            lockObj.AddValue(value);
        }
    }
}
