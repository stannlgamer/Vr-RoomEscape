using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public Transform start;
    public Transform end;

    void Update()
    {
        if(transform.position.x > start.position.x)
        {
            transform.position = start.position;
        }
        else if (transform.position.x < end.position.x)
        {
            transform.position = end.position;
        }
        if(transform.position.y != start.position.y)
        {
            Vector3 y = new Vector3(transform.position.x, start.position.y, transform.position.z);
            transform.position = y;
        }
        if (transform.position.z != start.position.z)
        {
            Vector3 z = new Vector3(transform.position.x, transform.position.y, start.position.z);
            transform.position = z;
        }
    }
}
