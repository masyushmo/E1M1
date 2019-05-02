using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_3p : MonoBehaviour
{
    public Transform cameraTarget; // target that camera will follow
    public Vector3 offset; //camera distance from player
    public float zoomSpeed = 5f;
    public float min = 5f;
    public float max = 50f;
    public float rotationSpeed = 100f;
    public float pitch = 2f;

    private float zoom = 10f;
    private float rotate = 0f; // value of rotation taken form A/D

    // Update is called once per frame
    void Update()
    {
        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoom = Mathf.Clamp(zoom, min, max);

        rotate -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        transform.position = cameraTarget.position - offset * zoom;
        transform.LookAt(cameraTarget.position + Vector3.up * pitch);
        transform.RotateAround(cameraTarget.position, Vector3.up, rotate);
    }
}
