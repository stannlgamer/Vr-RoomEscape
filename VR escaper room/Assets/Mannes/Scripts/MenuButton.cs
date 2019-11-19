using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
    
    public class MenuButton : MonoBehaviour
{
    public float moveBackDelay;
    public float moveBackSpeed;
    private float timer;
    private Vector3 defaultPos;
    private Vector3 move;
    private bool pressing;
    private bool pressedBack;

    [Header("Execute Function")]
    public UnityEvent buttonPress;

    private void Start()
    {
        defaultPos = transform.position;
    }

    private void Update()
    {
        if (!pressing)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                if (GetComponent<BoxCollider>().isTrigger)
                {
                    GetComponent<BoxCollider>().isTrigger = false;
                }
                if (transform.position != defaultPos)
                {
                    transform.position = Vector3.MoveTowards(transform.position, defaultPos, moveBackSpeed * Time.deltaTime);
                }
            }
        }
    }

    public void Pressed()
    {
        timer = moveBackDelay;
        buttonPress.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            pressing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            pressing = false;
        }
        if (other.name == "PressPlate")
        {
            pressedBack = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && !pressedBack)
        {
            move.x = -moveBackSpeed;
            transform.Translate(move * Time.deltaTime); 
        }
        if (other.name == "PressPlate")
        {
            pressedBack = true;
        }
    }

    
}
