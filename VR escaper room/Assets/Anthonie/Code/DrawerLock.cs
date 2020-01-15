using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerLock : MonoBehaviour
{
    public bool locked = true;
    public int lockNum;
    public GameObject drawer;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CheckLock()
    {
        if (!locked)
        {
            drawer.transform.tag = "Grab";
        }
    }
}
