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
    Vector3 lastFrameRot;

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

        lastFramePos = transform.position;
        lastFrameRot = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
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
                col.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                col.GetComponent<Rigidbody>().freezeRotation = true;
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
        holding.GetComponent<Rigidbody>().freezeRotation = false;
        holding.transform.parent = null;
        Vector3 CurrentVelocity = (transform.position - lastFramePos) / Time.deltaTime;
        holding.GetComponent<Rigidbody>().velocity = CurrentVelocity * trowMultiplier;
        Vector3 angularVel = (new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z) - lastFrameRot) / Time.deltaTime;
        holding.GetComponent<Rigidbody>().angularVelocity = angularVel;
    }
}
