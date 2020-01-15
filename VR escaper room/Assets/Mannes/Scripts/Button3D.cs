using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour
{
    public UnityEvent onPress;

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Hand")
        {
            onPress.Invoke();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
}
