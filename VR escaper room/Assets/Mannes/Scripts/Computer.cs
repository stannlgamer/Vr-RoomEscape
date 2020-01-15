using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public GameObject screen;
    bool powerOn;

    public void PowerOn()
    {
        if (!powerOn)
        {
            screen.SetActive(true);
            powerOn = true;
        }
        else
        {
            screen.SetActive(false);
            powerOn = false;
        }
    }
}
