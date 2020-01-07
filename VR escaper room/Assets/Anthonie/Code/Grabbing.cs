﻿using System.Collections;
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
    public string leftOrRightController;
    public Animator animator;
    public float checkButtonRange;

    void Start()
    {
        
    }

    void Update()
    {
        transform.localPosition = InputTracking.GetLocalPosition(NodeType);
        transform.localRotation = InputTracking.GetLocalRotation(NodeType);

        

        if (Input.GetAxis("RightGrip") >= .5 || Input.GetAxis("LeftGrip") >= .5)
        {
            bool point = false;
            Collider[] colliders = Physics.OverlapSphere(transform.position, checkButtonRange);
            for (int i = 0; i < colliders.Length  && !point; i++)
            {
                if(colliders[i].transform.tag == "Button")
                {
                    point = true;
                    animator.SetBool("Point", true);
                }
            }
            if (!point)
            {
                Grab();
                animator.SetBool("Close", true);
            }

            

        }
        else if (Input.GetAxis("RightGrip") < .5 || Input.GetAxis("LeftGrip") < .5)
        {
            LetGo();
            animator.SetBool("Close", false);
            animator.SetBool("Point", false);

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
        if (Input.GetButtonDown("TriggerLeft") || Input.GetButtonDown("TriggerRight"))
        {
            Use();
        }
        

        if(holding != null)
        {
            if (holding.transform.parent != transform)
            {
                LetGo();
            }
        }
        
        lastFramePos = transform.position;
        lastFrameRot = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
    }

    void Use()
    {
        if(holding.transform.tag == "ToyGun")
        {
            holding.GetComponent<Gun>().fire = true;
            print(leftOrRightController);
        }
    }

    void Grab()
    {
        bool grab = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, grabRadius);

        for (int i = 0; i < colliders.Length && !grab; i++)
        {
            if(colliders[i].transform.tag == "Grab" || colliders[i].transform.tag == "GrabAndDraw")
            {
                //lock position.
                var col = colliders[i].transform;
                col.GetComponent<Rigidbody>().useGravity = false;
                col.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                col.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                //make child of hand.
                col.parent = transform;
                holding = colliders[i].gameObject;
                grab = true;
            }


        }
    }

    public void LetGo()
    {
        if (holding.transform.parent == transform)
        {
            holding.transform.parent = null;
            holding.GetComponent<Rigidbody>().useGravity = true;
            holding.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezeAll;

            Vector3 CurrentVelocity = (transform.position - lastFramePos) / Time.deltaTime;
            holding.GetComponent<Rigidbody>().velocity = CurrentVelocity * trowMultiplier;
            Vector3 angularVel = (new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z) - lastFrameRot) / Time.deltaTime;
            holding.GetComponent<Rigidbody>().angularVelocity = angularVel;
        }
        
    }
}
