using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jvel;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SDpace is preset");
            GetComponent<Rigidbody>().velocity = Vector3.up * jvel;
        }
    }
}
