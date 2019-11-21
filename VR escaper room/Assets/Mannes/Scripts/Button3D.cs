using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour
{
    public UnityEvent onPress;

    void OnPress()
    {
        onPress.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            OnPress();
        }
    }
}
