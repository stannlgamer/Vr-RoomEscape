using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public float moveBackDelay;
    public float moveBackSpeed;
    private float timer;
    private Vector3 defaultPos;

    private void Start()
    {
        defaultPos = transform.position;
    }

    private void Update()
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

    public void Pressed()
    {
        timer = moveBackDelay;
    }
}
