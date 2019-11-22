using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    RaycastHit ray;
    public float drawRange;
    public GameObject currentLine;
    public GameObject lineRenderer;
    int point;


    void Start()
    {
        
    }

    void Update()
    {
        
        if(Physics.Raycast(transform.position, -transform.up, out ray, drawRange))
        {
            if (ray.transform.tag == "Drawable")
            {
                if (currentLine == null)
                {
                    currentLine = Instantiate(lineRenderer, ray.point, ray.transform.rotation, ray.transform);
                    for (int i = 0; i < currentLine.GetComponent<LineRenderer>().positionCount; i++)
                    {
                        currentLine.GetComponent<LineRenderer>().SetPosition(i, ray.point);
                    }
                    point = 0;
                }
                else
                {
                    
                    if (currentLine.GetComponent<LineRenderer>().GetPosition(point) != ray.point)
                    {
                        for (int i = point; i < currentLine.GetComponent<LineRenderer>().positionCount; i++)
                        {
                            currentLine.GetComponent<LineRenderer>().SetPosition(i, ray.point);
                        }
                        point++;
                    }
                    
                }
            }
            else
            {
                currentLine = null;
            }
        }
        else
        {
            currentLine = null;
        }



    }
}
