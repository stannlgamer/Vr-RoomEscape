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
    public Color color;


    void Start()
    {
        transform.GetComponent<MeshRenderer>().materials[0].color = color;
    }

    void Update()
    {
        timeDraw -= Time.deltaTime;
        if(Physics.Raycast(transform.position, transform.right, out ray, drawRange))
        {
            if (ray.transform.tag == "Drawable" || ray.transform.tag == "GrabAndDraw")
            {
                if (currentLine == null)
                {
                    currentLine = Instantiate(lineRenderer, ray.point, Quaternion.identity, ray.transform);
                    currentLine.transform.localScale = new Vector3 (currentLine.transform.localScale.x / currentLine.transform.parent.transform.localScale.x, currentLine.transform.localScale.y / currentLine.transform.parent.transform.localScale.y, currentLine.transform.localScale.z / currentLine.transform.parent.transform.localScale.z);
                    currentLine.transform.localRotation = ray.transform.rotation;
                    currentLine.GetComponent<LineRenderer>().startColor = color;
                    currentLine.GetComponent<LineRenderer>().endColor = color;
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
