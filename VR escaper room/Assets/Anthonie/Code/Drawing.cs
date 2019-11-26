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
    Vector3 drawSpawn;
    public float timeBetweenDraw;
    float timeDraw;


    void Start()
    {
        
    }

    void Update()
    {
        timeDraw -= Time.deltaTime;
        if(Physics.Raycast(transform.position, -transform.up, out ray, drawRange))
        {
            if (ray.transform.tag == "Drawable")
            {
                if (currentLine == null)
                {
                    currentLine = Instantiate(lineRenderer, ray.point, ray.transform.rotation, ray.transform);
                    drawSpawn = ray.point;
                    for (int i = 0; i < currentLine.GetComponent<LineRenderer>().positionCount; i++)
                    {
                        currentLine.GetComponent<LineRenderer>().SetPosition(i, ray.point - drawSpawn);
                    }
                    point = 0;
                }
                else
                {
                    if(timeDraw <= 0)
                    {
                        if (currentLine.GetComponent<LineRenderer>().GetPosition(point) != ray.point - drawSpawn)
                        {
                            for (int i = point; i < currentLine.GetComponent<LineRenderer>().positionCount; i++)
                            {
                                currentLine.GetComponent<LineRenderer>().SetPosition(i, ray.point - drawSpawn);
                            }
                            point++;
                        }
                        timeDraw = timeBetweenDraw;
                    }
                    
                    
                }
            }
            else
            {
                currentLine.GetComponent<LineRenderer>().positionCount = point;
                currentLine = null;
            }
        }
        else
        {
            currentLine.GetComponent<LineRenderer>().positionCount = point;
            currentLine = null;
        }



    }
}
