using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    RaycastHit ray;
    public float teleportRange;


    void Start()
    {
        
    }

    void Update()
    {
        
        if(Physics.Raycast(transform.position, transform.forward, out ray, teleportRange))
        {
            if (ray.transform.tag == "Drawable")
            {

            }
        }



    }
}
