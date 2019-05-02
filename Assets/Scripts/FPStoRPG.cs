using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FPStoRPG : MonoBehaviour
{
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        GameObject camera = GameObject.Find("Main Camera");

        bool FPS = false;
        float RPG = 0f;
        
        if (FPS == false && camera.GetComponent<camera_3p>().zoom == 0f)
        {
            FPS = true;
            player.GetComponent<Moves>().enabled = true;
            player.GetComponent<Move_3p>().enabled = false;
            player.GetComponent<MoveControl>().enabled = false;
            player.GetComponent<NavMeshAgent>().enabled = false;
            camera.GetComponent<camera_3p>().enabled = false;
            camera.GetComponent<CameraToPlayer>().enabled = true;
        }
        if (FPS == true && (RPG -= Input.GetAxis("Mouse ScrollWheel")) > 0f)
        {
            FPS = false;
            camera.GetComponent<camera_3p>().enabled = true;
            camera.GetComponent<CameraToPlayer>().enabled = false;
            camera.GetComponent<camera_3p>().zoom = 3f;
            player.GetComponent<Moves>().enabled = false;
            player.GetComponent<Move_3p>().enabled = true;
            player.GetComponent<MoveControl>().enabled = true;
            player.GetComponent<NavMeshAgent>().enabled = true;
        }
    }
}
