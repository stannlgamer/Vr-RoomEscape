using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Grabbing : MonoBehaviour
{
    public float grabRadius;
    GameObject holding;
    public float trowMultiplier;
    public XRNode NodeType;
    Vector3 lastFramePos;
    Vector3 lastFrameRot;
    public string leftOrRightController;
    public Animator animator;
    public float checkButtonRange;
    public Transform itemPos;
    public string triggerName;
    public string gripName;
    public Transform offset;
    public bool grabB;

    void Start()
    {
        
    }

    void Update()
    {
        transform.localPosition = InputTracking.GetLocalPosition(NodeType);
        transform.localRotation = InputTracking.GetLocalRotation(NodeType);

        

        if (Input.GetAxis(gripName) >= .5 || Input.GetKeyDown("g"))
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
        else if (Input.GetAxis(gripName) < .5)
        {
            animator.SetBool("Close", false);
            animator.SetBool("Point", false);
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
        if (Input.GetButtonDown(triggerName))
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
        if(holding.transform.name == "ToyGun")
        {
            holding.GetComponent<Gun>().Fire();
        }
        else if (holding.transform.name == "BlackLight")
        {
            holding.GetComponent<TurnLightOnOff>().TurnOnOff();
        }
    }

    void Grab()
    {
        if (grabB)
        {
            bool grab = false;
            Collider[] colliders = Physics.OverlapSphere(transform.position, grabRadius);
            if (colliders[0] != null)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (!grab)
                    {
                        if (colliders[i].transform.name == "ToyGun")
                        {
                            //lock position.
                            var col = colliders[i].transform;
                            col.GetComponent<Rigidbody>().useGravity = false;
                            col.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            col.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                            //col.transform.position = itemPos.position;
                            //make child of hand.
                            col.transform.position = offset.position;
                            col.transform.rotation = offset.rotation;
                            col.parent = transform;
                            holding = colliders[i].gameObject;
                            grab = true;
                        }
                        else if (colliders[i].transform.tag == "Grab" || colliders[i].transform.tag == "GrabAndDraw" || colliders[i].transform.tag == "Puzzle")
                        {
                            //lock position.
                            var col = colliders[i].transform;
                            col.GetComponent<Rigidbody>().useGravity = false;
                            col.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                            col.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                            //col.transform.position = itemPos.position;
                            //make child of hand.
                            col.parent = transform;
                            holding = colliders[i].gameObject;
                            grab = true;
                        }
                    }
                    


                }
            }
        }
        
        
    }

    public void LetGo()
    {
        if(holding != null)
        {
            if (holding.transform.parent.transform == transform)
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

    public void GameStart()
    {
        grabB = true;
    }
}
