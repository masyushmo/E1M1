using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToPlayer : MonoBehaviour
{
    public Vector3 offset;
    public float pitch;
    public Transform target;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = target.position - offset;
        transform.rotation = target.rotation;
    }   
}
