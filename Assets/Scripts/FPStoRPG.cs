using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FPStoRPG : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject player = GameObject.Find("Player");
            GameObject camera = GameObject.Find("Main Camera");

            player.GetComponent<Moves>().enabled = true;
            player.GetComponent<Move_3p>().enabled = false;
            player.GetComponent<MoveControl>().enabled = false;
            player.GetComponent<NavMeshAgent>().enabled = false;
            camera.GetComponent<camera_3p>().enabled = false;
            camera.GetComponent<CameraToPlayer>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            GameObject player = GameObject.Find("Player");
            GameObject camera = GameObject.Find("Main Camera");

            player.GetComponent<Moves>().enabled = false;
            player.GetComponent<Move_3p>().enabled = true;
            player.GetComponent<MoveControl>().enabled = true;
            player.GetComponent<NavMeshAgent>().enabled = true;
            camera.GetComponent<camera_3p>().enabled = true;
            camera.GetComponent<CameraToPlayer>().enabled = false;
        }
    }
}
