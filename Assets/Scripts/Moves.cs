using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour
{
    public float speed = 5f;
    public float jumpmove = 5f;

    private float FallMult = 2.5f;

    private float lowFallMult = 2f;

    private Rigidbody rb;
    
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        var rot = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jumpmove;
        }
        transform.Translate(move * speed * Time.deltaTime);
        transform.Rotate(rot);
    }
}
