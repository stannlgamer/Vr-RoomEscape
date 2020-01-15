using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Lost")
        {
            transform.position = collision.transform.GetComponent<LostAndFound>().lostAndFoundtran.position;
        }
    }
}
