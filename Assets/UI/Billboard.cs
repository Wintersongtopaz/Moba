using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Billboard Images are rotated to always face the camera
public class Billboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 start = Camera.main.transform.position;
        Vector3 end = transform.position;

        Quaternion rotation = Quaternion.LookRotation(end - start);
        transform.rotation = rotation;
    }
}
