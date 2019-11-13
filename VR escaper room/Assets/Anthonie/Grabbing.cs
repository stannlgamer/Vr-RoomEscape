using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Grabbing : MonoBehaviour
{
    public float grabRadius;
    public string inputName;
    GameObject holding;
    public float trowMultiplier;
    public XRNode NodeType;
    Vector3 lastFramePos;

    void Start()
    {
        
    }

    void Update()
    {
        transform.localPosition = InputTracking.GetLocalPosition(NodeType);
        transform.localRotation = InputTracking.GetLocalRotation(NodeType);


        if (Input.GetButtonDown(inputName))
        {
            Grab();
        }
        else if (Input.GetButtonUp(inputName))
        {
            LetGo();
        }
        else if(holding != null)
        {
            bool holdingB = false;
            Collider[] colliders = Physics.OverlapSphere(transform.position, grabRadius);
            for (int i = 0; i < colliders.Length && !holdingB; i++)
            {
                if(colliders[i].gameObject == holding)
                {
                    holdingB = true;
                }
                else if(i == colliders.Length - 1 && !holdingB)
                {
                    LetGo();
                }
            }
        }
    }

    void Grab()
    {
        bool grab = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, grabRadius);

        for (int i = 0; i < colliders.Length && !grab; i++)
        {
            if(colliders[i].transform.tag == ("Grab"))
            {
                //lock position.
                var col = colliders[i].transform;
                col.GetComponent<Rigidbody>().useGravity = false;
                //make child of hand.
                col.parent = transform;
                holding = colliders[i].gameObject;
                grab = true;
            }


        }
    }

    void LetGo()
    {
        holding.GetComponent<Rigidbody>().useGravity = true;
        holding.transform.parent = null;
        Vector3 CurrentVelocity = (transform.position - lastFramePos) / Time.deltaTime;
        holding.GetComponent<Rigidbody>().velocity = CurrentVelocity * trowMultiplier;
        holding = null;
        lastFramePos = transform.position;
    }
}
