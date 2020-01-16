using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public float teleportRange;
    public RaycastHit ray;
    public Transform teleportPositionIndicator;
    public Transform player;
    public float rotateAmount;
    float timer = .2f;
    public Animator animator;
    public string menuButtonName;
    public Transform teleportPos;
    public GameObject cameraMain;
    Vector3 oldPos;

    void Start()
    {
        Vector3 offset = new Vector3(cameraMain.transform.position.x - player.position.x, 0, cameraMain.transform.position.z - player.position.z);
        player.transform.position -= offset;
    }

    // Update is called once per frame
    void Update()
    {
        

        Rotate();

        if (Input.GetButton(menuButtonName))
        {
            TeleportCheck();
            animator.SetBool("Point", true);
        }
        else
        {
            teleportPositionIndicator.position = new Vector3(0, -10, 0);

        }
        if (Input.GetButtonUp(menuButtonName))
        {
            Teleport();
            animator.SetBool("Point", false);
        }
    }

    void TeleportCheck()
    {
        if(Physics.Raycast(teleportPos.position, transform.forward, out ray, teleportRange))
        {
            if(ray.transform.tag == "Teleport")
            {
                teleportPositionIndicator.position = ray.point;

            }
            else
            {
                teleportPositionIndicator.position = new Vector3(0, -10, 0);
            }
        }
        else
        {
            teleportPositionIndicator.position = new Vector3(0, -10, 0); 
        }

        
    }

    void Teleport()
    {
        if (Physics.Raycast(teleportPos.position, transform.forward, out ray, teleportRange))
        {
            if (ray.transform.tag == "Teleport")
            {
                Vector3 offset = new Vector3(cameraMain.transform.position.x - player.position.x, 0, cameraMain.transform.position.z - player.position.z);

                player.position = ray.point - offset;

            }
            

        }
    }

    void Rotate()
    {
        Vector3 oldPos = new Vector3(cameraMain.transform.position.x, 0, cameraMain.transform.position.z);
        if (Input.GetButtonDown("LeftTrackpadButton"))
        {
            
            player.Rotate(0, rotateAmount, 0);
            Vector3 offset = new Vector3(cameraMain.transform.position.x - player.position.x, 0, cameraMain.transform.position.z - player.position.z);

            player.position = oldPos - offset;
        }
        else if (Input.GetButtonDown("RightTrackpadButton"))
        {
            player.Rotate(0, -rotateAmount, 0);
            Vector3 offset = new Vector3(cameraMain.transform.position.x - player.position.x, 0, cameraMain.transform.position.z - player.position.z);

            player.position = oldPos - offset;
        }
        
    }
}
