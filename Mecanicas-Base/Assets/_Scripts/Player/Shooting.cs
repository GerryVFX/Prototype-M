using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 rayPosition = transform.TransformDirection(Vector3.forward);
            RaycastHit hit;

            if (Physics.Raycast(transform.position, rayPosition, out hit))
                print("Found an object - distance: " + hit.transform.name);
            if (hit.transform.name == "Zombi1"|| hit.transform.name == "Zombi2"|| hit.transform.name == "Zombi3")
            {
                Destroy(hit.transform.gameObject);
            }

        }
    }
}
