using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackLight : MonoBehaviour
{
    public List<Collider> colliders = new List<Collider>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BlackLight")
        {
            if(other.transform.GetComponent<MeshRenderer>() != null)
            {
                other.transform.GetComponent<MeshRenderer>().enabled = true;

            }
            else if(other.transform.GetComponent<SpriteRenderer>() != null)
            {
                other.transform.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BlackLight")
        {
            if (other.transform.GetComponent<MeshRenderer>() != null)
            {
                other.transform.GetComponent<MeshRenderer>().enabled = false;

            }
            else if (other.transform.GetComponent<SpriteRenderer>() != null)
            {
                other.transform.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
