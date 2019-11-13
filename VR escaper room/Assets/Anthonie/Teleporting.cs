﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public float teleportRange;
    public RaycastHit ray;
    public Transform teleportPositionIndicator;
    public Transform player;
    public float rotateAmount;
    bool rotated;
    float timer = .2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();

        if (Input.GetButton("RightTrackpadButton"))
        {
            TeleportCheck();
        }
        else
        {
            teleportPositionIndicator.position = new Vector3(0, -10, 0);

        }
        if (Input.GetButtonUp("RightTrackpadButton"))
        {
            Teleport();
        }
    }

    void TeleportCheck()
    {
        if(Physics.Raycast(transform.position, transform.forward, out ray, teleportRange))
        {
            teleportPositionIndicator.position = ray.point;
        }
        else
        {
            teleportPositionIndicator.position = new Vector3(0, -10, 0); 
        }

        
    }

    void Teleport()
    {
        if (Physics.Raycast(transform.position, transform.forward, out ray, teleportRange))
        {
            player.position = ray.point;

        }
    }

    void Rotate()
    {
        if (Input.GetAxis("RightGrip") >= .5 && !rotated)
        {
            player.Rotate(0, rotateAmount, 0);
            rotated = true;
        }
        else if (Input.GetAxis("LeftGrip") >= .5 && !rotated)
        {
            player.Rotate(0, -rotateAmount, 0);
            rotated = true;
        }
        else if (rotated)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                timer = 0.2f;
                rotated = false;
            }
        }
    }
}
