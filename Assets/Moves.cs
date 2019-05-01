using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour
{
    public float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        var rot = new Vector3(0, Input.GetAxis("Mouse X"), 0);

        transform.Translate(move * speed * Time.deltaTime);
        transform.Rotate(rot);
    }
}
