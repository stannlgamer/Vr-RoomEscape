using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLightOnOff : MonoBehaviour
{
    public GameObject lightObject;
    public bool on;
    
    public void TurnOnOff()
    {
        on = !on;
        lightObject.SetActive(on);
        transform.GetComponent<AudioSource>().Play(0);
    }
}
